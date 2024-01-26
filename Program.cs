using System;


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