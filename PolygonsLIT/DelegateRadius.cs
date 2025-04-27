using System;

namespace PolygonsLIT;

public class DelegateRadius
{
    public delegate void RadiusChangedHandler(object? sender, RadiusEventArgs e);

    public class RadiusEventArgs : EventArgs
    {
        public int R { get; set; }
        public RadiusEventArgs(int r = 30)
        {
            R = r;
        }
    }
}