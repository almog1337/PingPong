
namespace Core.Converters
{
    public interface IConverter<T, R>
    {
        R Convert(T obj);
    }
}
