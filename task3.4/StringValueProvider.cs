class StringValueProvider : IValueProvider<string>
{
    private static Random random = new Random();
    private int length = 5;

    public string GetRandomValue()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public string GetUserValue()
    {
        return Console.ReadLine();
    }
}