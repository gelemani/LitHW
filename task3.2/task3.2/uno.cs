using System;

public sealed class UnoDimensional : ArrayBase
{
    private int length;
    private int[] _array;
    private bool choice;

    public UnoDimensional(int Length)
    {
        length = Length;
        Create();
    }

    public override void Create()
    {
        _array = new int[length];
        Random rand = new Random();
        for (int i = 0; i < length; i++)
        {
            _array[i] = rand.Next(-200, 200);
        }
    }

    public override void Print()
    {
        Console.WriteLine("Array:");
        Console.WriteLine(string.Join(" ", _array));
    }

    public override void MiddleValue()
    {
        int counter = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            counter += _array[i];
        }
        Console.WriteLine("Average: " + counter / _array.Length);
    }
}
