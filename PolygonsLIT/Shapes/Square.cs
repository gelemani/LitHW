using System;
using Avalonia;
using Avalonia.Media;

namespace PolygonsLIT.Shapes;

public class Square : Shape
{
    public Square(int x, int y) : base(x, y)
    {
    }

    public override void Draw(DrawingContext drawingContext)
    {
        Pen pen = new Pen(Brushes.Purple, 5);
        Brush brush = new SolidColorBrush(Colors.FloralWhite);
        
        double delta = Radius * Math.Sqrt(2) / 2;
        drawingContext.DrawRectangle(brush, pen, new Rect(new Point(X - delta, Y - delta), new Size(2*delta, 2*delta)));
        // Console.WriteLine("Drawing a square!");
    }

    public override bool IsInside(int dx, int dy)
    {
        double diff = Radius * Math.Sqrt(2) / 2;
        if ((Math.Abs(X - dx) <= diff) & (Math.Abs(Y - dy) <= diff)){
            return true;
        }
        return false;
    }

}