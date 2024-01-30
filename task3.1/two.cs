using System;


class DosDimensional
{
    private int rows, columns;
    private int[,] array;
    private bool choice;

    public DosDimensional(int Rows, int Columns, bool Choice = false)
    {
        choice = Choice;
        rows = Rows;
        columns = Columns;
        CreateDos();
    }

    public void CreateDos()
    {
        array = new int[rows, columns];
        if (!choice)
        {
            array = GetTwoDimensionalArrayRand(rows, columns);
        }
        else
        {
            array = GetTwoDimensionalArrayInput(rows, columns);
        }
    }

    private int[,] GetTwoDimensionalArrayRand(int rows, int columns)
    {
        Random rand = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = rand.Next(-200, 200);
            }
            Console.WriteLine();
        }
        return array;
    }

    private int[,] GetTwoDimensionalArrayInput(int rows, int columns)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; i++)
            {
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }
        return array;
    }

    public void middleValueDos()
    {
        Console.WriteLine("\nTask 1");
        int counter = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                counter += array[i, j];
            }
        }
        Console.WriteLine(counter / array.Length);
    }

    public void matrixValueDos()
    {
        Console.WriteLine("\nTask 2.1");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.Write("\n");
        }

        Console.WriteLine("\nTask 2.2");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                var element = i % 2 == 0
                    ? array[i, array.GetLength(1) - 1 - j]
                    : array[i, j];
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
