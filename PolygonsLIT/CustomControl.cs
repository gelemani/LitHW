using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Automation.Peers;
using Avalonia.Controls;
using Avalonia.Media;
using PolygonsLIT.Shapes;

namespace PolygonsLIT
{
    public class CustomControl : UserControl
    {
        private List<Shape> _shapes = new();
        List<Avalonia.Point> _borders = new();
        private int _cx, _cy;

        public int SelectedShapeIndex { get; set; } = 0;
        public int SelectedAlgorithmIndex { get; set; } = 0;
        private AnalitycsWindow? _analitycsWindow;
        private int _dy;
        public DrawingContext DC { get; set; }
        public Func<List<Avalonia.Point>> AlgDef { get; set; }
        public Func<List<Avalonia.Point>> AlgJar { get; set; }
        public int SelectedFileControlIndex { get; set; }

        public override void Render(DrawingContext drawingContext)
        {
            DC = drawingContext;
            AlgDef = CalculateByDefinition;
            AlgJar = CalculateJarvice;

            foreach (Shape shape in _shapes)
            {
                shape.Draw(drawingContext);
            }

            if (_shapes.Count < 3)
                return;

            switch (SelectedAlgorithmIndex)
            {
                case 0:
                    DrawConvexHull(drawingContext, CalculateByDefinition);
                    break;
                case 1:
                    DrawConvexHull(drawingContext, CalculateJarvice);
                    break;
                default:
                    DrawConvexHull(drawingContext, CalculateByDefinition);
                    Console.WriteLine("Using By Definition (default)");
                    break;
            }
        }

        public void DrawConvexHull(DrawingContext drawingContext, Func<List<Avalonia.Point>> calculateHull)
        {
            _borders = calculateHull();
            var hullPen = new Pen(Brushes.DimGray, 2, lineCap: PenLineCap.Square);

            for (int i = 0; i < _borders.Count; i += 2)
            {
                drawingContext.DrawLine(hullPen, _borders[i], _borders[i + 1]);
            }
        }

        public void OpenAnalitycsWindow()
        {
            if (_analitycsWindow == null)
            {
                _analitycsWindow = new AnalitycsWindow();
                _analitycsWindow.Closed += (sender, e) => _analitycsWindow = null;
                _analitycsWindow.Show();
            }
            else
            {
                _analitycsWindow.Activate();
            }
        }

        public List<Avalonia.Point> CalculateByDefinition()
        {
            List<Avalonia.Point> borders = new();
            if (_shapes.Count < 3)
                return borders;

            for (int i = 0; i < _shapes.Count - 1; i++)
            {
                for (int j = i + 1; j < _shapes.Count; j++)
                {
                    Shape firstPoint = _shapes[i];
                    Shape secondPoint = _shapes[j];
                    bool allAbove = true;
                    bool allBelow = true;

                    if (firstPoint.X == secondPoint.X)
                    {
                        for (int a = 0; a < _shapes.Count; a++)
                        {
                            if (a == i || a == j)
                                continue;
                            Shape point = _shapes[a];
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

                    if (firstPoint.Y == secondPoint.Y)
                    {
                        for (int a = 0; a < _shapes.Count; a++)
                        {
                            if (a == i || a == j)
                                continue;
                            Shape point = _shapes[a];
                            if (firstPoint.Y > point.Y)
                                allBelow = false;
                            if (firstPoint.Y < point.Y)
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
                        double k = ((double)secondPoint.Y - firstPoint.Y) / ((double)secondPoint.X - firstPoint.X);
                        double b = firstPoint.Y - k * firstPoint.X;
                        for (int a = 0; a < _shapes.Count; a++)
                        {
                            if (a == i || a == j)
                                continue;
                            Shape point = _shapes[a];
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
                        borders.Add(new Avalonia.Point(firstPoint.X, firstPoint.Y));
                        borders.Add(new Avalonia.Point(secondPoint.X, secondPoint.Y));
                    }
                }
            }

            Console.WriteLine("Using By Definition");
            return borders;
        }

        private List<Avalonia.Point> CalculateJarvice()
        {
            List<Avalonia.Point> borders = new();
            if (_shapes.Count < 3)
                return borders;

            int leftestIndex = 0;
            for (int i = 1; i < _shapes.Count; i++)
            {
                if (_shapes[i].X < _shapes[leftestIndex].X)
                    leftestIndex = i;
            }

            List<Avalonia.Point> hullPoints = new List<Avalonia.Point>();
            int currentIndex = leftestIndex;
            do
            {
                hullPoints.Add(new Avalonia.Point(_shapes[currentIndex].X, _shapes[currentIndex].Y));
                int nextIndex = (currentIndex + 1) % _shapes.Count;
                for (int i = 0; i < _shapes.Count; i++)
                {
                    if (i == currentIndex)
                        continue;
                    double cross = CrossProduct(_shapes[currentIndex], _shapes[nextIndex], _shapes[i]);
                    if (cross > 0)
                        nextIndex = i;
                    else if (cross == 0)
                    {
                        if (DistanceSquared(_shapes[currentIndex], _shapes[i]) >
                            DistanceSquared(_shapes[currentIndex], _shapes[nextIndex]))
                        {
                            nextIndex = i;
                        }
                    }
                }

                currentIndex = nextIndex;
            } while (currentIndex != leftestIndex);

            for (int i = 0; i < hullPoints.Count; i++)
            {
                Point p1 = hullPoints[i];
                Point p2 = hullPoints[(i + 1) % hullPoints.Count];
                borders.Add(p1);
                borders.Add(p2);
            }

            Console.WriteLine("Using Jarvice");
            return borders;
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

        public void UpdateRadius(object? sender, Delegates.RadiusEventArgs e)
        {
            Shape.Radius = e.R;
            InvalidateVisual();
        }

        public void UpdateColor(object? sender, Delegates.ColorEventArgs e)
        {
            Brush newBrush = new SolidColorBrush((Color)e.Color);
            Shape.Brush = newBrush;
            Shape.Pen = new Pen(newBrush, 3);
            InvalidateVisual();
        }

        public void RightClick(int x, int y)
        {
            _cx = x;
            _cy = y;
            var counter = 0;
            foreach (Shape shape in _shapes)
            {
                if (shape.IsInside(_cx, _cy))
                {
                    shape.IsMoving = true;
                    shape.DX = _cx - shape.X;
                    shape.DY = _cy - shape.Y;
                    counter++;
                }
            }

            if (counter == 0)
            {
                switch (SelectedShapeIndex)
                {
                    case 0:
                        _shapes.Add(new Circle(_cx, _cy, Shape.Radius));
                        Console.WriteLine("Drawing a circle!");
                        break;
                    case 1:
                        _shapes.Add(new Square(_cx, _cy));
                        Console.WriteLine("Drawing a square!");
                        break;
                    case 2:
                        _shapes.Add(new Triangle(_cx, _cy));
                        Console.WriteLine("Drawing a triangle!");
                        break;
                    default:
                        _shapes.Add(new Circle(_cx, _cy, Shape.Radius));
                        Console.WriteLine("Drawing a circle!");
                        break;
                }

                InvalidateVisual();
                counter = 0;
            }
        }

        public void LeftClick(int x, int y)
        {
            var deleteIndex = -1;
            foreach (Shape shape in _shapes)
            {
                if (shape.IsInside(x, y))
                {
                    deleteIndex = _shapes.IndexOf(shape);
                    break;
                }
            }

            if (deleteIndex != -1)
            {
                _shapes.RemoveAt(deleteIndex);
            }

            InvalidateVisual();
        }

        public void Drag(int x, int y)
        {
            foreach (Shape shape in _shapes)
            {
                if (shape.IsMoving)
                {
                    shape.X = x - shape.DX;
                    shape.Y = y - shape.DY;
                    InvalidateVisual();
                }
            }
        }

        public void Drop()
        {
            HashSet<Point> points = _borders.ToHashSet();
            List<Shape> newShapes = new();
            if (_shapes.Count > 3)
            {
                foreach (Shape shape in _shapes)
                {
                    shape.IsMoving = false;
                    if (points.Contains(new Point(shape.X, shape.Y)))
                    {
                        newShapes.Add(shape);
                    }
                }

                _shapes = newShapes;
            }

            InvalidateVisual();
        }

        public void CheckRayIntersections()
        {
            if (_borders == null || _borders.Count < 2)
                return;

            int width = (int)Bounds.Width;
            int height = (int)Bounds.Height;

            for (int y = 0; y < height; y += 10) // step by 10 for performance
            {
                for (int x = 0; x < width; x += 10)
                {
                    int intersections = 0;
                    for (int i = 0; i < _borders.Count; i += 2)
                    {
                        var p1 = _borders[i];
                        var p2 = _borders[i + 1];

                        if (IsIntersectingHorizontalRay(x, y, p1, p2))
                            intersections++;
                    }

                    if (intersections % 2 != 0)
                    {
                        InvalidateVisual();
                    }
                }
            }
        }

        private bool IsIntersectingHorizontalRay(double x, double y, Point p1, Point p2)
        {
            if (p1.Y > p2.Y)
            {
                var temp = p1;
                p1 = p2;
                p2 = temp;
            }

            if (y == p1.Y || y == p2.Y)
                y += 0.0001; // perturb a bit to avoid ambiguity

            if (y < p1.Y || y > p2.Y)
                return false;

            if (p1.X > p2.X)
                (p1, p2) = (p2, p1);

            double xIntersection = p1.X + (y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y);

            return xIntersection > x;
        }


        public void MoveHull(int newX, int newY)
        {
            if (_borders == null || _borders.Count == 0)
                return;

            double centerX = 0;
            double centerY = 0;

            foreach (var point in _borders)
            {
                centerX += point.X;
                centerY += point.Y;
            }

            centerX /= _borders.Count;
            centerY /= _borders.Count;

            double dx = newX - centerX;
            double dy = newY - centerY;

            for (int i = 0; i < _borders.Count; i++)
            {
                var p = _borders[i];
                _borders[i] = new Point(p.X + dx, p.Y + dy);
            }

            InvalidateVisual();
        }
    }
}