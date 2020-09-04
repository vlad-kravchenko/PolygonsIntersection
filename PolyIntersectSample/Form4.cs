﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PolyIntersectSample
{
    public partial class Form4 : Form
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

        RectangleF RectangleF = RectangleF.Empty;
        PointF CenterPoint = PointF.Empty;

        public bool Inval { get; private set; }

        public Form4()
        {
            InitializeComponent();

            Path.AddLine(new PointF(33, 294), new PointF(50, 420));
            Path.AddLine(new PointF(50, 420), new PointF(400, 400));
            Path.AddLine(new PointF(400, 400), new PointF(280, 210));
            Path.AddLine(new PointF(280, 210), new PointF(400, 150));
            Path.AddLine(new PointF(400, 150), new PointF(330, 60));
            Path.AddLine(new PointF(330, 60), new PointF(200, 30));
            Path.AddLine(new PointF(200, 30), new PointF(60, 80));
            Path.AddLine(new PointF(60, 80), new PointF(80, 250));
            Path.AddLine(new PointF(80, 250), new PointF(33, 294));

            FindRectangle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawPath(new Pen(Color.Red), Path);
            e.Graphics.DrawRectangle(new Pen(Color.Red), Rectangle.Ceiling(RectangleF));
            e.Graphics.FillEllipse(Brushes.Red, CenterPoint.X - 10, CenterPoint.Y - 10, 20, 20);
        }

        private void btnInvalidate_Click(object sender, EventArgs e)
        {
            //Inval = true;
            FindRectangle();
            Invalidate();

            textBox1.Text = "";
            textBox1.Text += CenterPoint + Environment.NewLine;
            textBox1.Text += RectangleF + Environment.NewLine + Environment.NewLine;
            textBox1.Text += GetArea(Points) + Environment.NewLine;

            foreach (var point in Points)
            {
                textBox1.Text += point + Environment.NewLine;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnInvalidate_Click(this, null);
        }

        private void FindRectangle()
        {
            Random rand = new Random();
            List<PointF> innerPoints = new List<PointF>();
            var elementPoints = Path.PathPoints.ToList();

            for (int i = 0; i < 100; i++)
            {
                int minX = 0, maxX = 0, minY = 0, maxY = 0;
                minX = (int)elementPoints.Min(p => p.X);
                maxX = (int)elementPoints.Max(p => p.X);
                minY = (int)elementPoints.Min(p => p.Y);
                maxY = (int)elementPoints.Max(p => p.Y);
                int X = rand.Next(minX, maxX);
                int Y = rand.Next(minY, maxY);

                if (IsPointInPolygon(elementPoints.ToArray(), new Point(X, Y)))
                {
                    innerPoints.Add(new PointF(X, Y));
                }
            }

            var firstPoint = innerPoints.First();
            List<PointF> rectPoints = new List<PointF>
            {
                new PointF(firstPoint.X - 1, firstPoint.Y - 1),
                new PointF(firstPoint.X + 1, firstPoint.Y - 1),
                new PointF(firstPoint.X + 1, firstPoint.Y + 1),
                new PointF(firstPoint.X - 1, firstPoint.Y + 1)
            };

            List<PointF> currentRect = rectPoints;
            float area = GetArea(rectPoints);
            PointF centerPoint = firstPoint;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            List<Result> results = new List<Result>();

            foreach (var point in innerPoints)
            {
                rectPoints.Clear();
                rectPoints.AddRange(new[]
                {
                    new PointF(point.X - 1, point.Y - 1),
                    new PointF(point.X + 1, point.Y - 1),
                    new PointF(point.X + 1, point.Y + 1),
                    new PointF(point.X - 1, point.Y + 1)
                });

                //0 and 1 - up
                while (!IsIntersect(elementPoints.ToList(), rectPoints))
                {
                    rectPoints[0] = new PointF(rectPoints[0].X, rectPoints[0].Y - 1);
                    rectPoints[1] = new PointF(rectPoints[1].X, rectPoints[1].Y - 1);
                    UpdateWindow(rectPoints, point);
                }
                rectPoints[0] = new PointF(rectPoints[0].X, rectPoints[0].Y + 1);
                rectPoints[1] = new PointF(rectPoints[1].X, rectPoints[1].Y + 1);
                //0 and 3 - left
                while (!IsIntersect(elementPoints.ToList(), rectPoints))
                {
                    rectPoints[0] = new PointF(rectPoints[0].X - 1, rectPoints[0].Y);
                    rectPoints[3] = new PointF(rectPoints[3].X - 1, rectPoints[3].Y);
                    UpdateWindow(rectPoints, point);
                }
                rectPoints[0] = new PointF(rectPoints[0].X + 1, rectPoints[0].Y);
                rectPoints[3] = new PointF(rectPoints[3].X + 1, rectPoints[3].Y);
                //1 and 2 - right
                while (!IsIntersect(elementPoints.ToList(), rectPoints))
                {
                    rectPoints[1] = new PointF(rectPoints[1].X + 1, rectPoints[1].Y);
                    rectPoints[2] = new PointF(rectPoints[2].X + 1, rectPoints[2].Y);
                    UpdateWindow(rectPoints, point);
                }
                rectPoints[1] = new PointF(rectPoints[1].X - 1, rectPoints[1].Y);
                rectPoints[2] = new PointF(rectPoints[2].X - 1, rectPoints[2].Y);
                //2 and 3 - bottom
                while (!IsIntersect(elementPoints.ToList(), rectPoints))
                {
                    rectPoints[2] = new PointF(rectPoints[2].X, rectPoints[2].Y + 1);
                    rectPoints[3] = new PointF(rectPoints[3].X, rectPoints[3].Y + 1);
                    UpdateWindow(rectPoints, point);
                }
                rectPoints[2] = new PointF(rectPoints[2].X, rectPoints[2].Y - 1);
                rectPoints[3] = new PointF(rectPoints[3].X, rectPoints[3].Y - 1);

                textBox2.Text += GetArea(rectPoints) + Environment.NewLine;
                if (GetArea(rectPoints) > area && GetCompact(rectPoints) < 5)
                {
                    area = GetArea(rectPoints);
                    currentRect = rectPoints;
                    centerPoint = point;
                    Points = rectPoints;

                    results.Add(new Result
                    {
                        Area = area,
                        Rectangle = BuildRectangle(currentRect)
                    });

                    textBox3.Text += BuildRectangle(currentRect) + " " + area;
                }
            }

            RectangleF = BuildRectangle(currentRect);
            CenterPoint = centerPoint;

            foreach (var result in results)
            {
                textBox4.Text += result.Area + " " + result.CenterPointF + " " + result.Rectangle + Environment.NewLine;
            }

            var best = results.FirstOrDefault(r => r.Area == results.Max(res => res.Area));
            RectangleF = best.Rectangle;
            centerPoint = best.CenterPointF;
        }

        private void UpdateWindow(List<PointF> rectPoints, PointF point)
        {
            if (!Inval) return;
            RectangleF = BuildRectangle(rectPoints);
            CenterPoint = point;
            Refresh();
            Thread.Sleep(5);
            textBox1.Text = GetArea(rectPoints).ToString();
        }

        private double GetCompact(List<PointF> rectPoints)
        {
            var rectTest = BuildRectangle(rectPoints);
            double compact = 1;
            if (rectTest.Width > rectTest.Height) compact = rectTest.Width / rectTest.Height;
            else compact = rectTest.Height / rectTest.Width;
            return compact;
        }

        private RectangleF BuildRectangle(List<PointF> points)
        {
            float minX = points.Min(p => p.X);
            float maxX = points.Max(p => p.X);
            float minY = points.Min(p => p.Y);
            float maxY = points.Max(p => p.Y);

            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }

        public bool IsPointInPolygon(PointF[] polygon, Point p)
        {
            PointF p1, p2;
            bool inside = false;
            if (polygon.Length < 3)
            {
                return inside;
            }
            var oldPoint = new PointF(polygon[polygon.Length - 1].X, polygon[polygon.Length - 1].Y);
            for (int i = 0; i < polygon.Length; i++)
            {
                var newPoint = new PointF(polygon[i].X, polygon[i].Y);
                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }
                if ((newPoint.X < p.X) == (p.X <= oldPoint.X) &&
                    (p.Y - (long)p1.Y) * (p2.X - p1.X) < (p2.Y - (long)p1.Y) * (p.X - p1.X))
                {
                    inside = !inside;
                }
                oldPoint = newPoint;
            }
            return inside;
        }

        private float GetArea(List<PointF> rectPoints)
        {
            return (rectPoints.Max(p => p.X) - rectPoints.Min(p => p.X)) *
                   (rectPoints.Max(p => p.Y) - rectPoints.Min(p => p.Y));
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
