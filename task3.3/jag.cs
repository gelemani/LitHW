using System;

public interface IJaggedDimensional : IArrayBase
{
    void ChangeChet();
}

public sealed class JaggedDimensional : ArrayBase, IJaggedDimensional
{
    private int[][] _array;
    private bool choice;

    public JaggedDimensional(int rows)
    {
        _array = new int[rows][];
        Create();
    }

    protected override void RandFill()
    {
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

    protected override void HandFill()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            Console.WriteLine($"How much element in {i + 1} podmassive: ");
            _array[i] = new int[int.Parse(Console.ReadLine())];
            for (int j = 0; j < _array[i].Length; j++)
            {
                _array[i][j] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
    }

    public void ChangeChet()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = 0; j < _array[i].Length; j++)
            {
                if (_array[i][j] % 2 == 0)
                {
                    _array[i][j] = _array[i][j] * j;
                }
            }
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
            Console.WriteLine($"Empty _array: {e.Message}");
            throw;
        }
    }


    public override void Print()
    {
        Console.WriteLine("\njagged array:");
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