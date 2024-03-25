using System;

namespace task4._1;
public class UnoDimensional<T>
{
    private T[] _array;

    public UnoDimensional()
    {
        _array = new T[7];
        Create();
    }
    
    public T[] Add(T element)
    {
        
    }

    public T[] Where(Func<T, bool> condition)
    {
        T[] _arr = new T[_array.Length];
        int count = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (condition(arr[i]))
            {
                _arr[count++] = _array[i];
            }
        }
        Array.Resize(_arr, count);
        return _arr;
    } 

    public override void Print()
    {
        Console.WriteLine($"\n{typeof(T)} uno array:");
        Console.WriteLine(string.Join(" ", _array));
    }
}