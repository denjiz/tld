using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TLD.Model.Detection
{
    [Serializable]
    public class BaseClassifier
    {
        private int _myIndex;
        private IPixelComparisonScheduler _pixelComparisonScheduler;
        private IScanningWindowGenerator _scanningWindowGenerator;

        [NonSerialized]
        Point[][][] _comparisonsForWindow;
        [NonSerialized]
        byte[, ,] _currentFrameData;
        [NonSerialized]
        int _currCode;
        [NonSerialized]
        IBoundingBox _currBb;
        [NonSerialized]
        Dictionary<int, int> _positivePatches;
        [NonSerialized]
        Dictionary<int, int> _negativePatches;
        [NonSerialized]
        List<double> _posteriors;
        [NonSerialized]
        PixelComparisonF[] _strechedComparisons;
        [NonSerialized]
        Dictionary<IBoundingBox, int> _codes;
        [NonSerialized]
        private int[] bitMask;

        public BaseClassifier(IScanningWindowGenerator swg, int myIndex, IPixelComparisonScheduler pixelComparisonScheduler)
        {
            _scanningWindowGenerator = swg;
            this._myIndex = myIndex;
            this._pixelComparisonScheduler = pixelComparisonScheduler;

            PostInstantiation();
        }

        public void PostInstantiation()
        {
            _positivePatches = new Dictionary<int, int>();
            _negativePatches = new Dictionary<int, int>();
            _posteriors = new List<double>();
            _codes = new Dictionary<IBoundingBox, int>();
            _strechedComparisons = new PixelComparisonF[_pixelComparisonScheduler.ComparisonsPerClassifier];

            CalculateBitMask();
        }

        private void CalculateBitMask()
        {
            int count = _pixelComparisonScheduler.ComparisonsPerClassifier;
            bitMask = new int[count];
            for (int i = 0; i < count; i++)
            {
                bitMask[i] = 1 << count - i - 1;
            }
        }

        public void Initialize()
        {
            _positivePatches.Clear();
            _negativePatches.Clear();
            StretchComparisonsOnWindows();
        }

        private void StretchComparisonsOnWindows()
        {
            // get bbs that contain windows
            IBoundingBox[] bbs = _scanningWindowGenerator.ScanningWindows;

            // allocate space for comparisons
            int windowCount = bbs.Length;
            _comparisonsForWindow = new Point[windowCount][][];

            // calculate comparisons for every window
            for (int i = 0; i < windowCount; i++)
            {
                _comparisonsForWindow[i] = StretchComparisonsOnWindow(i);
            }
        }

        public void Update(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            AddPositiveExamples(positivePatches);
            AddNegativeExamples(negativePatches);
        }

        public void AddPositiveExamples(List<Image<Gray, byte>> patches)
        {
            for (int i = 0; i < patches.Count; i++)
            {
                Image<Gray, byte> patch = patches[i];

                // calculate patch's code
                int code = GetPatchCode(patch);

                // add it to the collection of positive patches with the same code
                AddPositiveCode(code);
            }
        }

        public void AddNegativeExamples(List<Image<Gray, byte>> patches)
        {
            for (int i = 0; i < patches.Count; i++)
            {
                Image<Gray, byte> patch = patches[i];

                // calculate patch's code
                int code = GetPatchCode(patch);

                // add it to the collection of negative patches with the same code
                AddNegativeCode(code);
            }
        }

        private void AddPositiveCode(int code)
        {
            if (!_positivePatches.ContainsKey(code))
            {
                _positivePatches.Add(code, 0);
            }
            _positivePatches[code] += 1;
        }

        private void AddNegativeCode(int code)
        {
            if (!_negativePatches.ContainsKey(code))
            {
                _negativePatches.Add(code, 0);
            }
            _negativePatches[code] += 1;
        }

        public void ForgetCodes()
        {
            _codes.Clear();
        }

        public double CalculatePosteriorForWindow(int windowIndex)
        {
            // calculate binary code for window
            _currCode = CalculateIntegerBinaryCodeForWindow(windowIndex);

            // calculate posterior for window
            int positives = _positivePatches.ContainsKey(_currCode) ? _positivePatches[_currCode] : 0;
            int negatives = _negativePatches.ContainsKey(_currCode) ? _negativePatches[_currCode] : 0;
            if (positives == 0 && negatives == 0)
            {
                return 0;
            }
            else
            {
                return ((double)positives) / (positives + negatives);
            }
        }

        public double GetPosterior(Image<Gray, byte> frame, IBoundingBox boundingBox)
        {
            if (_codes.ContainsKey(boundingBox))
            {
                _currCode = _codes[boundingBox];
            }
            else
            {
                _currCode = GetPatchCode(frame, boundingBox);
            }
            _currBb = boundingBox;

            // calculate posterior
            int positives = _positivePatches.ContainsKey(_currCode) ? _positivePatches[_currCode] : 0;
            int negatives = _negativePatches.ContainsKey(_currCode) ? _negativePatches[_currCode] : 0;
            if (positives == 0 && negatives == 0)
            {
                return 0;
            }
            else
            {
                return ((double)positives) / (positives + negatives);
            }
        }

        public void RememberLastCode()
        {
            _codes.Add(_currBb, _currCode);
        }

        public void SetCurrentFrame(Image<Gray, byte> frame)
        {
            _currentFrameData = frame.Data;
        }

        public int CalculateIntegerBinaryCodeForWindow(int windowIndex)
        {
            // get comparisons for window
            Point[][] comparisons = _comparisonsForWindow[windowIndex];

            // calculate code
            int binaryCode = 0;
            int count = comparisons.Length;
            for (int i = 0; i < count; i++)
            {
                Point pixel1 = comparisons[i][0];
                Point pixel2 = comparisons[i][1];
                byte intensity1 = _currentFrameData[pixel1.Y, pixel1.X, 0];
                byte intensity2 = _currentFrameData[pixel2.Y, pixel2.X, 0];

                if (intensity1 > intensity2)
                {
                    binaryCode = binaryCode | bitMask[i];
                }
            }

            return binaryCode;
        }

        public BoolArrayKey CalculateBinaryCodeForWindow(int windowIndex)
        {
            // get comparisons for window
            Point[][] comparisons = _comparisonsForWindow[windowIndex];

            // allocate memory for binary code
            int count = comparisons.Length;
            bool[] binaryCode = new bool[count];
            
            // calculate code
            for (int i = 0; i < count; i++)
            {
                Point pixel1 = comparisons[i][0];
                Point pixel2 = comparisons[i][1];
                byte intensity1 = _currentFrameData[pixel1.Y, pixel1.X, 0];
                byte intensity2 = _currentFrameData[pixel2.Y, pixel2.X, 0];

                binaryCode[i] = intensity1 > intensity2;
            }

            return new BoolArrayKey(binaryCode);
        }

        private int GetPatchCode(Image<Gray, byte> currentFrame, IBoundingBox patchBb)
        {
            // define region where the patch is
            currentFrame.ROI = Rectangle.Round(patchBb.GetRectangle());

            return GetPatchCode(currentFrame);
        }

        private int GetPatchCode(Image<Gray, byte> patch)
        {
            PixelComparisonF[] comparisons = _pixelComparisonScheduler.GetComparisonsForClassifier(_myIndex);

            // stretch comparisons over the patch
            StretchComparisons(patch.Size, comparisons, _strechedComparisons);

            // calculate the code
            int binaryCode = 0;
            for (int i = 0; i < _strechedComparisons.Length; i++)
            {
                PixelComparisonF strechedComparison = _strechedComparisons[i];
                double i1 = patch[Point.Round(strechedComparison.Pixel1)].Intensity;
                double i2 = patch[Point.Round(strechedComparison.Pixel2)].Intensity;

                // actual bit
                if (i1 > i2)
                {
                    binaryCode = binaryCode | bitMask[i];
                }
            }

            return binaryCode;
        }

        private void StretchComparisons(Size size, PixelComparisonF[] comparisons, PixelComparisonF[] strechedComparisons)
        {
            int width = size.Width;
            int height = size.Height;
            for (int i = 0; i < comparisons.Length; i++)
            {
                PixelComparisonF comparison = comparisons[i];
                PointF strechedPixel1 = comparisons[i].Pixel1.Multiply(width-1, height-1);
                PointF strechedPixel2 = comparisons[i].Pixel2.Multiply(width-1, height-1);
                strechedComparisons[i] = new PixelComparisonF(strechedPixel1, strechedPixel2);
            }
        }

        public Point[][] StretchComparisonsOnWindow(int windowIndex)
        {
            // get normalized comparisons
            PixelComparisonF[] normalizedComparisons = _pixelComparisonScheduler.GetComparisonsForClassifier(_myIndex);
            int comparisons = normalizedComparisons.Length;

            // allocate space for stretched comparisons
            Point[][] stretchedComparisons = new Point[comparisons][];
            for (int i = 0; i < comparisons; i++)
            {
                stretchedComparisons[i] = new Point[2];
            }

            // get scanning window and its parameters
            ScanningWindow window = _scanningWindowGenerator.ScanningWindows[windowIndex].ScanningWindow;
            Point windowLocation = window.Location;
            Size windowSize = window.Size;
            int windowWidth = windowSize.Width;
            int windowHeight = windowSize.Height;
            int windowWidthMinus1 = windowWidth - 1;
            int windowHeightMinus1 = windowHeight - 1;

            // calculate stretched comparisons
            for (int i = 0; i < comparisons; i++)
            {
                PixelComparisonF normalizedComparison = normalizedComparisons[i];
                Point[] stretchedComparison = stretchedComparisons[i];

                Point stretchedPixel1 = new Point((int)Math.Round(normalizedComparison.Pixel1.X * windowWidthMinus1 + windowLocation.X), (int)Math.Round(normalizedComparison.Pixel1.Y * windowHeightMinus1 + windowLocation.Y));
                Point stretchedPixel2 = new Point((int)Math.Round(normalizedComparison.Pixel2.X * windowWidthMinus1 + windowLocation.X), (int)Math.Round(normalizedComparison.Pixel2.Y * windowHeightMinus1 + windowLocation.Y));

                stretchedComparison[0] = stretchedPixel1;
                stretchedComparison[1] = stretchedPixel2;
            }

            return stretchedComparisons;
        }

        public void AddLastCodeAsPositive()
        {
            AddPositiveCode(_currCode);
        }

        public void AddLastCodeAsNegative()
        {
            AddNegativeCode(_currCode);
        }

        public void AddSeenBoundingBoxAsNegative(IBoundingBox bb)
        {
            AddNegativeCode(_codes[bb]);
        }

        public Point[][][] ComparisonsForWindow
        {
            get { return _comparisonsForWindow; }
        }
    }
}
