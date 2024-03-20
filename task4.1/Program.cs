using System;

namespace task4._1;
class Program
{
    public static void Main(string[] args)
    {
        int defaultLength = 7;

        // IValueProvider<int> fillInt = new IntValueProvider();
        IArray<int> unoArrayInt = new UnoDimensional<int>(defaultLength, fillInt);

        Message message = Hello;
        message += HowAreYou;  // теперь message указывает на два метода
        message();              // вызываются оба метода - Hello и HowAreYou
        
        void Hello() => Console.WriteLine("Hello");
        void HowAreYou() => Console.WriteLine("How are you?");
        
        
    }
    delegate void Message();
}
