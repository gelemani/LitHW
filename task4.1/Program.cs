using System;

namespace task4._1;
class Program
{
    public static void Main(string[] args)
    {
        Message message = Hello;
        message += HowAreYou;  // теперь message указывает на два метода
        message();              // вызываются оба метода - Hello и HowAreYou
        
        void Hello() => Console.WriteLine("Hello");
        void HowAreYou() => Console.WriteLine("How are you?");
        
        
    }
    delegate void Message();
}
