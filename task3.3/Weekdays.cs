using System;

public class Weekdays : IPrinter
{
    public void Print()
    {
        foreach (var item in Enum.GetValues(typeof(weekdaysList)))
        {
            Console.WriteLine(item);
        }
    }

    public enum weekdaysList
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}