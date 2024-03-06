internal interface IArray<T> : IPrinter
{
    int Length { get; }
    T this[int index] { get; }
    void ReCreate(int length);
}