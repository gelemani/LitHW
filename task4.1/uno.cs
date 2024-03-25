using System;


namespace task4._1;
public class UnoDimensional<T> : ArrayBase
{
    private T[] _array;

    public UnoDimensional(T[] array)
    {
        _array = array;      
    }

    public T[] Where(Func<T, bool> condition)
    {
        T[] _arr = new T[_array.Length];
        int count = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (condition(_arr[i]))
            {
                _arr[count++] = _array[i];
            }
        }
        Array.Resize(ref _arr, count);
        return _arr;
    }

    public T[] Add(T element)
    {
        T[] _arr = new T[_array.Length + 1];
        _arr[_arr.Length - 1] = element;    
        return _arr;
    }

    public T[] Remove(T element)
    {
        T[] _arr = new T[_array.Length - 1];
        for (int i = 0; i < _arr.Length; i++)
        {
            if (_arr[i] == element)
            {
                continue;
            }
            _arr[i] = _array[i];
        }
        Array.Resize(ref _arr, _arr.Length - 1);
        return _arr;
    }


    public T[] Reverse()
    {
        T[] _arr = new T[_array.Length];
        int count = 0;
        for (int i = _arr.Length; i >= 0; i--)
        {
            _arr[i] = _array[count++];
        }
        return _arr;
    }

    public override void Print()
    {
        Console.WriteLine($"\n{typeof(T)} uno array:");
        Console.WriteLine(string.Join(" ", _array));
    }
}