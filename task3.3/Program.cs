using System;

class Program
{
    public static void Main(string[] args)
    {
        ArrayBase[] ab = new ArrayBase[3];
        ab[0] = new UnoDimensional(5);
        ab[1] = new DosDimensional(4, 4);
        ab[2] = new JaggedDimensional(3);
        foreach (var item in ab)
        {
            item.Print();
            item.MiddleValue();
        }
        Console.WriteLine("\n-----------------------------------------------------------------------");   
        var week = new Weekdays();
        IUnoDimensional unoDim = (IUnoDimensional)ab[0];
        unoDim.DeleteDuplicates();  
        IDosDimensional dosDim = (IDosDimensional)ab[1];
        IJaggedDimensional jagDim = (IJaggedDimensional)ab[2];
        jagDim.ChangeChet();

        IPrinter[] pr = new IPrinter[4] { unoDim, dosDim, jagDim, week };
        foreach (var item in pr)
        {
            item.Print();
        }
    }
}