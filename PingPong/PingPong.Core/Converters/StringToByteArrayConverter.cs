using System.Text;

namespace Core.Converters
{
    public class StringToByteArrayConverter : IConverter<string, byte[]>
    {
        public StringToByteArrayConverter()
        {

        }

        public byte[] Convert(string obj)
        {
            return Encoding.UTF8.GetBytes(obj);
        }
    }
}
