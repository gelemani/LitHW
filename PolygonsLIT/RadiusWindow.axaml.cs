using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace PolygonsLIT;

public partial class RadiusWindow : Window
{
    public RadiusWindow(int radius)
    {
        InitializeComponent();
        slider.Value = radius;
    }
    
    public event DelegateRadius.RadiusChangedHandler? Rc;

    private void RadiusSliderValue(object sender, RoutedEventArgs e)
    {
        if (Rc != null)
        {
            Rc(this, new DelegateRadius.RadiusEventArgs(Convert.ToInt32(slider.Value)));
        }
    }
}