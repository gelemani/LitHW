using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PolygonsLIT.Shapes;

namespace PolygonsLIT
{
    public class AnalitycsCustomControl : UserControl
    {
        private readonly Random _random = new();
        private List<Shape> _polygonShapes = new();

        public override void Render(DrawingContext drawingContext)
        {
            DrawArrow(drawingContext, new Point(15, 502), new Point(15, 50), new SolidColorBrush(Colors.White));
            DrawArrow(drawingContext, new Point(14, 502), new Point(700, 502), new SolidColorBrush(Colors.White));
            GraphContent(drawingContext, Graph());
        }

        private List<Point[]> Graph()
        {
            List<Shape> randomPolygons = new List<Shape>();
            List<int[]> counter = new List<int[]>();
            const int iterations = 10;
            const int figuresCount = 30;

            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < figuresCount; j++)
                {
                    randomPolygons.Add(GenerateRandomShape());
                }

                int timeJarvis = 0;
                int timeByDef = 0;
                
                DateTime dateTime = DateTime.Now;
                GraphJarvis(randomPolygons);
                timeJarvis = (int)(DateTime.Now - dateTime).TotalMilliseconds;
                dateTime = DateTime.Now;
                GraphByDef(randomPolygons);
                timeByDef = (int)(DateTime.Now - dateTime).TotalMilliseconds;
                counter.Add(new int[] { timeJarvis, timeByDef });
            }

            List<Point[]> graphLines = new List<Point[]>();
            int yJarvis = 500;
            int yByDef = 500;
            int x = 20;
            foreach (int[] point in counter)
            {
                graphLines.Add(new Point[] { new Point(x, yJarvis), new Point(x + 40, yJarvis - point[0]) });
                graphLines.Add(new Point[] { new Point(x, yByDef), new Point(x + 40, yByDef - point[1]) });
                yJarvis -= point[0];
                yByDef -= point[1];
                x += 40;
            }

            return graphLines;
        }
        
        private void DrawArrow(DrawingContext drawingContext, Point start, Point end, IBrush brush)
        {
            drawingContext.DrawLine(new Pen(brush, 3), start, end);

            double arrowLength = 10;
            double arrowAngle = Math.PI / 6;

            Vector direction = (end - start);
            direction = direction.Normalize();
            Vector perpendicular = new Vector(-direction.Y, direction.X);

            Point arrowPoint1 = end - direction * arrowLength + perpendicular * arrowLength * Math.Tan(arrowAngle);
            Point arrowPoint2 = end - direction * arrowLength - perpendicular * arrowLength * Math.Tan(arrowAngle);

            var arrowGeometry = new StreamGeometry();
            using (var ctx = arrowGeometry.Open())
            {
                ctx.BeginFigure(end, true);
                ctx.LineTo(arrowPoint1);
                ctx.LineTo(arrowPoint2);
                ctx.EndFigure(true);
            }

            drawingContext.DrawGeometry(brush, null, arrowGeometry);
        }

        private Shape GenerateRandomShape()
        {
            int maxX = 800, maxY = 600;
            int x = _random.Next(0, maxX);
            int y = _random.Next(0, maxY);
            int shapeType = _random.Next(0, 3);
            return shapeType switch
            {
                0 => new Circle(x, y, Shape.Radius),
                1 => new Square(x, y),
                _ => new Triangle(x, y),
            };
        }

        private void GraphContent(DrawingContext drawingContext, List<Point[]> graphLines)
        {
            int index = 0;
            foreach (Point[] line in graphLines)
            {
                if (index % 2 == 0)
                {
                    drawingContext.DrawLine(new Pen(Brushes.Orange, 3, lineCap: PenLineCap.Square),
                        new Point(line[0].X, line[0].Y), new Point(line[1].X, line[1].Y));
                }
                else
                {
                    drawingContext.DrawLine(new Pen(Brushes.Green, 3, lineCap: PenLineCap.Square),
                        new Point(line[0].X, line[0].Y), new Point(line[1].X, line[1].Y));
                }

                index++;
            }
        }

        private void GraphByDef(List<Shape> randomPolygons)
        {
            if (randomPolygons.Count < 3)
                return;

            for (int i = 0; i < randomPolygons.Count - 1; i++)
            {
                for (int j = i + 1; j < randomPolygons.Count; j++)
                {
                    Shape firstPoint = randomPolygons[i];
                    Shape secondPoint = randomPolygons[j];
                    bool allAbove = true;
                    bool allBelow = true;

                    if (firstPoint.X == secondPoint.X)
                    {
                        for (int a = 0; a < randomPolygons.Count; a++)
                        {
                            if (a == i || a == j)
                                continue;
                            Shape point = randomPolygons[a];
                            if (firstPoint.X > point.X)
                                allBelow = false;
                            else if (firstPoint.X < point.X)
                                allAbove = false;
                            else
                            {
                                allAbove = false;
                                allBelow = false;
                            }
                        }
                    }
                    else if (firstPoint.Y == secondPoint.Y)
                    {
                        for (int a = 0; a < randomPolygons.Count; a++)
                        {
                            if (a == i || a == j)
                                continue;
                            Shape point = randomPolygons[a];
                            if (firstPoint.Y > point.Y)
                                allBelow = false;
                            else if (firstPoint.Y < point.Y)
                                allAbove = false;
                            else
                            {
                                allAbove = false;
                                allBelow = false;
                            }
                        }
                    }
                    else
                    {
                        double k = (double)(secondPoint.Y - firstPoint.Y) / (secondPoint.X - firstPoint.X);
                        double b = firstPoint.Y - k * firstPoint.X;
                        for (int a = 0; a < randomPolygons.Count; a++)
                        {
                            if (a == i || a == j)
                                continue;
                            Shape point = randomPolygons[a];
                            double yLine = k * point.X + b;
                            if (yLine > point.Y)
                                allBelow = false;
                            else if (yLine < point.Y)
                                allAbove = false;
                            else
                            {
                                allAbove = false;
                                allBelow = false;
                            }
                        }
                    }

                    if (allAbove || allBelow)
                    {
                        randomPolygons[i].IsVertex = true;
                        randomPolygons[j].IsVertex = true;
                    }
                }
            }
        }

        private void GraphJarvis(List<Shape> randomPolygons)
        {
            if (randomPolygons.Count < 3)
                return;

            int leftestIndex = 0;
            for (int i = 1; i < randomPolygons.Count; i++)
            {
                if (randomPolygons[i].X < randomPolygons[leftestIndex].X)
                    leftestIndex = i;
            }

            List<Shape> hullShapes = new List<Shape>();
            int currentIndex = leftestIndex;
            do
            {
                hullShapes.Add(randomPolygons[currentIndex]);
                int nextIndex = (currentIndex + 1) % randomPolygons.Count;
                for (int i = 0; i < randomPolygons.Count; i++)
                {
                    if (i == currentIndex)
                        continue;
                    double cross = CrossProduct(randomPolygons[currentIndex], randomPolygons[nextIndex], randomPolygons[i]);
                    if (cross > 0)
                        nextIndex = i;
                    else if (cross == 0)
                    {
                        if (DistanceSquared(randomPolygons[currentIndex], randomPolygons[i]) >
                            DistanceSquared(randomPolygons[currentIndex], randomPolygons[nextIndex]))
                        {
                            nextIndex = i;
                        }
                    }
                }
                currentIndex = nextIndex;
            } while (currentIndex != leftestIndex);

            foreach (var shape in hullShapes)
            {
                shape.IsVertex = true;
            }
        }

        private double CrossProduct(Shape p, Shape q, Shape r)
        {
            return (q.X - p.X) * (r.Y - p.Y) - (q.Y - p.Y) * (r.X - p.X);
        }

        private double DistanceSquared(Shape a, Shape b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            return dx * dx + dy * dy;
        }
    }
}