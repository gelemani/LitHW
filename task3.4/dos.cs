using System;


public sealed class DosDimensional<T> : ArrayBase, IArray<T>
{
    private T[,] _array;
    private IValueProvider<T> _fill;

    public DosDimensional(int rows, int columns, IValueProvider<T> fill)
    {
        _array = new T[rows, columns];
        _fill = fill;
        Create();
    }

    protected override void RandFill()
    {
        Random rand = new Random();
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = _fill.GetRandomValue();
            }
            Console.WriteLine();
        }
    }

    protected override void HandFill()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = _fill.GetUserValue();
            }
            Console.WriteLine();
        }
    }

    public override void Print()
    {
        Console.WriteLine($"\n{typeof(T)} dos array:");
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            Console.Write($"Row {i}: ");
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                Console.Write(_array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}