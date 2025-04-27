using Avalonia.Controls;

namespace PolygonsLIT;

public partial class AnalitycsWindow : Window
{
    public AnalitycsWindow()
    {
        this.Width = 800;
        this.Height = 600;
        this.Title = "Graph Window";
        this.Content = new AnalitycsCustomControl();
    }
}