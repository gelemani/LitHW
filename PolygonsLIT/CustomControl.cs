using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Media;
using PolygonsLIT.Shapes;

namespace PolygonsLIT
{
    public class CustomControl : UserControl
    {
        private static Random _random = new();
        private List<Shape> _shapes = new();
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

            List<Avalonia.Point> borders = new ();
            var hullPen = new Pen(Brushes.Green, 2, lineCap: PenLineCap.Square);

            for (int i = 0; i < _shapes.Count - 1; i++)
            {
                for (int j = i + 1; j < _shapes.Count; j++)
                {
                    Shape firstPoint = _shapes[i];
                    Shape secondPoint = _shapes[j];

                    bool allAbove = true;
                    bool allBelow = true;
                    
                    // y = kx + b
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
                

                    if (allAbove || allBelow)
                    {
                        borders.Add(new Avalonia.Point(firstPoint.X, firstPoint.Y));
                        borders.Add(new Avalonia.Point(secondPoint.X, secondPoint.Y));
                    }
                }
            }

            for (int i = 0; i < borders.Count; i += 2)
            {   
                drawingContext.DrawLine(hullPen, borders[i], borders[i + 1]);
            }
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
                        InvalidateVisual();
                        counter = 0;
                        break;
                    case 1:
                        _shapes.Add(new Square(_cx, _cy));
                        InvalidateVisual();counter = 0;
                        break;
                    case 2:
                        _shapes.Add(new Triangle(_cx, _cy));
                        InvalidateVisual();
                        counter = 0;
                        break;
                    default:
                        _shapes.Add(new Circle(_cx, _cy, Shape.Radius));
                        InvalidateVisual();
                        counter = 0;
                        break;
                }
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
            foreach (Shape shape in _shapes)
            {
                shape.IsMoving = false;
            }
        }
    }
}
