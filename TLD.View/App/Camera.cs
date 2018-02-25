using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLD.View
{
    class Camera
    {
        public Camera()
        {

        }

        public void OpenAll()
        {
            Captures = new List<Capture>();
            while (true)
            {
                try
                {
                    Captures.Add(new Capture(Captures.Count));
                }
                catch (NullReferenceException)
                {
                    break;
                }
            }
        }

        public List<Capture> Captures { get; private set; }
    }
}
