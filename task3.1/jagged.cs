using System;


class JaggedDimensional
{
    private int rows;
    private int[][] array;
    private bool choice;

    public JaggedDimensional(int Rows, bool Choice = false)
    {
        choice = Choice;
        rows = Rows;
        CreateJag();
    }

    public void CreateJag()
    {
        array = new int[rows][];
        if (!choice)
        {
            array = GetJaggedArrayRand(rows);
        }
        else
        {
            array = GetJaggedArrayInput(rows);
        }
        PrintArrayJag(array);
    }

    private int[][] GetJaggedArrayRand(int rows)
    {
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            int columns = rand.Next(1, 6);
            array[i] = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                array[i][j] = rand.Next(-200, 200);
            }
            Console.WriteLine();
        }
        return array;
    }

    private int[][] GetJaggedArrayInput(int rows)
    {
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"How much element in {i + 1} podmassive: ");
            array[i] = new int[int.Parse(Console.ReadLine())];
            for (int j = 0; j < array[i].Length; j++)
            {
                array[i][j] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
        return array;
    }

    public void MiddleValueJagged()
    {
        Console.WriteLine("\nTask 1");
        int sum = 0;
        int counter = 1;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                sum += array[i][j];
                counter += 1;
            }
        }
        try
        {
            Console.WriteLine(sum / (counter - 1));
        }
        catch (Exception e)
        {
            Console.WriteLine($"Empty array: {e.Message}");
            throw;
        }
    }

    public void MiddleValueInEachJagged()
    {
        Console.WriteLine("\nTask 2");
        for (int i = 0; i < array.Length; i++)
        {
            int sum = 0;
            int counter = 1;
            for (int j = 0; j < array[i].Length; j++)
            {
                sum += array[i][j];
                counter += 1;
            }
            try
            {
                Console.WriteLine(sum / (counter - 1));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Empty array: {e.Message}");
                throw;
            }
        }
    }

    public void JaggedArray_ReplaceEvenValues()
    {
        Console.WriteLine("\nTask 3");
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] % 2 == 0)
                {
                    array[i][j] = i * j;
                }
            }
        }
        PrintArrayJag(array);    
    }

    private static void PrintArrayJag(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}