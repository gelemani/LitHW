using System;
using Avalonia.Controls;
using Avalonia.Input;

namespace PolygonsLIT;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void InputElement_OnPointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        CustomControl customControl = this.Find<CustomControl>("CustomControl")!;
        if (e.GetCurrentPoint(customControl).Properties.IsRightButtonPressed)
        {
            customControl.LeftClick(Convert.ToInt32(e.GetPosition(customControl).X), Convert.ToInt32(e.GetPosition(customControl).Y));
            
        }
        else
        {
            customControl.RightClick(Convert.ToInt32(e.GetPosition(customControl).X), Convert.ToInt32(e.GetPosition(customControl).Y));
        }
    }
    
    private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        CustomControl customControl = this.Find<CustomControl>("CustomControl")!;
        customControl.Drag(Convert.ToInt32(e.GetPosition(customControl).X), Convert.ToInt32(e.GetPosition(customControl).Y));
    }

    private void InputElement_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        CustomControl customControl = this.Find<CustomControl>("CustomControl")!;
        customControl.Drop();
    }

    private void ShapeComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox comboBox && CustomControl != null)
        {
            CustomControl.SelectedShapeIndex = comboBox.SelectedIndex;
        }
    }
}