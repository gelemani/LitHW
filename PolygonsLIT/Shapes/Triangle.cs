using System;
using Avalonia;
using Avalonia.Media;

namespace PolygonsLIT.Shapes;

public class Triangle : Shape
{
    private Point _unoPoint, _dosPoint, _tresPoint;
    public Triangle(int x, int y) : base(x, y)
    {
    }

    public override void Draw(DrawingContext drawingContext)
    {
        Pen pen = new Pen(Brushes.Purple, 5);
        Brush brush = new SolidColorBrush(Colors.FloralWhite);

        _unoPoint = new Point(X, Y - Radius);
        _dosPoint = new Point(X + (Radius / 2 * Math.Sqrt(3)), Y + Radius / 2);
        _tresPoint = new Point(X - (Radius / 2 * Math.Sqrt(3)), Y + Radius / 2);

        Point[] points =
        {
            _unoPoint,
            _dosPoint,
            _tresPoint,
            _unoPoint
        };

        PolylineGeometry geometry = new PolylineGeometry(points, true);
        drawingContext.DrawGeometry(brush, pen, geometry);
        Console.WriteLine("Drawing a triangle!");
    }

    public override bool IsInside(int dx, int dy)
    {
        double triangleArea = CalculateArea(_unoPoint.X, _unoPoint.Y, _dosPoint.X, _dosPoint.Y, _tresPoint.X, _tresPoint.Y);
        double area1 = CalculateArea(dx, dy, _dosPoint.X, _dosPoint.Y, _tresPoint.X, _tresPoint.Y);
        double area2 = CalculateArea(_unoPoint.X, _unoPoint.Y, dx, dy, _tresPoint.X, _tresPoint.Y);
        double area3 = CalculateArea(_unoPoint.X, _unoPoint.Y, _dosPoint.X, _dosPoint.Y, dx, dy);

        return Math.Abs(area1 + area2 + area3 - triangleArea) < 0.1;
    }
    
    static double CalculateArea(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        double a = Distance(x1, y1, x2, y2);
        double b = Distance(x2, y2, x3, y3);
        double c = Distance(x3, y3, x1, y1);
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}