using System;

public interface IUnoDimensional : IArrayBase
{
    void DeleteDuplicates();
}

public sealed class UnoDimensional<T> : ArrayBase, IUnoDimensional
{
    private int[] _array;
    private bool choice;

    public UnoDimensional(int length)
    {
        _array = new int[length];
        Create();
    }

    protected override void RandFill()
    {
        Random rand = new Random();
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = rand.Next(-200, 200);
        }
    }

    protected override void HandFill()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = int.Parse(Console.ReadLine());
        }
    }

    public void DeleteDuplicates()
    {
        int n = _array.Length;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int it = 0; it < _array.Length; it++)
            {
                if (_array[i] == _array[it] && it != i && it > i)
                {
                    n--;
                }
            }
        }
        int[] newArray = new int[n];
        int newIndex = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            bool isDuplicate = false;
            for (int it = 0; it < i; it++)
            {
                if (_array[i] == _array[it])
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                newArray[newIndex] = _array[i];
                newIndex++;
            }
        }
        _array = newArray;
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