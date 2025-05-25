using System;
using Avalonia.Media;

namespace PolygonsLIT;

public class Delegates
{
    public delegate void RadiusChangedHandler(object? sender, RadiusEventArgs e);

    public class RadiusEventArgs(int r = 30) : EventArgs
    {
        public int R { get; set; } = r;
    }
    
    public delegate void ColorChangedHandler(object? sender, ColorEventArgs e);
    public class ColorEventArgs(Color color) : EventArgs
    {
        public Color Color { get; set; } = color;
    }
}