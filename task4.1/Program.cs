using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace task4._1;
class Program
{
    public static void Main(string[] args)
    {
        UnoDimensional<int> unoInt = new(5);
        unoInt.Add(1);
        unoInt.Add(123);
        unoInt.Add(1);
        unoInt.Add(1);
        unoInt.Add(1000);
        unoInt.Print();

        unoInt.Reverse();
        unoInt.Print();

        unoInt.Sorting();
        unoInt.Print();

        Console.WriteLine(string.Join(",", unoInt.Where(x => x > 1)));

        // int[] numbers = unoInt.Where( (x) => {});
        // Console.WriteLine(string.Join(' ', numbers));
    }
}