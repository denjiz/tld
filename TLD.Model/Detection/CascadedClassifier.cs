using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TLD.Model.Detection
{
    [Serializable]
    public class CascadedClassifier : IClassifier
    {
        private IClassifier _varianceClassifier;
        private IClassifier _ensembleClassifier;
        private IClassifier _nnClassifier;

        public CascadedClassifier(
            IClassifier varianceClassifier,
            IClassifier ensembleClassifier,
            IClassifier nnClassifier
        )
        {
            _varianceClassifier = varianceClassifier;
            _ensembleClassifier = ensembleClassifier;
            _nnClassifier = nnClassifier;
        }

        #region IClassifier

        public void PostInstantiation()
        {
            _varianceClassifier.PostInstantiation();
            _ensembleClassifier.PostInstantiation();
            _nnClassifier.PostInstantiation();
        }

        public void Initialize(Image<Gray, byte> initialFrame, IBoundingBox initialBb)
        {
            _varianceClassifier.Initialize(initialFrame, initialBb);
            _ensembleClassifier.Initialize(initialFrame, initialBb);
            _nnClassifier.Initialize(initialFrame, initialBb);
        }

        public List<int> AcceptedWindows(Image<Gray, byte> frame, List<int> scanningWindows)
        {
            Stopwatch variance = new Stopwatch();
            variance.Start();
            List<int> varianceWindows = _varianceClassifier.AcceptedWindows(frame, scanningWindows);
            variance.Stop();

            Stopwatch ensemble = new Stopwatch();
            ensemble.Start();
            List<int> ensembleWindows = _ensembleClassifier.AcceptedWindows(frame, varianceWindows);
            ensemble.Stop();

            Stopwatch nn = new Stopwatch();
            nn.Start();
            List<int>       nnWindows =       _nnClassifier.AcceptedWindows(frame, ensembleWindows);
            nn.Stop();

            return nnWindows;
        }

        public void Update(List<Image<Gray, byte>> positivePatches, List<Image<Gray, byte>> negativePatches)
        {
            _ensembleClassifier.Update(positivePatches, negativePatches);
        }

        #endregion

        #region components (getters only)

        public IClassifier VarianceClassifier
        {
            get { return _varianceClassifier; }
        }

        public IClassifier EnsembleClassifier
        {
            get { return _ensembleClassifier; }
        }

        public IClassifier NnClassifier
        {
            get { return _nnClassifier; }
        }

        #endregion
    }
}
