using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace PolygonsLIT;

public class DraggableCircle : Control
{
    private Point _currentPosition; // Текущая позиция
    private bool _isDragging; // Флаг перетаскивания
    private Point _dragStartOffset; // Смещение относительно точки начала перетаскивания

    public DraggableCircle()
    {
        // Начальные координаты
        _currentPosition = new Point(100, 100);

        // Подписываемся на события мыши
        this.PointerPressed += OnPointerPressed;
        this.PointerMoved += OnPointerMoved;
        this.PointerReleased += OnPointerReleased;
    }

    // Обработка нажатия кнопки мыши
    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        // Проверяем, нажата ли левая кнопка мыши
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            _isDragging = true;
            // Вычисляем начальное смещение относительно центра круга
            _dragStartOffset = e.GetPosition(this) - _currentPosition;
            e.Pointer.Capture(this); // Захватываем указатель
        }
    }

    // Обработка движения мыши
    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (_isDragging)
        {
            // Обновляем позицию на основе текущего положения мыши
            _currentPosition = e.GetPosition(this) - _dragStartOffset;
            this.InvalidateVisual(); // Перерисовываем элемент
        }
    }

    // Обработка отпускания кнопки мыши
    private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        if (_isDragging)
        {
            _isDragging = false;
            e.Pointer.Capture(null); // Освобождаем указатель
        }
    }

    // Отрисовка круга
    public override void Render(DrawingContext context)
    {
        base.Render(context);

        // Рисуем круг
        Brush brush = new SolidColorBrush(Colors.Blue);
        Pen pen = new Pen(new SolidColorBrush(Colors.Black), 2);
        context.DrawEllipse(brush, pen, _currentPosition, 50, 50);
    }
}

