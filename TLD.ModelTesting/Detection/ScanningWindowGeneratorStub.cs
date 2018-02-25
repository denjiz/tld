using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TLD.Model;

namespace TLD.ModelTesting.Detection
{
    class ScanningWindowGeneratorStub : IScanningWindowGenerator
    {
        public ScanningWindowGeneratorStub() { }

        public ScanningWindowGeneratorStub(IBoundingBox[] scanningWindows)
        {
            ScanningWindows = scanningWindows;
        }

        public IBoundingBox[] Generate(System.Drawing.Size frameSize, IBoundingBox initialBb)
        {
            throw new NotImplementedException();
        }

        public IBoundingBox[] ScanningWindows { get; set; }

        public float ScaleStep
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float HorizontalRelativeStep
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float VerticalRelativeStep
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int MinimumWindowSize
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
