using System;


namespace task4._1;
public class UnoDimensional<T> : ArrayBase
{
    private T[] _array;
    private int _size, _capacity;

    public UnoDimensional(int capacity)
    {
        _capacity = capacity;
        _size = 0;
        _array = new T[_capacity];
    }

    public UnoDimensional() : this(7) {}

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

    public void Add(T element)
    {
        if (_size >= _capacity)
        {
            _capacity = _capacity * 2 + 1;
            T[] newArray = new T[_capacity];
            Array.Copy(newArray, 0, _array, 0, _size);
            _array = newArray;
        }
        _array[_size++] = element;
    }

    //public T[] Remove(T element)
    //{
    //    T[] _arr = new T[_array.Length - 1];
    //    for (int i = 0; i < _arr.Length; i++)
    //    {
    //        if (_arr[i] == element)
    //        {
    //            continue;
    //        }
    //        _arr[i] = _array[i];
    //    }
    //    Array.Resize(ref _arr, _arr.Length - 1);
    //    return _arr;
    //}


    public T[] Reverse()
    {
        T[] newArray = new T[_capacity];
        newArray = _array;
        T count = default(T);

        try
        {
            for (int i = 0; i < (newArray.Length / 2); i++)
            {
                count = newArray[i];
                newArray[i] = newArray[newArray.Length - i - 1];
                newArray[newArray.Length - i - 1] = count;
            }
            return newArray;
        }
        catch
        {
             return _array;
        }
    }

    public void Sorting()
    {
        Array.Sort(_array);
    }

    public override void Print()
    {
        Console.WriteLine($"\n{typeof(T)} uno array:");
        Console.WriteLine(string.Join(" ", _array));
    }
}