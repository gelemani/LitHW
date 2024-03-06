using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class IArrayFill<T>
{
    private T[] _array;
    public IArrayFill(int length)
    {
        _array = new T[length];
    }

    
    public T GetRandomValue(Type currentType)
    {
        currentType = typeof(T);
        Random rand = new Random();
        if (currentType == typeof(int))
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = rand.Next(-200, 200);
            }
            currentType = ;
        }
        /*if (currentType == typeof(double))
        {
            return rand.Next();
        }
        if (currentType == typeof(bool))
        {
            return rand.Next();
        }
        if (currentType == typeof(string))
        {
            return rand.Next();
        }
        if (currentType == typeof(BankAccount))
        {

        }*/
    }
}
