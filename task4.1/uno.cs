using System;

namespace task4._1;
public class UnoDimensional<T>
{
    private T[] _array;
    private IValueProvider<T> _fill;
    delegate void Fill();

    public UnoDimensional(int defaultLength)
    {
        _array = new T[defaultLength];
        Fill _fill;
        Create();
    }
   
    private static Random random = new Random();    

    public int GetRandomValue()
    {
        return random.Next(0, 101);
    }

    public int GetUserValue()
    {
        return int.Parse(Console.ReadLine());
    }
   

    protected override void RandFill()
    { 
        Random rand = new Random();
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = _fill.GetRandomValue();
        }
    }

    protected override void HandFill()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = _fill.GetUserValue();
        }
    }

    public override void Print()
    {
        Console.WriteLine($"\n{typeof(T)} uno array:");
        Console.WriteLine(string.Join(" ", _array));
    }
}