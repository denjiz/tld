using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLD.Model.Detection;

namespace TLD.ModelTesting.Detection
{
    class PixelComparisonSchedulerStub : IPixelComparisonScheduler
    {
        private PixelComparisonGroupF[] _scheduledComparisons;

        public PixelComparisonSchedulerStub(PixelComparisonGroupF[] scheduledComparisons)
        {
            _scheduledComparisons = scheduledComparisons;
        }

        public PixelComparisonSchedulerStub()
        {
            // TODO: Complete member initialization
        }

        #region IPixelComparisonScheduler

        public int BaseClassifierCount
        {
            get
            {
                return _scheduledComparisons.Length;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ComparisonsPerClassifier
        {
            get { return _scheduledComparisons[0].Value.Length; }
        }

        public void GeneratePixelComparisons()
        {
        }

        public PixelComparisonF[] GetComparisonsForClassifier(int classifier)
        {
            return _scheduledComparisons[classifier].Value;
        }

        public PixelComparisonGroupF[] ScheduledPixelComparisons
        {
            get { return _scheduledComparisons; }
            set { _scheduledComparisons = value; }
        }

        public void SchedulePixelComparisons()
        {
        }

        public int MaxComparisonsPerClassifier
        {
            get { return ComparisonsPerClassifier; }
            set { }
        }

        #endregion


        public int PatchWidth
        {
            get { throw new NotImplementedException(); }
        }

        public int PatchHeight
        {
            get { throw new NotImplementedException(); }
        }

        public void PostInstantiation()
        {
            
        }
    }
}
