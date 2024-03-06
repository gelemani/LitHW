using System;



public sealed class UnoDimensional<T> : ArrayBase
{
    private T[] _array;
    private bool choice;

    public UnoDimensional(int length, T fill)
    {
        _array = new T[length];
        IArrayFill(length);


    }

    public override void Print()
    {
        Console.WriteLine("\nuno array:");
        Console.WriteLine(string.Join(" ", _array));
    }
}