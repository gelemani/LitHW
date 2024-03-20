using System;

namespace task4._1;
public class UnoDimensional<T>
{
    private T[] _array;
    private IValueProvider<T> _fill;

    public UnoDimensional(int defaultLength, IValueProvider<T> fill)
    {
        _array = new T[defaultLength];
        _fill = fill;
        Create();
    }

    protected override void RandFill()
    {
        Random rand = new Random();
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = _fill.GetRandomValue();
        }
    }

    protected override void HandFill()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = _fill.GetUserValue();
        }
    }

    public override void Print()
    {
        Console.WriteLine($"\n{typeof(T)} uno array:");
        Console.WriteLine(string.Join(" ", _array));
    }
}