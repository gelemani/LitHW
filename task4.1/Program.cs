<<<<<<< HEAD
using System;
using System.Collections;
namespace task4._1;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("-----------------------int-----------------------");
        UnoDimensional<int> unoInt = new(5);

        unoInt.Add(1);
        unoInt.Add(215);
        unoInt.Add(-334);
        unoInt.Add(40);
        unoInt.Add(-50);
        unoInt.Print();

        Console.Write("\nSorted - ");
        unoInt.Sorting();
        unoInt.Print();

        Console.Write("\nReversed - ");
        unoInt.Reverse();
        unoInt.Print();
        
        Func<int, int, int> compare = (x, y) => x.CompareTo(y);
        Console.WriteLine($"\nMin {unoInt.FindMin<int>(compare)}");
        Console.WriteLine($"Max {unoInt.FindMax<int>(compare)}");

        Console.Write("\nElement removed - ");
        unoInt.Remove(4);
        unoInt.Print();

        Console.WriteLine();    
        unoInt.ForEachAction<int>((x) =>
        {
            double pow = Math.Pow(x, 2);
            Console.WriteLine("Value = " + x + ", pow^2 = " + pow);
        });

        Console.WriteLine($"\nAll elementes - {unoInt.CountArray<int>()}");

        Console.WriteLine($"With condition - {unoInt.CountArrayWithCondition<int>((x) => x % 2 == 1)}");

        Console.WriteLine($"With at least one  - {unoInt.EvenOneCondition<int>((x) => {
            if (x > 50) { return true; }
            else { return false; }
        })}");

        Console.WriteLine($"With all - {unoInt.AllCondition<int>((x) => {
            if (x >= 0) { return true; }
            else { return false; }
        })}");

        Console.WriteLine($"\nContains - {unoInt.Contains<int>(215)}");

        int[] numbersInt = unoInt.Where<int>((x) => x < 100);
        Console.WriteLine($"Array with condition - {string.Join(' ', numbersInt)}");

        Console.WriteLine($"\nArray from index - {unoInt.CountArrayFromIndex<int>(1)}");

        Console.Write("\nForeach - ");
        unoInt.iterForeach((x) => Console.Write(x * x * x + " "));


        Console.WriteLine("\n\n\n-----------------------float-----------------------");
        UnoDimensional<float> unoFloat = new(4);

        unoFloat.Add(5.1f);
        unoFloat.Add(100.500f);
        unoFloat.Add(33f);
        unoFloat.Add(-500.17f);
        unoFloat.Print();

        Console.Write("\nSorted - ");
        unoFloat.Sorting();
        unoFloat.Print();

        Console.Write("\nReversed - ");
        unoFloat.Reverse();
        unoFloat.Print();

        Func<float, float, int> compareFloat = (x, y) => x.CompareTo(y);
        Console.WriteLine($"\nMin {unoFloat.FindMin<float>(compareFloat)}");
        Console.WriteLine($"Max {unoFloat.FindMax<float>(compareFloat)}");

        Console.Write("\nElement removed - ");
        unoFloat.Remove(8);
        unoFloat.Print();

        Console.WriteLine();
        unoFloat.ForEachAction<float>((x) =>
        {
            double pow = Math.Pow(x, 2);
            Console.WriteLine("Value = " + x + ", pow^2 = " + pow);
        });

        Console.WriteLine($"\nAll elementes - {unoFloat.CountArray<float>()}");

        Console.WriteLine($"With condition - {unoFloat.CountArrayWithCondition<float>((x) => x % 2 == 1)}");

        Console.WriteLine($"With at least one  - {unoFloat.EvenOneCondition<float>((x) =>
        {
            if (x > 50) { return true; }
            else { return false; }
        })}");

        Console.WriteLine($"With all - {unoFloat.AllCondition<float>((x) =>
        {
            if (x >= 0) { return true; }
            else { return false; }
        })}");

        Console.WriteLine($"\nContains - {unoFloat.Contains<float>(21.5f)}");

        float[] numbersFloat = unoFloat.Where<float>((x) => x < 100f);
        Console.WriteLine($"Array with condition - {string.Join(' ', numbersFloat)}");

        Console.WriteLine($"\nArray from index - {unoFloat.CountArrayFromIndex<float>(1)}");

        Console.Write("\nForeach - ");
        unoFloat.iterForeach((x) => Console.Write(x * x * x + " "));
        Console.WriteLine("\n");
    }
=======
using System;
using System.Collections;
namespace task4._1;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("-----------------------int-----------------------");
        UnoDimensional<int> unoInt = new(5);

        unoInt.Add(1);
        unoInt.Add(215);
        unoInt.Add(-334);
        unoInt.Add(40);
        unoInt.Add(-50);
        unoInt.Print();

        Console.Write("\nSorted - ");
        unoInt.Sorting();
        unoInt.Print();

        Console.Write("\nReversed - ");
        unoInt.Reverse();
        unoInt.Print();
        
        Func<int, int, int> compare = (x, y) => x.CompareTo(y);
        Console.WriteLine($"\nMin {unoInt.FindMin<int>(compare)}");
        Console.WriteLine($"Max {unoInt.FindMax<int>(compare)}");

        Console.Write("\nElement removed - ");
        unoInt.Remove(4);
        unoInt.Print();

        Console.WriteLine();    
        unoInt.ForEachAction<int>((x) =>
        {
            double pow = Math.Pow(x, 2);
            Console.WriteLine("Value = " + x + ", pow^2 = " + pow);
        });

        Console.WriteLine($"\nAll elementes - {unoInt.CountArray<int>()}");

        Console.WriteLine($"With condition - {unoInt.CountArrayWithCondition<int>((x) => x % 2 == 1)}");

        Console.WriteLine($"With at least one  - {unoInt.EvenOneCondition<int>((x) => {
            if (x > 50) { return true; }
            else { return false; }
        })}");

        Console.WriteLine($"With all - {unoInt.AllCondition<int>((x) => {
            if (x >= 0) { return true; }
            else { return false; }
        })}");

        Console.WriteLine($"\nContains - {unoInt.Contains<int>(215)}");

        int[] numbersInt = unoInt.Where<int>((x) => x < 100);
        Console.WriteLine($"Array with condition - {string.Join(' ', numbersInt)}");

        Console.WriteLine($"\nArray from index - {unoInt.CountArrayFromIndex<int>(1)}");

        Console.Write("\nForeach - ");
        unoInt.iterForeach((x) => Console.Write(x * x * x + " "));


        Console.WriteLine("\n\n\n-----------------------float-----------------------");
        UnoDimensional<float> unoFloat = new(4);

        unoFloat.Add(5.1f);
        unoFloat.Add(100.500f);
        unoFloat.Add(33f);
        unoFloat.Add(-500.17f);
        unoFloat.Print();

        Console.Write("\nSorted - ");
        unoFloat.Sorting();
        unoFloat.Print();

        Console.Write("\nReversed - ");
        unoFloat.Reverse();
        unoFloat.Print();

        Func<float, float, int> compareFloat = (x, y) => x.CompareTo(y);
        Console.WriteLine($"\nMin {unoFloat.FindMin<float>(compareFloat)}");
        Console.WriteLine($"Max {unoFloat.FindMax<float>(compareFloat)}");

        Console.Write("\nElement removed - ");
        unoFloat.Remove(8);
        unoFloat.Print();

        Console.WriteLine();
        unoFloat.ForEachAction<float>((x) =>
        {
            double pow = Math.Pow(x, 2);
            Console.WriteLine("Value = " + x + ", pow^2 = " + pow);
        });

        Console.WriteLine($"\nAll elementes - {unoFloat.CountArray<float>()}");

        Console.WriteLine($"With condition - {unoFloat.CountArrayWithCondition<float>((x) => x % 2 == 1)}");

        Console.WriteLine($"With at least one  - {unoFloat.EvenOneCondition<float>((x) =>
        {
            if (x > 50) { return true; }
            else { return false; }
        })}");

        Console.WriteLine($"With all - {unoFloat.AllCondition<float>((x) =>
        {
            if (x >= 0) { return true; }
            else { return false; }
        })}");

        Console.WriteLine($"\nContains - {unoFloat.Contains<float>(21.5f)}");

        float[] numbersFloat = unoFloat.Where<float>((x) => x < 100f);
        Console.WriteLine($"Array with condition - {string.Join(' ', numbersFloat)}");

        Console.WriteLine($"\nArray from index - {unoFloat.CountArrayFromIndex<float>(1)}");

        Console.Write("\nForeach - ");
        unoFloat.iterForeach((x) => Console.Write(x * x * x + " "));
        Console.WriteLine("\n");

    }
>>>>>>> 9908cc8 (done!)
}