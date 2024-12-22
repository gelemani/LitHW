using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using PolygonsLIT.Shapes;

namespace PolygonsLIT;

public class CustomControl : UserControl
{
    public override void Render(DrawingContext drawingContext)
    {
       Square square = new Square(300, 300, 100);
        square.Draw(drawingContext);
        
        Triangle triangle = new Triangle(300, 405);
        triangle.Draw(drawingContext);
        
        Circle circle = new Circle(280, 300, 12);
        circle.Draw(drawingContext);
        
        circle = new Circle(320, 300, 12);
        circle.Draw(drawingContext);
    }
} 