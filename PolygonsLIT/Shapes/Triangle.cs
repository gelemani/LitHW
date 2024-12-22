using System;
using Avalonia;
using Avalonia.Media;

namespace PolygonsLIT.Shapes;

public class Triangle : Shape
{
    public Triangle(int x, int y) : base(x, y) { }
    public override void Draw(DrawingContext drawingContext)
    {
        Pen pen = new Pen(Brushes.Purple, 5);
        Brush brush = new SolidColorBrush(Colors.FloralWhite);

        var point1 = new Point(this.X, this.Y - 50);
        var point2 = new Point(this.X - 50, this.Y + 50);
        var point3 = new Point(this.X + 50, this.Y + 50);

        var geometry = new StreamGeometry();
        using (var context = geometry.Open())
        {
            context.BeginFigure(point1, true); 
            context.LineTo(point2);  
            context.LineTo(point3);  
            context.EndFigure(true);  
        }

        drawingContext.DrawGeometry(brush, pen, geometry);
        Console.WriteLine("Drawing a triangle!");
    }
}