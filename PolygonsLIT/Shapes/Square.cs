using System;
using Avalonia;
using Avalonia.Media;

namespace PolygonsLIT.Shapes;

public class Square : Shape
{
    public int Size { get; }
    public Square(int x, int y, int size) : base(x, y)
    {
        Size = size;
    }

    public override void Draw(DrawingContext drawingContext)
    {
        Pen pen = new Pen(Brushes.Purple, 5);
        Brush brush = new SolidColorBrush(Colors.FloralWhite);

        var rect = new Rect(this.X - Size / 2, this.Y - Size / 2, Size, Size);

        drawingContext.DrawRectangle(brush, pen, rect);
        Console.WriteLine("Drawing a square!");
    }
}