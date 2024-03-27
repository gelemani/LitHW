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

    public void Remove(int index)
    {
        if (index <= _size)
        {
            T[] newArray = new T[_capacity];
            for (int i = 0; i < _size; i++)
            {
                if (i != index)
                {
                    newArray[i] = _array[i];
                }
            }
            _size--;
            _array = newArray; 
        }
        else
        {         
            Console.WriteLine("You can't do this operation");
        }
    }


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
        catch (Exception e)
        {
            Console.WriteLine($"{e}, \n so you can't do this operation");
            return _array;
        }
    }

    public void Sorting()
    {
        Array.Sort(_array, 0, _size);
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


    public void FillArray<T> (Func<T> fillRandFunc)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = fillRandFunc();                                // ???????????????????????????????????????????????????????????????????????????????????????
        }
    }

    public static void PrintArrayWithCondition<T> (T[] array, Func<T, bool> conditionFunc)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (conditionFunc(array[i]))
            {
                Console.Write(array[i] + " ");
            }
        }
        Console.WriteLine();
    }

    public static void ForEachAction<T> (T[] array, Action<T> action)
    {
        for (int i = 0; i < array.Length; i++)
        {
            action(array[i]);
        }
    }

    public override void Print()
    {
        Console.WriteLine($"\n{typeof(T)} uno array:");
        Console.WriteLine(string.Join(" ", _array));
    }
}