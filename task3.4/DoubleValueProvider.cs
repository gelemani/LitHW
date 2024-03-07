class DoubleValueProvider : IValueProvider<double>
{
    private static Random random = new Random();

    public double GetRandomValue()
    {
        return random.Next(0, 101);
    }

    public double GetUserValue()
    {
        return double.Parse(Console.ReadLine());
    }
}