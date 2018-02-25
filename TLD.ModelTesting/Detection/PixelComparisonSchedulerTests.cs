using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TLD.Model.Detection;
using System.Collections.Generic;

namespace TLD.ModelTesting.Detection
{
    [TestClass]
    public class PixelComparisonSchedulerTests
    {
        [TestMethod]
        public void SchedulePixelComparisons_Simple()
        {
            // arrange - instantiate scheduler
            PixelComparisonScheduler scheduler = new PixelComparisonScheduler(2, 1, 2, 2);

            // get scheduled comparisons
            PixelComparisonGroupF[] scheduledComparisons = scheduler.ScheduledPixelComparisons;

            // assert - number of base classifiers
            Assert.AreEqual(2, scheduler.BaseClassifierCount);

            // assert - comparisons per classifier
            Assert.AreEqual(1, scheduler.ComparisonsPerClassifier);

            // gather all comparisons in one list
            List<PixelComparisonF> comparisons = new List<PixelComparisonF>();
            for (int i = 0; i < scheduler.BaseClassifierCount; i++)
            {
                for (int j = 0; j < scheduler.ComparisonsPerClassifier; j++)
                {
                    comparisons.Add(scheduledComparisons[i].Value[j]);
                }
            }

            // assert - all comparisons are unique
            CollectionAssert.AllItemsAreUnique(comparisons);
        }

        [TestMethod]
        public void SchedulePixelComparisons_BiggerCase()
        {
            // arrange - instantiate scheduler
            PixelComparisonScheduler scheduler = new PixelComparisonScheduler(5, 10, 10, 10);

            // get scheduled comparisons
            PixelComparisonGroupF[] scheduledComparisons = scheduler.ScheduledPixelComparisons;

            // gather all comparisons in one list
            List<PixelComparisonF> comparisons = new List<PixelComparisonF>();
            for (int i = 0; i < scheduler.BaseClassifierCount; i++)
            {
                for (int j = 0; j < scheduler.ComparisonsPerClassifier; j++)
                {
                    comparisons.Add(scheduledComparisons[i].Value[j]);
                }
            }

            // assert - all comparisons are unique
            CollectionAssert.AllItemsAreUnique(comparisons);
        }

        [TestMethod]
        public void SchedulePixelComparisons_NotEnoughPixelComparisons()
        {
            // arrange - instantiate scheduler
            PixelComparisonScheduler scheduler = new PixelComparisonScheduler(5, 10, 3, 2);

            // assert - every classifier got only 1 comparison
            Assert.AreEqual(1, scheduler.ComparisonsPerClassifier);
        }
    }
}
