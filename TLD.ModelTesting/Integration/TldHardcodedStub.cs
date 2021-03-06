﻿using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TLD.Model;
using TLD.Model.Detection;
using TLD.Model.Integration;
using TLD.Model.Learning;

namespace TLD.ModelTesting.Integration
{
    class TldHardcodedStub
    {
        public static ITld Instantiate()
        {
            IObjectModel objectModel = LoadObjectModel();
            MedianFlowTracker tracker = LoadTracker();
            IDetector detector = LoadDetector(objectModel);
            ILearner learner = LoadLearner(objectModel, detector);

            ITld tld = new Tld(
                objectModel,
                tracker,
                learner,
                detector,
                new ZdenekOutputStrategy(objectModel, learner)
            );
            tld.PostInstantiation();

            return tld;
        }

        private static IObjectModel LoadObjectModel()
        {
            ObjectModel objectModel = new ObjectModel(new Size(15, 15));
            objectModel.PostInstantiation();
            return objectModel;
        }

        private static ILearner LoadLearner(IObjectModel objectModel, IDetector detector)
        {
            // initial positive patch synthesis info
            WarpInfo initPosPatchWarpInfo = new WarpInfo(0.01f, 0.01f, 10);
            PositivePatchSynthesisInfo initPosPatchSynthesisInfo = new PositivePatchSynthesisInfo(
                100, 10, initPosPatchWarpInfo, 0.2
            );
            WarpInfo runtimePosPatchWarpInfo = new WarpInfo(0.01f, 0.01f, 10);
            PositivePatchSynthesisInfo runtimePosPatchSynthesisInfo = new PositivePatchSynthesisInfo(
                100, 10, runtimePosPatchWarpInfo, 0.2
            );

            // initial negative patch picking info
            NegativePatchPickingInfo initNegPatchPickInfo = new NegativePatchPickingInfo(50, 10, 0.2f);
            NegativePatchPickingInfo runtimeNegPatchPickInfo = new NegativePatchPickingInfo(100, 10, 0.2f);

            Learner learner = new Learner(
                objectModel,
                detector,
                initPosPatchSynthesisInfo,
                initNegPatchPickInfo,
                runtimePosPatchSynthesisInfo,
                runtimeNegPatchPickInfo,
                0.95f,
                0.57f
            );

            return learner;
        }

        private static IDetector LoadDetector(IObjectModel objectModel)
        {
            // scanning window generator
            IScanningWindowGenerator scanningWindowGenerator = new ScanningWindowGenerator
            (
            1.2f,
            0.1f,
            0.1f,
            100
            );

            // cascaded classifier

            //      variance classifier
            IClassifier varianceClassifier = new VarianceClassifier(scanningWindowGenerator, 0.5);

            //      ensemble classifier
            int width = objectModel.PatchSize.Width;
            int height = objectModel.PatchSize.Height;
            IPixelComparisonScheduler pcs = new PixelComparisonScheduler(12, 3, width, height);
            IClassifier ensembleClassifier = new EnsembleClassifier(scanningWindowGenerator, pcs, 2);

            //      nn classifier
            NnClassifier nnClassifier = new NnClassifier(scanningWindowGenerator, objectModel, 0.75f, 0.55f);

            // instantiate cascaded classifier
            IClassifier cascadedClassifier = new CascadedClassifier(varianceClassifier, ensembleClassifier, nnClassifier);

            IDetector detector = new Detector
            (
            scanningWindowGenerator,
            cascadedClassifier,
            Service.NonMaximalBoundingBoxSuppress
            );

            return detector;
        }

        private static MedianFlowTracker LoadTracker()
        {
            MedianFlowTrackerBoundingBox bb = LoadBoundingBox();
            LucasKanadeTracker lkTracker = LoadLucasKanade();

            // fb error calculator
            MedianFlowTracker.FBError_Calculator fbErrorCalc = Service.FBError;

            // ncc calculator
            MedianFlowTracker.NCC_Calculator nccCalc = Service.NCC;

            // patch size
            Size patchSize = new Size(8, 8);

            // mad treshold
            float madTreshold = 10;

            return new MedianFlowTracker
            (
                bb,
                lkTracker,
                fbErrorCalc,
                nccCalc,
                patchSize,
                madTreshold
            );
        }

        private static MedianFlowTrackerBoundingBox LoadBoundingBox()
        {
            return new MedianFlowTrackerBoundingBox(new Size(8, 8), new SizeF(5, 5));
        }

        private static LucasKanadeTracker LoadLucasKanade()
        {
            LucasKanadeTracker lkTracker = new LucasKanadeTracker
            (
                new Size(8, 8),
                4,
                new MCvTermCriteria(20, 0.03),
                LKFLOW_TYPE.DEFAULT,
                LKFLOW_TYPE.CV_LKFLOW_PYR_A_READY | LKFLOW_TYPE.CV_LKFLOW_PYR_B_READY
            );

            return lkTracker;
        }
    }
}
