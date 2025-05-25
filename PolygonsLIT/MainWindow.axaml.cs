using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;

namespace PolygonsLIT;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        CustomControl customControl = this.Find<CustomControl>("CustomControl")!;

        if (e.Pointer.Captured is TextBlock || e.Pointer.Captured is LightDismissOverlayLayer || e.Pointer.Captured is Border)

            return; 

        if (e.GetCurrentPoint(customControl).Properties.IsRightButtonPressed)
        {
            customControl.LeftClick(Convert.ToInt32(e.GetPosition(customControl).X), Convert.ToInt32(e.GetPosition(customControl).Y));
        }
        else
        {
            customControl.RightClick(Convert.ToInt32(e.GetPosition(customControl).X), Convert.ToInt32(e.GetPosition(customControl).Y));
        }
        // Console.WriteLine($"Clicked on: {e.Source?.GetType().Name}");
    }

    
    private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        CustomControl customControl = this.Find<CustomControl>("CustomControl")!;
        customControl.Drag(Convert.ToInt32(e.GetPosition(customControl).X), Convert.ToInt32(e.GetPosition(customControl).Y));
        if (e.GetCurrentPoint(customControl).Properties.IsLeftButtonPressed)
        {
            customControl.MoveHull(Convert.ToInt32(e.GetPosition(customControl).X), Convert.ToInt32(e.GetPosition(customControl).Y));
        }
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
    
    private void FileControlComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox comboBox && CustomControl != null)
        {
            CustomControl customControl = this.Find<CustomControl>("CustomControl")!;
            CustomControl.SelectedFileControlIndex = comboBox.SelectedIndex;
        }
    }
    
    private T? FindWindow<T>() where T : Window
    {
        IReadOnlyList<Window?>? windows = ((IClassicDesktopStyleApplicationLifetime)Application.Current?.ApplicationLifetime!)?.Windows;
        if (windows != null)
            foreach (Window? window in windows)
            {
                if (window is T typedWindow)
                {
                    return typedWindow;
                }
            }

        return null;
    }


    private void AlgorithmComboBox_OnSelectionChangedComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox comboBox && CustomControl != null)
        {
            CustomControl customControl = this.Find<CustomControl>("CustomControl")!;
            CustomControl.SelectedAlgorithmIndex = comboBox.SelectedIndex;
            //
            // switch (comboBox.SelectedIndex)
            // {
            //     case 0:
            //         customControl.DrawConvexHull(customControl.DC, customControl.AlgDef);
            //         break;
            //     case 1:
            //         customControl.DrawConvexHull(customControl.DC, customControl.AlgJar);
            //         break;
            //     default:
            //         customControl.DrawConvexHull(customControl.DC, customControl.AlgDef);
            //         Console.WriteLine("Using By Definition (default)");
            //         break;
            // }
        }
    }

    private void SettingsCombobox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox comboBox && CustomControl != null)
        {
            CustomControl.SelectedAlgorithmIndex = comboBox.SelectedIndex;
            OpenWindowByIndex(comboBox.SelectedIndex);
            CustomControl.SelectedAlgorithmIndex = -1;
        }
    }

    private void SettingsComboBox_DropDownClosed(object? sender, EventArgs e)
    {
        if (sender is ComboBox comboBox && CustomControl != null)
        {
            int selectedIndex = comboBox.SelectedIndex;
            // Если индекс не менялся, но окно должно обновиться
            OpenWindowByIndex(selectedIndex);
        }
    }

    private void OpenWindowByIndex(int index)
    {
        CustomControl customControl = this.Find<CustomControl>("CustomControl")!;

        switch (index)
        {
            case 0:
                var radiusWindow = FindWindow<RadiusWindow>();
                if (radiusWindow == null)
                {
                    var newRadiusWindow = new RadiusWindow(Shape.Radius);
                    newRadiusWindow.Rc += customControl.UpdateRadius;
                    newRadiusWindow.Show();
                }
                else
                {
                    if (radiusWindow.WindowState == WindowState.Minimized)
                        radiusWindow.WindowState = WindowState.Normal;
                    radiusWindow.Show();
                    radiusWindow.Activate();
                }
                break;
            case 1:
                var colorPickWindow = FindWindow<ColorPick>();
                if (colorPickWindow == null)
                {
                    var color = new ColorPick();
                    color.ColorHandler += customControl.UpdateColor;
                    color.Show();
                }
                else
                {
                    if (colorPickWindow.WindowState == WindowState.Minimized)
                        colorPickWindow.WindowState = WindowState.Normal;
                    colorPickWindow.Show();
                    colorPickWindow.Activate();
                }
                break;
            case 2:
                var analyticsWindow = FindWindow<AnalitycsWindow>();
                if (analyticsWindow == null)
                {
                    customControl.OpenAnalitycsWindow();
                }
                else
                {
                    if (analyticsWindow.WindowState == WindowState.Minimized)
                        analyticsWindow.WindowState = WindowState.Normal;
                    analyticsWindow.Show();
                    analyticsWindow.Activate();
                }
                break;
        }
    }
}