using System;


public sealed class DosDimensional : Array
{
    private int rows, columns;
    private int[,] _array;
    private bool choice;

    public DosDimensional(int Rows, int Columns, bool Choice = false)
    {
        choice = Choice;
        rows = Rows;
        columns = Columns;
    }

    public override void Create()
    {
        _array = new int[rows, columns];
        _array = GetTwoDimensionalArrayRand(rows, columns);
    }

    private int[,] GetTwoDimensionalArrayRand(int rows, int columns)
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
        return _array;
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
        Console.WriteLine("Array:");
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