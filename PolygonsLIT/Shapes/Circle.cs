using System;
using Avalonia;
using Avalonia.Media;

namespace PolygonsLIT.Shapes
{
    sealed class Circle : Shape
    {
        public int Radius { get; } 

        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }
        public override void Draw(DrawingContext drawingContext)
        {
            Pen pen = new Pen(Brushes.Purple, 5);
            Brush brush = new SolidColorBrush(Colors.LightPink);

            drawingContext.DrawEllipse(brush, pen, new Point(this.X, this.Y), Radius, Radius);
            Console.WriteLine("Drawing a circle!");
        }
    }
}