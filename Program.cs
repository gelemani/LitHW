using System;
using System.Xml.Serialization;

class MainClass
{
    public static void Main()
    {
        Choice();

        Console.WriteLine("\nOne-dimensional");
        Console.WriteLine("Enter array's length: ");
        UnoDimensional uno = new UnoDimensional(int.Parse(Console.ReadLine()));
        uno.PrintUno();
        uno.middleValueUno();
        uno.GetRidofValue();
        uno.NonRepeat();

        Console.WriteLine("\nTwo-dimensional");
        (int, int) dosInput = Input();
        DosDimensional dos = new DosDimensional(dosInput.Item1, dosInput.Item2);
        dos.middleValueDos();
        dos.matrixValueDos();

        Console.WriteLine("\nJagged array");
        JaggedDimensional jag = new JaggedDimensional(InputJaggedDimensional());
        jag.MiddleValueJagged();
        jag.MiddleValueInEachJagged();
        jag.JaggedArray_ReplaceEvenValues();
    }

    static bool Choice()
    {

        Console.WriteLine("Manual(0) or automate(1) ? ");
        int a = int.Parse(Console.ReadLine());
        bool choice = a == 0 ? choice = true : false;
        return choice;
    }

    static (int, int) Input()
    {
        Console.WriteLine("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of columns: ");
        int columns = int.Parse(Console.ReadLine());
        return (rows, columns);
    }

    static int InputJaggedDimensional()
    {
        Console.WriteLine("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        return rows;
    }
}


class UnoDimensional
{
    private int length;
    private int[] array;

    public UnoDimensional(int length, bool choice = false)
    {
        array = new int[length];
        if (!choice)
        {
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(-200, 200);
            }
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void PrintUno()
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public void middleValueUno()
    {
        Console.WriteLine("\nTask 1");
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            counter += array[i];
        }
        Console.WriteLine(counter / array.Length);
    }

    public void GetRidofValue()
    {
        Console.WriteLine("\nTask 2");
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) < 100)
            {
                counter += 1;
            }
        }
        int[] newArr = new int[counter];
        int j = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) < 100)
            {
                newArr[j] = array[i];
                j++;
            }
        }
        foreach (var item in newArr)
        {
            Console.WriteLine(item);
        }
    }

    public void NonRepeat()
    {
        Console.WriteLine("\nTask 3");
        int newArrayLength = array.Length;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                if (array[i] == array[j] && i != j)
                {
                    newArrayLength--;
                    break;
                }
            }
        }
        int[] newArray = new int[newArrayLength];
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = int.MinValue;
        }
        int counter = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (!Exists(array[i], newArray))
            {
                newArray[counter] = array[i];
                counter++;
            }
        }
        PrintArray(newArray);
    }
    private static bool Exists(int value, int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }
    private static void PrintArray(int[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}


class DosDimensional
{
    private int rows, columns;
    private int[,] array;

    public DosDimensional(int rows, int columns, bool choice = false)
    {
        array = new int[rows, columns];
        if (!choice)
        {
            array = GetTwoDimensionalArray(rows, columns);
        }
        else
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; i++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
    }

    private int[,] GetTwoDimensionalArray(int rows, int columns)
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


class JaggedDimensional
{
    private int rows;
    private int[][] array;

    public JaggedDimensional(int rows, bool choice = false)
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
