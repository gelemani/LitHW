using System;

public sealed class UnoDimensional : ArrayBase
{
    private int _length;
    private int[] _array;
    private bool choice;

    public UnoDimensional(int length)
    {
        _length = length;
        _array = new int[length];
        Create();
    }

    public override void RandFill()
    {
        Random rand = new Random();
        for (int i = 0; i < _length; i++)
        {
            _array[i] = rand.Next(-200, 200);
        }
    }

    public override void HandFill()
    {
        for (int i = 0; i < _length; i++)
        {
            _array[i] = int.Parse(Console.ReadLine());
        }
    }

    public override void Print()
    {
        Console.WriteLine("\nuno array:");
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