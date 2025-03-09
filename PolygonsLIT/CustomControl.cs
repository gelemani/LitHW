using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using PolygonsLIT.Shapes;

namespace PolygonsLIT
{
    public class CustomControl : UserControl
    {
        private static Random _random = new();
        private List<Shape> _shapes = new();
        List<Avalonia.Point> _borders = new();
        private int _cx, _cy;
        public int SelectedShapeIndex { get; set; } = 0;

        public override void Render(DrawingContext drawingContext)
        {
             foreach (Shape shape in _shapes)
             {
                 shape.Draw(drawingContext);
             }
             if (_shapes.Count < 3)
                 return;

            // ByDefinition(drawingContext);
            Jarvice(drawingContext);

            // SpeedTest();
        }


        protected void ByDefinition(DrawingContext drawingContext)
        {
            _borders.Clear();
            var hullPen = new Pen(Brushes.Green, 2, lineCap: PenLineCap.Square);

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
                        _borders.Add(new Avalonia.Point(firstPoint.X, firstPoint.Y));
                        _borders.Add(new Avalonia.Point(secondPoint.X, secondPoint.Y));
                    }
                }
            }

            for (int i = 0; i < _borders.Count; i += 2)
            {
                drawingContext.DrawLine(hullPen, _borders[i], _borders[i + 1]);
            }
        }

        protected void Jarvice(DrawingContext drawingContext)
        {
            _borders.Clear();
            var hullPen = new Pen(Brushes.Green, 2, lineCap: PenLineCap.Square);

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
                Avalonia.Point p1 = hullPoints[i];
                Avalonia.Point p2 = hullPoints[(i + 1) % hullPoints.Count];
                _borders.Add(p1);
                _borders.Add(p2);
            }

            for (int i = 0; i < _borders.Count; i += 2)
            {
                drawingContext.DrawLine(hullPen, _borders[i], _borders[i + 1]);
            }
        }
        
        protected List<Avalonia.Point> ByDefinition()
        {
            List<Avalonia.Point> borders = new List<Avalonia.Point>();
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
            return borders;
        }

        protected List<Avalonia.Point> Jarvice()
        {
            List<Avalonia.Point> borders = new List<Avalonia.Point>();
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
                Avalonia.Point p1 = hullPoints[i];
                Avalonia.Point p2 = hullPoints[(i + 1) % hullPoints.Count];
                borders.Add(p1);
                borders.Add(p2);
            }
            return borders;
        }
        

        public void SpeedTest()
        {
            _shapes = CreateRandomShapes(150);

            Stopwatch stopwatchDef = new Stopwatch();
            stopwatchDef.Start();
            var bordersDef = ByDefinition();
            stopwatchDef.Stop();
            Console.WriteLine("ByDefinition execution time: " + stopwatchDef.Elapsed.TotalMilliseconds + " ms");

            Stopwatch stopwatchJar = new Stopwatch();
            stopwatchJar.Start();
            var bordersJar = Jarvice();
            stopwatchJar.Stop();
            Console.WriteLine("Jarvice execution time: " + stopwatchJar.Elapsed.TotalMilliseconds + " ms");

            Console.WriteLine("ByDefinition border segments count: " + (bordersDef.Count / 2));
            Console.WriteLine("Jarvice border segments count: " + (bordersJar.Count / 2));
        }

        private List<Shape> CreateRandomShapes(int count)
        {
            List<Shape> shapes = [];
            int maxX = 800;
            int maxY = 600;
            for (int i = 0; i < count; i++)
            {
                int x = _random.Next(0, maxX);
                int y = _random.Next(0, maxY);
                int shapeType = _random.Next(0, 3);
                switch (shapeType)
                {
                    case 0:
                        shapes.Add(new Circle(x, y, Shape.Radius));
                        break;
                    case 1:
                        shapes.Add(new Square(x, y));
                        break;
                    case 2:
                        shapes.Add(new Triangle(x, y));
                        break;
                }
            }
            return shapes;
        }
        

        // Вычисление кросс-произведения векторов (p -> q) и (p -> r).
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
            int deleteIndex = -1;
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
    }
}