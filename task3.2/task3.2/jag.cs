using System;


public sealed class JaggedDimensional : ArrayBase
{
    private int rows;
    private int[][] _array;
    private bool choice;

    public JaggedDimensional(int Rows)
    { 
        rows = Rows;
        Create();
    }

    public override void Create()
    {
        _array = new int[rows][];
        Random rand = new Random();
        for (int i = 0; i < _array.Length; i++)
        {
            int columns = rand.Next(1, 6);
            _array[i] = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                _array[i][j] = rand.Next(-200, 200);
            }
            Console.WriteLine();
        }
    }


    public override void MiddleValue()
    {
        int sum = 0;
        int counter = 1;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = 0; j < _array[i].Length; j++)
            {
                sum += _array[i][j];
                counter += 1;
            }
        }
        try
        {
            Console.WriteLine("Average: " + sum / (counter - 1));
        }
        catch (Exception e)
        {
            Console.WriteLine($"Empty array: {e.Message}");
            throw;
        }
    }


    public override void Print()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = 0; j < _array[i].Length; j++)
            {
                Console.Write(_array[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}