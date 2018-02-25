using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TLD.Model
{
    public class Shift
    {
        public PointF Previous { get; set; }
        public PointF Forward { get; set; }
        public PointF Backward { get; set; }

        public float FBError { get; set; }
        public float NCC { get; set; }

        public float Horizontal { get { return Forward.X - Previous.X; } }
        public float Vertical { get { return Forward.Y - Previous.Y; } }

        public Shift(
            PointF previousPoint,
            PointF forwardPoint,
            PointF backwardPoint
        )
        {
            Previous = previousPoint;
            Forward = forwardPoint;
            Backward = backwardPoint;
        }
    }
}
