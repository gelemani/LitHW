using System;


public sealed class DosDimensional : ArrayBase
{
    private int rows, columns;
    private int[,] _array;
    private bool choice;

    public DosDimensional(int rows, int columns)
    {
        _array = new int[rows, columns];
        Create();
    }


    public override void RandFill()
    {
        Random rand = new Random();
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = rand.Next(-200, 200);
            }
            Console.WriteLine();
        }
    }

    public override void HandFill()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
    }

    public override void MiddleValue()
    {
        int counter = 0;
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                counter += _array[i, j];
            }
        }
        Console.WriteLine("Average: " + counter / _array.Length);
    }

    public override void Print()
    {
        Console.WriteLine("\ndos array:");
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