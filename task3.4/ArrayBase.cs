using System;

public abstract class ArrayBase : IArrayBase
{
    public abstract void Print();

    public virtual int Create()
    { 
        Console.WriteLine("Manual(0) or automate(1) ? ");
        int a = int.Parse(Console.ReadLine());
        bool choice = a == 0 ? choice = true : false;
        if (!choice)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}