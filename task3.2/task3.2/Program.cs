using System;

class Program
{
    public static void Main(string[] args)
    {
        ArrayBase[] ab = new ArrayBase[3];
        ab[0] = new UnoDimensional(5);
        ab[1] = new DosDimensional(4, 4);
        ab[3] = new JaggedDimensional(3);
        foreach (var item in ab)
        { 
            item.MiddleValue();
            item.Print();
        }
    }
}
