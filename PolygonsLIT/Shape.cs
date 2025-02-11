using Avalonia.Media;

namespace PolygonsLIT;

public abstract class Shape 
{
    protected internal int X { get; set; }
    protected internal int Y { get; set; }
    protected string Color { get; set; } = null!;
    public static int Radius { get; set; }
    // protected static int Radius
    // {
    //     get { return Radius; }
    //     set { Radius = value;  }
    // }

    public bool IsMoving = false;
    protected int Dx { get; set; }
    protected int Dy { get; set; }

    public int DX 
    {
        get { return Dx; }
        set { Dx = value; }
    }

    public int DY
    {
        get { return Dy; }
        set { Dy = value; }
    }
    
    protected Shape(int x, int y, string color)
    {
        X = x;
        Y = y;
        Color = color;
    }

    protected Shape(int x, int y)
    {
        X = x;
        Y = y;
    }

    static Shape()
    {
        Radius = 52; 
    }

    public abstract void Draw(DrawingContext dc);
    public abstract bool IsInside(int dx, int dy);
}