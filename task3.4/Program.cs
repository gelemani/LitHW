using System;

class Program
{
    public static void Main(string[] args)
    {
        ArrayBase[] ab = new ArrayBase[2];
/*        ab[0] = new UnoDimensional<int>(5);
        ab[1] = new DosDimensional<int>(4, 4);*/


        UnoDimensional<int> UnoDimensionalInt = new UnoDimensional<int>(5);
        UnoDimensional<double> UnoDimensionalDouble = new UnoDimensional<double>(5);
        UnoDimensional<bool> UnoDimensionalBool = new UnoDimensional<bool>(5);
        UnoDimensional<string> UnoDimensionalString = new UnoDimensional<string>(5);


        DosDimensional<int> DosDimensionalInt = new DosDimensional<int>(4, 4);
        DosDimensional<double> DosDimensionalDouble = new DosDimensional<double>(4, 4);
        DosDimensional<bool> DosDimensionalBool = new DosDimensional<bool>(4, 4);
        DosDimensional<string> DosDimensionalString = new DosDimensional<string>(4, 4);


        foreach (var item in ab)
        {
            item.Print();
            item.MiddleValue();
        }
        Console.WriteLine("\n-----------------------------------------------------------------------");   
        IUnoDimensional<int> unoDim = (IUnoDimensional)ab[0];
        unoDim.DeleteDuplicates();  
        IDosDimensional dosDim = (IDosDimensional)ab[1];

        IPrinter[] pr = { unoDim, dosDim};
        foreach (var item in pr)
        {
            item.Print();
        }
    }
}