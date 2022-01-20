using System.Text;

namespace Core.Converters
{
    public class ByteArrayToStringConverter : IConverter<byte[], string>
    {
        public ByteArrayToStringConverter()
        {

        }

        public string Convert(byte[] obj)
        {
            return Encoding.UTF8.GetString(obj);
        }
    }
}
