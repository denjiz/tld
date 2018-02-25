using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Combinatorics;

namespace TLD.Model
{
    [Serializable]
    public class MedianFlowTracker : ITracker
    {
        public delegate float FBError_Calculator(PointF point1, PointF point2);
        public delegate float NCC_Calculator(Image<Gray, byte> patch1, Image<Gray, byte> patch2);

        [NonSerialized]
        private Image<Gray, byte> _previousFrame;
        private bool _failureEnabled;
        [NonSerialized]
        private bool _failed;
        private IMedianFlowTrackerBoundingBox _currentBb;
        [NonSerialized]
        private IMedianFlowTrackerBoundingBox _previousBb;
        private ILucasKanadeTracker _lucasKanade;
        private FBError_Calculator _FBError;
        private NCC_Calculator _NCC;
        private Size _patchSize;
        private float _madTreshold;

        [NonSerialized]
        private Shift[] _reliableShiftArray;

        [NonSerialized]
        private Shift[] _validShiftArray;

        [NonSerialized]
        private MedianFlowTrackerStatus _status;

        public MedianFlowTrackerStatus Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        [NonSerialized]
        private float _fbErrorMedian;

        public float FbErrorMedian
        {
            get { return _fbErrorMedian; }
            private set { _fbErrorMedian = value; }
        }

        [NonSerialized]
        private float _nccMedian;

        public float NccMedian
        {
            get { return _nccMedian; }
            private set { _nccMedian = value; }
        }

        public IMedianFlowTrackerBoundingBox BoundingBox
        {
            get { return _currentBb; }
        }

        public IMedianFlowTrackerBoundingBox PrevBoundingBox
        {
            get { return _previousBb; }
        }

        public MedianFlowTracker(
            IMedianFlowTrackerBoundingBox bb,
            ILucasKanadeTracker lucasKanade,
            FBError_Calculator FBError,
            NCC_Calculator NCC,
            Size patchSize,
            float madTreshold
        )
        {
            _currentBb = bb;
            _lucasKanade = lucasKanade;
            _FBError = FBError;
            _NCC = NCC;
            _patchSize = patchSize;
            _madTreshold = madTreshold;

            _failureEnabled = true;
        }

        public void Initialize(Image<Gray, byte> frame, IBoundingBox boundingBox)
        {
            _previousFrame = frame;
            _currentBb.Center = boundingBox.Center;
            _currentBb.Size = boundingBox.Size;

            _lucasKanade.Initialize(frame);

            Status = MedianFlowTrackerStatus.OK;
            _failed = false;
        }

        public IBoundingBox FindObject(Image<Gray, byte> currentFrame)
        {
            /* If the tracker failed in the past,
             * don't try to track the object anymore
             */
            if (_failed)
            {
                return null;
            }

            /* Set up the state.
             */
            _previousBb = _currentBb;

            /* Get valid shifts.
             * Valid shift is a shift where both forward and backward point are found inside the frame.
             */

            // track points forward and backward
            PointF[] prevPoints = _previousBb.GetGridPoints();
            byte[] forwStatus;
            PointF[] forwPoints = _lucasKanade.TrackPointsForward(prevPoints, currentFrame, out forwStatus);
            byte[] backStatus;
            PointF[] backPoints = _lucasKanade.TrackPointsBackward(out backStatus);

            // create valid shifts
            List<Shift> validShiftList = new List<Shift>();
            for (int i = 0; i < prevPoints.Length; i++)
            {
                if (forwStatus[i] == 1 && backStatus[i] == 1)
                {
                    Shift shift = new Shift(prevPoints[i], forwPoints[i], backPoints[i]);
                    validShiftList.Add(shift);
                }
            }
            _validShiftArray = validShiftList.ToArray();

            // if there are less that 2 valid shifts, return null
            // (2 shifts are minimum if want to calculate scale)
            if (_validShiftArray.Length < 2)
            {
                Status = MedianFlowTrackerStatus.NOT_ENOUGH_VALID_SHIFTS;
                if (_failureEnabled)
                {
                    _failed = true;
                }
                return null;
            }

            /* Leave only reliable shifts.
             * Reliable shift is a shift which has, at the same time:
             *       - FB error <= median(FB error)
             *       - NCC      >= median(NCC)
             */

            // calculate FB error and NCC for each shift
            foreach (Shift shift in _validShiftArray)
            {
                shift.FBError = _FBError(shift.Previous, shift.Backward);
                shift.NCC = _NCC(
                    _previousFrame.GetPatch(shift.Previous, _patchSize),
                    currentFrame.GetPatch(shift.Forward, _patchSize)
                );
            }

            // calculate FB error and NCC median
            FbErrorMedian = Service.GetMedian<Shift>(_validShiftArray, s => s.FBError);
            NccMedian     = Service.GetMedian<Shift>(_validShiftArray, s => s.NCC);

            // if MAD (fbErrorMedian) is bigger that a threshold, return null
            if (FbErrorMedian > _madTreshold)
            {
                Status = MedianFlowTrackerStatus.MAD_TOO_BIG;
                if (_failureEnabled)
                {
                    _failed = true;
                }
                return null;
            }

            // leave only reliable shifts
            List<Shift> reliableShiftList = new List<Shift>();
            foreach (Shift shift in _validShiftArray)
            {
                if (shift.FBError <= FbErrorMedian && shift.NCC >= NccMedian)
                {
                    reliableShiftList.Add(shift);
                }
            }
            _reliableShiftArray = reliableShiftList.ToArray();

            // if there are no reliable shifts, return null
            if (_reliableShiftArray.Length < 2)
            {
                Status = MedianFlowTrackerStatus.NOT_ENOUGH_RELIABLE_SHIFTS;
                if (_failureEnabled)
                {
                    _failed = true;
                }
                return null;
            }

            /* Calculate horizontal translation, vertical translation and scale of the previous bounding box
             * Horizontal translation = median(horizontal translations of all shifts)
             * Vertical   translation = median(vertical   translations of all shifts)
             * Scale calculation:
             *      - for every pair of shifts, 
             *        calculate the ratio between the distances of their forward and previous points
             *      - scale is the median of these ratios
             */

            // calculate horizontal and vertical translation
            float transX = Service.GetMedian<Shift>(_reliableShiftArray, s => s.Horizontal);
            float transY = Service.GetMedian<Shift>(_reliableShiftArray, s => s.Vertical);

            // calculate scale
            Combinations<Shift> shiftPairs = new Combinations<Shift>(_reliableShiftArray, 2);
            long n = shiftPairs.Count;
            float[] ratios = new float[n];

            long _pair = 0;
            foreach (IList<Shift> pair in shiftPairs)
            {
                Shift s1 = pair[0];
                Shift s2 = pair[1];
                float forwDist = s1.Forward.DistanceTo(s2.Forward);
                float prevDist = s1.Previous.DistanceTo(s2.Previous);
                ratios[_pair] = forwDist / prevDist;
                _pair++;
            }

            float scale = Service.GetMedian<float>(ratios, r => r);

            /* Declare a tracking success and return the new bounding box
             */

            Status = MedianFlowTrackerStatus.OK;
            _previousFrame = currentFrame;
            _currentBb = _previousBb.CreateCurrent(transX, transY, scale);
            return _currentBb;
        }

        #region properties

        #region configuration (getters and setters)

        public bool FailureEnabled
        {
            get { return _failureEnabled; }
            set { _failureEnabled = value; }
        }

        public ILucasKanadeTracker LucasKanadeTracker
        {
            get { return _lucasKanade; }
            set { _lucasKanade = value; }
        }

        public Size NccPatchSize
        {
            get { return _patchSize; }
            set { _patchSize = value; }
        }

        public float MadTreshold
        {
            get { return _madTreshold; }
            set { _madTreshold = value; }
        }

        #endregion

        #region info (getters only)

        public bool Failed
        {
            get { return _failed; }
        }

        public Shift[] ValidShifts
        {
            get { return _validShiftArray; }
        }

        public Shift[] ReliableShifts
        {
            get { return _reliableShiftArray; }
        }

        #endregion

        #endregion
    }
}
