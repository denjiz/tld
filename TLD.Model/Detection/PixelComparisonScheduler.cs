using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions.Collections;

namespace TLD.Model.Detection
{
    [Serializable]
    public class PixelComparisonScheduler : IPixelComparisonScheduler
    {
        private int _baseClassifierCount;
        private int _maxComparisonsPerClassifier;
        private int _patchWidth;
        private int _patchHeight;

        [NonSerialized]
        private PixelComparisonF[] _allPixelComparisons;

        private PixelComparisonGroupF[] _scheduledPixelComparisons;
        [NonSerialized]
        private int _comparisonsPerClassifier;

        public PixelComparisonScheduler(int baseClassifierCount, int maxComparisonsPerClassifier, int patchWidth, int patchHeight)
        {
            _baseClassifierCount = baseClassifierCount;
            _maxComparisonsPerClassifier = maxComparisonsPerClassifier;
            _patchWidth = patchWidth;
            _patchHeight = patchHeight;

            GeneratePixelComparisons();
            SchedulePixelComparisons();
        }

        public void PostInstantiation()
        {
            GeneratePixelComparisons();
            _comparisonsPerClassifier = _scheduledPixelComparisons[0].Value.Length;
            //SchedulePixelComparisons();
        }

        public void GeneratePixelComparisons()
        {
            _allPixelComparisons = Service.GeneratePixelComparisons(_patchWidth, _patchHeight).ToArray();
        }

        public void SchedulePixelComparisons()
        {
            List<PixelComparisonF> allPixelComparisons = new List<PixelComparisonF>(_allPixelComparisons);
            _scheduledPixelComparisons = new PixelComparisonGroupF[_baseClassifierCount];
            for (int i = 0; i < _baseClassifierCount; i++)
            {
                _scheduledPixelComparisons[i] = new PixelComparisonGroupF();
                _scheduledPixelComparisons[i].Value = new PixelComparisonF[_maxComparisonsPerClassifier];
            }

            _comparisonsPerClassifier = 0;
            while(allPixelComparisons.Count >= _baseClassifierCount && _comparisonsPerClassifier < _maxComparisonsPerClassifier)
            {
                for (int i = 0; i < _baseClassifierCount; i++)
                {
                    PixelComparisonF comparison = allPixelComparisons.RandomElement();
                    _scheduledPixelComparisons[i].Value[_comparisonsPerClassifier] = comparison;
                    allPixelComparisons.Remove(comparison);
                }

                _comparisonsPerClassifier += 1;
            }

            if (_comparisonsPerClassifier < _maxComparisonsPerClassifier)
            {
                for (int i = 0; i < _baseClassifierCount; i++)
                {
                    Array.Resize(ref _scheduledPixelComparisons[i].Value, _comparisonsPerClassifier);
                }
            }
        }

        public PixelComparisonF[] GetComparisonsForClassifier(int classifier)
        {
            return _scheduledPixelComparisons[classifier].Value;
        }

        #region configuration (getters and setters)

        public int BaseClassifierCount
        {
            get { return _baseClassifierCount; }
            set
            {
                _baseClassifierCount = value;
                SchedulePixelComparisons();
            }
        }

        public int MaxComparisonsPerClassifier
        {
            get { return _maxComparisonsPerClassifier; }
            set
            {
                _maxComparisonsPerClassifier = value;
                SchedulePixelComparisons();
            }
        }

        public int PatchWidth
        {
            get { return _patchWidth; }
            set { _patchWidth = value; }
        }
        public int PatchHeight
        {
            get { return _patchHeight; }
            set { _patchHeight = value; }
        }

        #endregion

        #region state (getters only)

        public PixelComparisonGroupF[] ScheduledPixelComparisons
        {
            get { return _scheduledPixelComparisons; }
        }

        public int ComparisonsPerClassifier
        {
            get { return _comparisonsPerClassifier; }
        }

        #endregion
    }
}
