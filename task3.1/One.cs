using System;


class UnoDimensional
{
    private int length;
    private int[] array;
    private bool choice;

    public UnoDimensional(int Length, bool Choice = false)
    {
        choice = Choice;
        length = Length;
        CreateUno();
    }

    public void CreateUno()
    {
        array = new int[length];
        if (!choice)
        {
           array = GetUnoDimensionalArrayRand(length);
        }
        else
        {
            array = GetUnoDimensionalArrayInput(length);
        }
        PrintUno(array);
    }

    private int[] GetUnoDimensionalArrayRand(int length)
    {
        Random rand = new Random();
        for (int i = 0; i < length; i++)
        {
            array[i] = rand.Next(-200, 200);
        }
        return array;
    }

    private int[] GetUnoDimensionalArrayInput(int length)
    {
        for (int i = 0; i < length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
    }

    public void PrintUno(array)
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