using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PolyIntersectSample
{
    public partial class Form3 : Form
    {
        public struct Line
        {
            public PointF Point1 { get; set; }
            public PointF Point2 { get; set; }
        }

        private GraphicsPath Path = new GraphicsPath();
        private List<PointF> Points = new List<PointF>
        {
            new PointF(99,99),
            new PointF(101,99),
            new PointF(101,101),
            new PointF(99,101)
        };

        public Form3()
        {
            InitializeComponent();

            p1X.Value = 99;
            p1Y.Value = 99;
            p2X.Value = 101;
            p2Y.Value = 99;
            p3X.Value = 101;
            p3Y.Value = 101;
            p4X.Value = 99;
            p4Y.Value = 101;

            Path.AddLine(new PointF(33, 294), new PointF(50, 420));
            Path.AddLine(new PointF(50, 420), new PointF(400, 400));
            Path.AddLine(new PointF(400, 400), new PointF(280, 210));
            Path.AddLine(new PointF(280, 210), new PointF(400, 150));
            Path.AddLine(new PointF(400, 150), new PointF(330, 60));
            Path.AddLine(new PointF(330, 60), new PointF(200, 30));
            Path.AddLine(new PointF(200, 30), new PointF(60, 80));
            Path.AddLine(new PointF(60, 80), new PointF(80, 250));
            Path.AddLine(new PointF(80, 250), new PointF(33, 294));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawPath(new Pen(Color.Red), Path);

            e.Graphics.DrawLine(new Pen(Color.Red), new PointF(p1X.Value, p1Y.Value), new PointF(p2X.Value, p2Y.Value));
            e.Graphics.DrawLine(new Pen(Color.Red), new PointF(p2X.Value, p2Y.Value), new PointF(p3X.Value, p3Y.Value));
            e.Graphics.DrawLine(new Pen(Color.Red), new PointF(p3X.Value, p3Y.Value), new PointF(p4X.Value, p4Y.Value));
            e.Graphics.DrawLine(new Pen(Color.Red), new PointF(p4X.Value, p4Y.Value), new PointF(p1X.Value, p1Y.Value));
        }

        private void left_Scroll(object sender, EventArgs e)
        {
            Points[0] = new PointF(p1X.Value, p1Y.Value);
            Points[1] = new PointF(p2X.Value, p2Y.Value);
            Points[2] = new PointF(p3X.Value, p3Y.Value);
            Points[3] = new PointF(p4X.Value, p4Y.Value);

            Debug.WriteLine(IsIntersect(Path.PathPoints.ToList(), Points));

            Invalidate();
        }

        private bool IsIntersect(List<PointF> polygon1, List<PointF> polygon2)
        {
            List<Line> lines1 = new List<Line>();
            List<Line> lines2 = new List<Line>();
            for (int i = 0; i < polygon1.Count - 1; i++)
            {
                lines1.Add(new Line { Point1 = polygon1[i], Point2 = polygon1[i + 1] });
            }
            lines1.Add(new Line { Point1 = polygon1[polygon1.Count - 1], Point2 = polygon1[0] });
            for (int i = 0; i < polygon2.Count - 1; i++)
            {
                lines2.Add(new Line { Point1 = polygon2[i], Point2 = polygon2[i + 1] });
            }
            lines2.Add(new Line { Point1 = polygon2[polygon2.Count - 1], Point2 = polygon2[0] });

            foreach (var line1 in lines1)
            {
                foreach (var line2 in lines2)
                {
                    if (LinesIntersect(line1.Point1, line1.Point2, line2.Point1, line2.Point2)) return true;
                }
            }
            return false;
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
