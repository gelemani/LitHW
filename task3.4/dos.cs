using System;


public sealed class DosDimensional<T> : ArrayBase
{
    private T[,] _array;
    private bool choice;

    public DosDimensional(int rows, int columns)
    {
        _array = new T[rows, columns];
        GetRandomValue
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