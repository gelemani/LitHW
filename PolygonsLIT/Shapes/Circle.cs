using System;
using Avalonia;
using Avalonia.Media;

namespace PolygonsLIT.Shapes
{
    sealed class Circle : Shape
    {
        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }
        public override void Draw(DrawingContext drawingContext)
        {
            Pen pen = new Pen(Brushes.Purple, 5);   
            Brush brush = new SolidColorBrush(Colors.White);

            drawingContext.DrawEllipse(brush, pen, new Point(X, Y), Radius, Radius);
            Console.WriteLine("Drawing a circle!");
        }

        public override bool IsInside(int dx, int dy)
        {
            if (Math.Pow(X - dx, 2) + Math.Pow(Y - dy, 2) <= Math.Pow(Radius, 2))
            {
                return true;
            }
            return false;
        }
    }
}