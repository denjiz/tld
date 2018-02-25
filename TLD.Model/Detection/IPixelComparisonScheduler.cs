using System;
namespace TLD.Model.Detection
{
    public interface IPixelComparisonScheduler
    {
        void PostInstantiation();
        int BaseClassifierCount { get; set; }
        int ComparisonsPerClassifier { get; }
        int MaxComparisonsPerClassifier { get; set; }
        int PatchWidth { get; }
        int PatchHeight { get; }
        void GeneratePixelComparisons();
        PixelComparisonF[] GetComparisonsForClassifier(int classifier);
        PixelComparisonGroupF[] ScheduledPixelComparisons { get; }
        void SchedulePixelComparisons();
    }
}
