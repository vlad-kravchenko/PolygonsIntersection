using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PolyIntersectSample
{
    public partial class Form1 : Form
    {
        public struct Line
        {
            public PointF Point1 { get; set; }
            public PointF Point2 { get; set; }
        }

        private Line line1, line2;

        public Form1()
        {
            InitializeComponent();

            line1 = new Line { Point1 = new PointF(10, 10), Point2 = new PointF(100, 100) };
            line2 = new Line { Point1 = new PointF(10, 500), Point2 = new PointF(100, 100) };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            e.Graphics.DrawLine(new Pen(Color.Red, 2), line1.Point1, line1.Point2);
            e.Graphics.DrawLine(new Pen(Color.Red, 2), line2.Point1, line2.Point2);

            //Debug.WriteLine(LinesIntersect(line1.Point1, line1.Point2, line2.Point1,line2.Point2));
            label1.Text = LinesIntersect(line1.Point1, line1.Point2, line2.Point1, line2.Point2) ? "Пересекаются" : "Не пересекаются";
        }

        private void line2Y_Scroll(object sender, EventArgs e)
        {
            line1 = new Line { Point1 = new PointF(10, 10), Point2 = new PointF(line1X.Value, line1Y.Value) };
            line2 = new Line { Point1 = new PointF(10, 500), Point2 = new PointF(line2X.Value, line2Y.Value) };

            Invalidate();
        }

        private bool LinesIntersect(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            if (p2.X < p1.X)
            {
                PointF tmp = p1;
                p1 = p2;
                p2 = tmp;
            }
            if (p4.X < p3.X)
            {
                PointF tmp = p3;
                p3 = p4;
                p4 = tmp;
            }
            if (p2.X < p3.X)
            {
                return false;
            }
            if ((p1.X - p2.X == 0) && (p3.X - p4.X == 0))
            {
                if (p1.X == p3.X)
                {
                    if (!((Math.Max(p1.Y, p2.Y) < Math.Min(p3.Y, p4.Y)) ||
                    (Math.Min(p1.Y, p2.Y) > Math.Max(p3.Y, p4.Y))))
                    {
                        return true;
                    }
                }
                return false;
            }
            if (p1.X - p2.X == 0)
            {
                double Xa = p1.X;
                double A2 = (p3.Y - p4.Y) / (p3.X - p4.X);
                double b2 = p3.Y - A2 * p3.X;
                double Ya = A2 * Xa + b2;
                if (p3.X <= Xa && p4.X >= Xa && Math.Min(p1.Y, p2.Y) <= Ya &&
                Math.Max(p1.Y, p2.Y) >= Ya)
                {
                    return true;
                }
                return false;
            }
            if (p3.X - p4.X == 0)
            {
                double Xa1 = p3.X;
                double A11 = (p1.Y - p2.Y) / (p1.X - p2.X);
                double b11 = p1.Y - A11 * p1.X;
                double Ya = A11 * Xa1 + b11;
                if (p1.X <= Xa1 && p2.X >= Xa1 && Math.Min(p3.Y, p4.Y) <= Ya &&
                Math.Max(p3.Y, p4.Y) >= Ya)
                {
                    return true;
                }
                return false;
            }
            double A12 = (p1.Y - p2.Y) / (p1.X - p2.X);
            double A22 = (p3.Y - p4.Y) / (p3.X - p4.X);
            double b12 = p1.Y - A12 * p1.X;
            double b22 = p3.Y - A22 * p3.X;
            if (A12 == A22)
            {
                return false;
            }
            double Xa3 = (b22 - b12) / (A12 - A22);
            if ((Xa3 < Math.Max(p1.X, p3.X)) || (Xa3 > Math.Min(p2.X, p4.X)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
