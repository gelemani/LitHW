using System;
using System.Xml.Linq;

namespace task4._1;


public class UnoDimensional<T> : ArrayBase
{
    private static T[] _array;
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
            Array.Resize(ref _array, _size);
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
        Array.Sort(_array);
    }

    public T[] Where<U>(Func<T, bool> condition)
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

    public void PrintArrayWithCondition<U> (Func<T, bool> conditionFunc)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (conditionFunc(_array[i]))
            {
                Console.Write(value: _array[i] + " ");
            }
        }
        Console.WriteLine();
    }

    public int CountArrayWithCondition<U>(Func<T, bool> conditionFunc)
    {
        int count = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (conditionFunc(_array[i]))
            {
                count += 1;
            }
        }
        Console.WriteLine();
        return count;
    }

    public int CountArray<U>()
    {
        int count = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            count += 1;
        }

        return count;
    }

    public int CountArrayFromIndex<U>(int index)
    {
        int count = 0;
        for (int i = index; i < _array.Length; i++)
        {
            count += 1;
        }
        return count;
    }

    public T FindFirstElementByCondition(Func<T, bool> condition)
    {
        foreach (var element in _array)
        {
            if (condition(element))
            {
                return element;
            }
        }
        Console.WriteLine("There are no matching elements here");
        return (T)Convert.ChangeType(-1, typeof(T));
    }

    public bool EvenOneCondition<U>(Func<T, bool> conditionFunc)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (conditionFunc(_array[i]))
            {
                return true;
            }
        }
        return false;
    }
    public bool AllCondition<U>(Func<T, bool> conditionFunc)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (!conditionFunc(_array[i]))
            {
                return false;
            }
        }
        return true;
    }

    public void ForEachAction<U>(Action<T> action)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            action(_array[i]);
        }
    }

    public T FindMin<U>(Func<T, T, int> compare) where U : IComparable<U>
    {
        T min = _array[0];
        for (int i = 1; i < _array.Length; i++)
        {
            if (compare(_array[i], min) < 0)
            {
                min = _array[i];
            }
        }
        return min;
    }

    public T FindMax<U>(Func<T, T, int> compare) where U : IComparable<U>
    {
        T max = _array[0];
        for (int i = 1; i < _array.Length; i++)
        {
            if (compare(_array[i], max) > 0)
            {
                max = _array[i];
            }
        }
        return max;
    }

    public void iterForeach(Action<T> action)
    {
        foreach (var item in _array)
        {
            if (!item.Equals(_array))
            {
                action(item);
            }
        }
    }

    public bool Contains<U>(T element)
    {
        return EvenOneCondition<U>((x) => x.Equals(element));
    }

    public override void Print()
    {
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", _array));
    }
}   
