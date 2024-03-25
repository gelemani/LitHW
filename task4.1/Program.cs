using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace task4._1;
class Program
{
    public static void Main(string[] args)
    {
        UnoDimensional<int> unoInt = new(arrayFillIntDefault(7));
        unoInt.Add(1);
        unoInt.Print();

        UnoDimensional<int> uno = new(arrayFillIntDefault(30));
        uno.Add(15);
        uno.Print();

        // UnoDimensional<string> unoString = new();
        // unoString.Add("sdfsdfs");
        // unoString.Print();
    }

    public static int[] arrayFillIntDefault(int length)
    {
        int[] array = new int[length];
        Random rand = new Random();
        for (int i = 0; i < length; i++)
        {
            array[i] = rand.Next(-1024, 1024);
        }
        return array;
    }
}