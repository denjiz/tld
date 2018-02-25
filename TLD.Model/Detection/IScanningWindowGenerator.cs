using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TLD.Model
{
    public interface IScanningWindowGenerator
    {
        IBoundingBox[] Generate(Size frameSize, IBoundingBox initialBb);
        IBoundingBox[] ScanningWindows { get; }

        float ScaleStep { get; set; }

        float HorizontalRelativeStep { get; set; }

        float VerticalRelativeStep { get; set; }

        int MinimumWindowSize { get; set; }
    }
}
