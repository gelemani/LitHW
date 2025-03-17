using OxyPlot;
using OxyPlot.Series;
using Avalonia.Controls;
using Avalonia.Media;

namespace PolygonsLIT;
public partial class AnalitycsWindow : Window
{
    private LineSeries _executionTimeSeries;
    private LineSeries _borderCountSeries;

    public AnalitycsWindow()
    {
        InitializeComponent();
        
        // Инициализация графиков
        var plotModel = new PlotModel { Title = "Execution Time vs Border Count" };
        
        _executionTimeSeries = new LineSeries
        {
            Title = "Execution Time",
            MarkerType = MarkerType.Circle,
            MarkerSize = 4,
            Color = OxyColors.Green
        };

        _borderCountSeries = new LineSeries
        {
            Title = "Border Count",
            MarkerType = MarkerType.Circle,
            MarkerSize = 4,
            Color = OxyColors.Red
        };
        
        plotModel.Series.Add(_executionTimeSeries);
        plotModel.Series.Add(_borderCountSeries);

        plotView.Model = plotModel; // Связываем график с PlotView
    }

    public void UpdateCharts(double elapsedTotalMilliseconds, double totalMilliseconds, int bordersDefCount, int bordersJarCount)
    {
        // Обновляем данные для графиков
        _executionTimeSeries.Points.Add(new DataPoint(bordersDefCount, elapsedTotalMilliseconds));
        _borderCountSeries.Points.Add(new DataPoint(bordersDefCount, bordersDefCount));

        // Обновляем текстовые блоки
        executionTimeTextBlock.Text = $"ByDefinition Execution Time: {elapsedTotalMilliseconds} ms";
        jarviceTimeTextBlock.Text = $"Jarvice Execution Time: {totalMilliseconds} ms";
        borderCountTextBlock.Text = $"ByDefinition Border Count: {bordersDefCount}";
        bordersJarCountTextBlock.Text = $"Jarvice Border Count: {bordersJarCount}";

        // Обновляем прогресс бары
        executionTimeProgressBar.Value = elapsedTotalMilliseconds;
        jarviceTimeProgressBar.Value = totalMilliseconds;
        bordersDefCountProgressBar.Value = bordersDefCount;
        bordersJarCountProgressBar.Value = bordersJarCount;

        // Обновляем график
        plotView.InvalidatePlot(true); // Перерисовываем график
    }
}
