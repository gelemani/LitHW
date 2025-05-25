using Avalonia.Media;

namespace PolygonsLIT;

public abstract class Shape 
{
    protected internal int X { get; set; }
    protected internal int Y { get; set; }
    protected string Color { get; set; } = null!;
    public static int Radius { get; set; }
    static Pen _pen;
    static Brush _brush = new SolidColorBrush(Colors.DarkRed);

    public bool IsMoving = false;
    protected int Dx { get; set; }
    protected int Dy { get; set; }
    public bool isVertex = false;

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

    public bool IsVertex { get; set; }
    public static Pen Pen { get; set; }

    public static Brush Brush
    {
        get => _brush;
        set
        {
            _brush = value;
            _pen = new Pen(_brush, 3);
        }
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