class IntValueProvider : IArrayFill<int>
{
    private static Random random = new Random();

    public int GetRandomValue()
    {
        return random.Next(0, 101);
    }
}