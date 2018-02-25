using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TLD.View.App
{
    class GroundTruthMode
    {
        public static Rectangle Rectangle { get; set; }
        public static Rectangle DragStartRectangle { get; set; }

        public static bool Active { get; set; }

        public static bool DrawRectangle { get; set; }

        public static bool Dragging { get; private set; }

        public static Point DragStartCursor { get; set; }

        internal static bool CursorInsideGroundTruth(Point cursor)
        {
            Rectangle r = Rectangle;
            Point e = cursor;
            return e.X > r.X && e.X <= r.X + r.Width && e.Y > r.Y && e.Y <= r.Y + r.Height;
        }

        internal static void DragRectangle(Point cursor)
        {
            Point shift = new Point(cursor.X - DragStartCursor.X, cursor.Y - DragStartCursor.Y);
            Rectangle = new Rectangle
            (
                new Point(DragStartRectangle.X + shift.X, DragStartRectangle.Y + shift.Y),
                DragStartRectangle.Size
            );
        }

        internal static void StartDragging(Point cursor)
        {
            Dragging = true;
            DragStartRectangle = Rectangle;
            DragStartCursor = cursor;
        }

        internal static void StopDragging()
        {
            Dragging = false;
        }

        public static int VerticalTransStep { get; set; }

        public static int HorizontalTransStep { get; set; }
    }
}
