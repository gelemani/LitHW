using System;



public sealed class UnoDimensional<T> : ArrayBase
{
    private T[] _array;
    private bool choice;
    private IArrayFill<T> _fill;

    public UnoDimensional(int length, IArrayFill<T> fill)
    {
        _array = new T[length];
        IArrayFill(length);
        _fill = fill;
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
        Console.WriteLine("\nuno array:");
        Console.WriteLine(string.Join(" ", _array));
    }
}