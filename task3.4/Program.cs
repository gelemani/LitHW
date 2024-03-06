using System;

class Program
{
    public static void Main(string[] args)
    {
        ArrayBase[] ab = new ArrayBase[2];
        int length = 5;

        IArrayFill<int> fill = new IntValueProvider();

        IArray<int> unoArrayInt = new UnoDimensional<int>(length, fill);
        unoArrayInt.Print();

        UnoDimensional<double> UnoDimensionalDouble = new UnoDimensional<double>(5);
        UnoDimensional<bool> UnoDimensionalBool = new UnoDimensional<bool>(5);
        UnoDimensional<string> UnoDimensionalString = new UnoDimensional<string>(5);

    }
}