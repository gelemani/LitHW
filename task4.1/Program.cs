using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace task4._1;
class Program
{
    public static void Main(string[] args)
    {
        UnoDimensional<int> unoInt = new(5);
        FillArray(() => Random.Shared.Next(0, 501));
        unoInt.Print();

        unoInt.Reverse();
        unoInt.Print();

        unoInt.Sorting();
        unoInt.Print();

        unoInt.Remove(10);
        unoInt.Print();

        Console.WriteLine(unoInt.Where((x) => x % 2 == 1));

        // int[] numbers = unoInt.Where( (x) => {});
        // Console.WriteLine(string.Join(' ', numbers));
    }

    private static void FillArray(UnoDimensional<int> unoInt, Func<int> value)
    {
        throw new NotImplementedException();
    }
}
