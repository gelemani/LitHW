using System;

class Program
{
    public static void Main(string[] args)
    {
        int rows = 5;
        int columns = 4;

        IValueProvider<int> fillInt = new IntValueProvider();
        IValueProvider<double> fillDouble = new DoubleValueProvider();
        IValueProvider<bool> fillBool = new BoolValueProvider();
        IValueProvider<string> fillString = new StringValueProvider();

        //Uno
        IArray<int> unoArrayInt = new UnoDimensional<int>(rows, fillInt);
        IArray<double> unoArrayDouble = new UnoDimensional<double>(rows, fillDouble);
        IArray<bool> unoArrayBool = new UnoDimensional<bool>(rows, fillBool);
        IArray<string> unoArrayString = new UnoDimensional<string>(rows, fillString);

        //Dos
        IArray<int> dosArrayInt = new DosDimensional<int>(rows, columns, fillInt);
        IArray<double> dosArrayDouble = new DosDimensional<double>(rows, columns, fillDouble);
        IArray<bool> dosArrayBool = new DosDimensional<bool>(rows, columns, fillBool);
        IArray<string> dosArrayString = new DosDimensional<string>(rows, columns, fillString);


        IPrinter[] printers = { unoArrayInt, unoArrayDouble, unoArrayBool, unoArrayString, dosArrayInt, dosArrayDouble, dosArrayBool, dosArrayString };
        for (int i = 0; i < printers.Length; i++)
        {
            printers[i].Print();
        }
    }
}