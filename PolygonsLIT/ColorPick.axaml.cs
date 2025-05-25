using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace PolygonsLIT;

public partial class ColorPick : Window
{
    private Color _lastColor;

    public ColorPick()
    {
        InitializeComponent();
        _lastColor = Colors.Green;
    }

    public event Delegates.ColorChangedHandler? 
        ColorHandler;
    
    private void OkButtonPressed(object sender, RoutedEventArgs e)
    {
        _lastColor = this.FindControl<ColorPicker>("ColorPicker")!.Color;
        if (ColorHandler != null) ColorHandler(this, new Delegates.ColorEventArgs(_lastColor));
        Close();
    }

    private void DefaultButton_Pressed(object sender, RoutedEventArgs e)
    {
        this.FindControl<ColorPicker>("ColorPicker")!.Color = _lastColor;
    }
}