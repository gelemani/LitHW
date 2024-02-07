using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("\nOne-dimensional");
        Console.WriteLine("Enter array's length: ");
        UnoDimensional uno = new UnoDimensional(int.Parse(Console.ReadLine()));
        uno.Create();
        uno.Print();
        uno.MiddleValue();


        Console.WriteLine("\nTwo-dimensional");
        (int, int) dosInput = Input();
        DosDimensional dos = new DosDimensional(dosInput.Item1, dosInput.Item2);
        dos.Create();
        dos.Print();
        dos.MiddleValue();


        Console.WriteLine("\nJagged array");
        JaggedDimensional jag = new JaggedDimensional(InputJaggedDimensional());
        jag.Create();
        jag.Print();
        jag.MiddleValue();
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