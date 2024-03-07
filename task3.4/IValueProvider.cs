public interface IValueProvider<T>
{
    T GetRandomValue();
    T GetUserValue();
}