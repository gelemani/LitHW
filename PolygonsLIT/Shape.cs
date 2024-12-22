using Avalonia.Media;

namespace PolygonsLIT;

public abstract class Shape
{
    protected int X { get; set; }
    protected int Y { get; set; }
    protected string Color { get; set; } = null!;
    protected static int Radius { get; set; }

    protected Shape(int x, int y, string color)
    {
        this.X = x;
        this.Y = y;
        this.Color = color;
    }

    protected Shape(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    static Shape()
    {
        Radius = 12; 
    }

    public abstract void Draw(DrawingContext dc);
}