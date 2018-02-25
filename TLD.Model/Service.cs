using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using TLD.Model.Detection;
using Combinatorics;
using TLD.Model.Learning;

namespace TLD.Model
{
    public static class Service
    {
        private static Random _rand = new Random();

        public static float FBError(PointF p1, PointF p2)
        {
            return p1.DistanceTo(p2);
        }

        public static float NCC(Image<Gray, byte> patch1, Image<Gray, byte> patch2)
        {
            Image<Gray, float> matchImage = patch1.MatchTemplate(patch2, TM_TYPE.CV_TM_CCOEFF_NORMED);
            return (float)matchImage[0, 0].Intensity;
        }

        /// <summary>
        /// Sorts the array in place using the transformation function and returns the median value.
        /// </summary>
        /// <typeparam name="T">Type of the array.</typeparam>
        /// <param name="array">The array on which to calculate the median.</param>
        /// <param name="func">The transformation function to apply on each element.</param>
        /// <returns></returns>
        public static float GetMedian<T>(T[] array, Func<T, float> func)
        {
            Array.Sort(
                array,
                delegate(T elem1, T elem2)
                    {
                        return func(elem1).CompareTo(func(elem2));
                    }
            );

            float median;
            int lenght = array.Length;
            if (lenght % 2 == 1)
            {
                T elem = array[lenght / 2];
                median = func(elem);
            }
            else
            {
                T elem1 = array[lenght / 2 - 1];
                T elem2 = array[lenght / 2];
                median = (func(elem1) + func(elem2)) / 2;
            }

            return median;
        }

        private static double[,,] _integralData;
        private static double[,,] _squaredIntegralData;

        public static void SetIntegralImage(Image<Gray, double> integral)
        {
            _integralData = integral.Data;
        }

        public static void SetSquaredIntegralImage(Image<Gray, double> squaredIntegral)
        {
            _squaredIntegralData = squaredIntegral.Data;
        }

        /// <summary>
        /// Patch variance = E(P^2) - E^2(P)
        /// </summary>
        /// <param name="bb">Bounding box containing the patch.</param>
        /// <param name="sum">Integral image of pixel values.</param>
        /// <param name="squareSum">Integral image of squared pixel values.</param>
        /// <returns></returns>
        public static double GetPatchVariance(IBoundingBox bb)
        {
            // E(P)
            double patchMean = GetPatchMean_Integral(bb);

            // E(P^2)
            double squaredPatchMean = GetPatchMean_SquaredIntegral(bb);

            // E(P^2) - E^2(P)
            double patchVariance = squaredPatchMean - (patchMean * patchMean);

            return patchVariance;
        }

        /// <summary>
        /// Patch mean = ( S(A) + S(D) - S(B) - S(C) ) / patch.area
        /// </summary>
        /// <param name="boundingBox"></param>
        /// <param name="integral"></param>
        /// <returns></returns>
        public static double GetPatchMean_Integral(IBoundingBox boundingBox)
        {
            ScanningWindow window = boundingBox.ScanningWindow;

            double sum =    _integralData[window.AY, window.AX, 0] +
                            _integralData[window.DY, window.DX, 0] -
                            _integralData[window.BY, window.BX, 0] -
                            _integralData[window.CY, window.CX, 0];
            double mean = sum / window.Area;

            return mean;
        }

        public static double GetPatchMean_SquaredIntegral(IBoundingBox boundingBox)
        {
            ScanningWindow window = boundingBox.ScanningWindow;

            double sum =    _squaredIntegralData[window.AY, window.AX, 0] +
                            _squaredIntegralData[window.DY, window.DX, 0] -
                            _squaredIntegralData[window.BY, window.BX, 0] -
                            _squaredIntegralData[window.CY, window.CX, 0];
            double mean = sum / window.Area;

            return mean;
        }

        public static List<PixelComparisonF> GeneratePixelComparisons(int patchWidth, int patchHeight)
        {
            List<PixelComparisonF> comparisons = new List<PixelComparisonF>();
            float xStep = 1.0f / (patchWidth - 1);
            float yStep = 1.0f / (patchHeight - 1);

            // generate normalized pixel array
            PointF[,] normPixels = new PointF[patchHeight, patchWidth];
            for (int i = 0; i < patchHeight; i++)
            {
                float y = i * yStep;
                for (int j = 0; j < patchWidth; j++)
                {
                    float x = j * xStep;
                    normPixels[i, j] = new PointF(x, y);
                }
            }

            // generate horizontal comparisons
            PointF[] row = new PointF[patchWidth];
            for (int i = 0; i < patchHeight; i++)
            {
                // generate a 1-dim array of the pixels in the row
                for (int j = 0; j < patchWidth; j++)
                {
                    row[j] = normPixels[i, j];
                }

                // generate all 2-combinations of the pixels in the row
                Combinations<PointF> combinations = new Combinations<PointF>(row, 2);

                // added 2-combinations as pixel comparisons to a list of pixel comparisons
                foreach (IList<PointF> combination in combinations)
                {
                    comparisons.Add(new PixelComparisonF(combination[0], combination[1]));
                }
            }

            // generate vertical comparisons
            PointF[] col = new PointF[patchHeight];
            for (int j = 0; j < patchWidth; j++)
            {
                // generate a 1-dim array of the pixels in the column
                for (int i = 0; i < patchHeight; i++)
                {
                    col[i] = normPixels[i, j];
                }

                // generate all 2-combinations of the pixels in the column
                Combinations<PointF> combinations = new Combinations<PointF>(col, 2);

                // added 2-combinations as pixel comparisons to a list of pixel comparisons
                foreach (IList<PointF> combination in combinations)
                {
                    comparisons.Add(new PixelComparisonF(combination[0], combination[1]));
                }
            }

            return comparisons;
        }

        public static Image<Gray, byte> GeneratePatch(
            Image<Gray, byte> frame,
            IBoundingBox bb,
            WarpInfo warpInfo,
            double gaussianSigma,
            Size newSize
        )
        {
            Image<Gray, byte> patch;

            // warp
            if (warpInfo != null)
            {
                patch = GenerateSimilarPatch(frame, bb, warpInfo.MaxShift, warpInfo.MaxScale, warpInfo.MaxAngle);
            }
            else
            {
                patch = frame.GetPatch(bb.Center, Size.Round(bb.Size));
            }

            // add noise
            if (gaussianSigma != 0)
            {
                double sigmaX = gaussianSigma * patch.Width;
                double sigmaY = gaussianSigma * patch.Height;
                CvInvoke.cvSmooth(
                       patch,
                       patch,
                       SMOOTH_TYPE.CV_GAUSSIAN,
                       0, 0,
                       sigmaX, sigmaY
                   );
            }

            // resize
            if (newSize != Size.Empty)
            {
                patch = patch.Resize(newSize.Width, newSize.Height, INTER.CV_INTER_LINEAR);
            }

            return patch;
        }
    
        public static Image<Gray, byte> GenerateSimilarPatch(Image<Gray, byte> frame, IBoundingBox bb, float maxRelShift, float maxRelScale, double maxAngle)
        {
            // calculate new center
            PointF newCenter;
            if (maxRelShift != 0)
            {
                float relShift = (float)(_rand.NextDouble() * 2 - 1) * maxRelShift;
                PointF absShift = new PointF(relShift * bb.Size.Width, relShift * bb.Size.Height);
                newCenter = bb.Center.Add(absShift);
            }
            else
            {
                newCenter = bb.Center;
            }

            // calculate new size
            SizeF newSize;
            if (maxRelScale != 0)
            {
                float scale = 1.0f + (float)(_rand.NextDouble() * 2 - 1) * maxRelScale;
                newSize = bb.Size.Multiply(scale, scale);
            }
            else
            {
                newSize = bb.Size;
            }

            // calculate new bounding box
            IBoundingBox newBb = bb.CreateInstance(newCenter, newSize);

            // create patch
            Image<Gray, byte> patch = frame.GetPatch(newCenter, Size.Round(newSize));

            // rotate patch
            if (maxAngle != 0)
            {
                float angle = (float)((_rand.NextDouble() * 2 - 1) * maxAngle);
                float[,] m = new float[2,3];
                int w = patch.Width;
                int h = patch.Height;
                float angleRadians = angle * ((float)Math.PI / 180.0f);
                m[0,0] = (float)( Math.Cos(angleRadians) );
                m[0,1] = (float)( Math.Sin(angleRadians) );
                m[1,0] = -m[0,1];
                m[1,1] = m[0,0];
                m[0,2] = w*0.5f;  
                m[1,2] = h*0.5f;
                Matrix<float> M = new Matrix<float>(m);

                Image<Gray, byte> result = new Image<Gray, byte>(patch.Width, patch.Height);
                CvInvoke.cvGetQuadrangleSubPix(patch, result, M.Ptr);
                return result;
            }
            
            return patch;
        }

        public static List<IBoundingBox> SortScanningWindowsByOverlap(List<IBoundingBox> scanningWindows, IBoundingBox referenceBb)
        {
            List<IBoundingBox> sortedScanningWindows = scanningWindows.OrderBy(bb => (1 - bb.GetOverlap(referenceBb))).ToList();
            return sortedScanningWindows;
        }

        /// <summary>
        /// Assumes that a list of scanning windows is sorted by the overlap with the reference bb.
        /// </summary>
        /// <param name="overlap"></param>
        /// <param name="referenceBb"></param>
        /// <param name="scanningWindows"></param>
        /// <returns></returns>
        public static List<IBoundingBox> GetScanningWindowsWithOverlapGreaterOrEqualThan(float overlap, IBoundingBox referenceBb, List<IBoundingBox> sortedScanningWindows)
        {
            int index = sortedScanningWindows.FindIndex(bb => bb.GetOverlap(referenceBb) < overlap);
            List<IBoundingBox> result = sortedScanningWindows.GetRange(0, index);
            return result;
        }

        /// <summary>
        /// Assumes that a list of scanning windows is sorted by the overlap with the reference bb.
        /// </summary>
        /// <param name="overlap"></param>
        /// <param name="referenceBb"></param>
        /// <param name="sortedScanningWindows"></param>
        /// <returns></returns>
        public static List<IBoundingBox> GetScanningWindowsWithOverlapLessThan(float overlap, IBoundingBox referenceBb, List<IBoundingBox> sortedScanningWindows)
        {
            int index = sortedScanningWindows.FindIndex(bb => bb.GetOverlap(referenceBb) < overlap);
            List<IBoundingBox> result = sortedScanningWindows.GetRange(index, sortedScanningWindows.Count - index);
            return result;
        }

        public static List<IBoundingBox> NonMaximalBoundingBoxSuppress(List<IBoundingBox> boundingBoxes)
        {
            // initialize clustering
            int[] clustering = new int[boundingBoxes.Count];
            for (int i = 0; i < clustering.Length; i++)
            {
                clustering[i] = -1;
            }
            SortedList<int, int> clusters = new SortedList<int, int>();
            HashSet<int> deadClusters = new HashSet<int>();

            #region cluster bounding boxes

            for (int i = 0; i < boundingBoxes.Count; i++)
            {
                IBoundingBox bb1 = boundingBoxes[i];

                // find maximally overlapping bb among remaining bbs
                int maxOverlapBb = -1;
                float maxOverlap = 0.0f;
                for (int j = i+1; j < boundingBoxes.Count; j++)
                {
                    float overlap = bb1.GetOverlap(boundingBoxes[j]);
                    if (overlap > maxOverlap)
                    {
                        maxOverlapBb = j;
                        maxOverlap = overlap;
                    }
                }

                // if maximal overlap is big enough, merge bbs
                if (maxOverlap > 0.5f)
                {
                    if (clustering[i] == -1)
                    {
                        if (clustering[maxOverlapBb] == -1)
                        {
                            int cluster;
                            if (deadClusters.Count == 0)
                            {
                                cluster = clusters.Count;
                            }
                            else
                            {
                                cluster = deadClusters.Min();
                                deadClusters.Remove(cluster);
                            }
                            clustering[i] = cluster;
                            clustering[maxOverlapBb] = cluster;
                            clusters.Add(cluster, cluster);
                        }
                        else
                        {
                            clustering[i] = clustering[maxOverlapBb];
                        }
                    }
                    else
                    {
                        if (clustering[maxOverlapBb] == -1)
                        {
                            clustering[maxOverlapBb] = clustering[i];
                        }
                        else
                        {
                            // merge clusters
                            int cluster = clustering[i];
                            int deadCluster = clustering[maxOverlapBb];
                            for (int k = 0; k < clustering.Length; k++)
                            {
                                if (clustering[k] == deadCluster)
                                {
                                    clustering[k] = cluster;
                                }
                            }
                            clusters.Remove(deadCluster);
                            deadClusters.Add(deadCluster);
                        }
                    }
                }

                // if maximal overlap is not big enough
                else
                {
                    if (clustering[i] == -1)
                    {
                        int cluster;
                        if (deadClusters.Count == 0)
                        {
                            cluster = clusters.Count;
                        }
                        else
                        {
                            cluster = deadClusters.Min();
                            deadClusters.Remove(cluster);
                        }
                        clustering[i] = cluster;
                        clusters.Add(cluster, cluster);
                    }
                }
            }

            #endregion

            #region turn clustered bounding boxes into single bounding boxes

            List<IBoundingBox> singleBoundingBoxes = new List<IBoundingBox>();
            foreach (KeyValuePair<int, int> pair in clusters)
            {
                // extract cluster
                int i = pair.Value;
                List<IBoundingBox> cluster = new List<IBoundingBox>();
                for (int j = 0; j < clustering.Length; j++)
                {
                    if (clustering[j] == i)
                    {
                        cluster.Add(boundingBoxes[j]);
                    }
                }

                // average bounding boxes in the cluster
                float centerX = 0;
                float centerY = 0;
                float sizeWidth = 0;
                float sizeHeight = 0;
                int clusterCount = cluster.Count;
                for (int k = 0; k < clusterCount; k++)
                {
                    centerX += cluster[k].Center.X;
                    centerY += cluster[k].Center.Y;
                    sizeWidth += cluster[k].Size.Width;
                    sizeHeight += cluster[k].Size.Height;
                }
                PointF center = new PointF(centerX / clusterCount, centerY / clusterCount);
                SizeF size = new SizeF(sizeWidth / clusterCount, sizeHeight / clusterCount);

                singleBoundingBoxes.Add(cluster[0].CreateInstance(center, size));
            }

            #endregion

            return singleBoundingBoxes;
        }

        public static List<IBoundingBox> GenerateSimilarBoundingBoxes(Size frameSize, IBoundingBox refBb, SimilarBoundingBoxGenerationInfo info)
        {
            List<IBoundingBox> boundingBoxes = new List<IBoundingBox>();
            for (int i = 0; i < info.Count; i++)
            {
                // calculate new center
                PointF newCenter;
                if (info.MaxShift != 0)
                {
                    float relShift = (float)(_rand.NextDouble() * 2 - 1) * info.MaxShift;
                    PointF absShift = new PointF(relShift * refBb.Size.Width, relShift * refBb.Size.Height);
                    newCenter = refBb.Center.Add(absShift);
                }
                else
                {
                    newCenter = refBb.Center;
                }

                // calculate new size
                SizeF newSize;
                if (info.MaxScale != 0)
                {
                    float scale = 1.0f + (float)(_rand.NextDouble() * 2 - 1) * info.MaxScale;
                    newSize = refBb.Size.Multiply(scale, scale);
                }
                else
                {
                    newSize = refBb.Size;
                }

                // create new bounding box
                IBoundingBox newBb = refBb.CreateInstance(newCenter, newSize);

                // if bounding box is inside the frame, add it to collection
                if (newBb.InsideFrame(frameSize))
                {
                    boundingBoxes.Add(newBb);
                }
            }

            return boundingBoxes;
        }
    
        /// <summary>
        /// Concatenates training examples into array and permutes them and their labels.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="positiveExamples"></param>
        /// <param name="negativeExamples"></param>
        /// <param name="examplesArray"></param>
        /// <param name="labelsArray"></param>
        public static void PermuteTrainingExamples<T>(List<T> positiveExamples, List<T> negativeExamples, out T[] examplesArray, out bool[] labelsArray)
        {
            // concatenate examples and assign them labels
            ConcatenateTrainingExamples<T>(positiveExamples, negativeExamples, out examplesArray, out labelsArray);

            // permute training examples and their labels
            PermuteTrainingExamples<T>(examplesArray, labelsArray);
        }

        /// <summary>
        /// Permutes training examples and their labels.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="examplesArray"></param>
        /// <param name="labelsArray"></param>
        public static void PermuteTrainingExamples<T>(T[] examplesArray, bool[] labelsArray)
        {
            int examplesCount = examplesArray.Length;
            for (int i = 0; i < examplesCount; i++)
            {
                int other = _rand.Next(examplesCount);

                // switch examples
                T tempExample = examplesArray[i];
                examplesArray[i] = examplesArray[other];
                examplesArray[other] = tempExample;

                // switch labels
                bool tempLabel = labelsArray[i];
                labelsArray[i] = labelsArray[other];
                labelsArray[other] = tempLabel;
            }
        }

        /// <summary>
        /// Concatenates two lists and assigns them labels.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="positiveExamples"></param>
        /// <param name="negativeExamples"></param>
        /// <param name="examplesArray"></param>
        /// <param name="labelsArray"></param>
        public static void ConcatenateTrainingExamples<T>(List<T> positiveExamples, List<T> negativeExamples, out T[] examplesArray, out bool[] labelsArray)
        {
            int p = positiveExamples.Count;
            int n = negativeExamples.Count;
            int sum = p + n;
            examplesArray = new T[sum];
            labelsArray = new bool[sum];
            for (int i = 0; i < p; i++)
            {
                examplesArray[i] = positiveExamples[i];
                labelsArray[i] = true;
            }
            for (int i = 0; i < n; i++)
            {
                int index = i + p;
                examplesArray[index] = negativeExamples[i];
                labelsArray[index] = false;
            }
        }
    }
}
