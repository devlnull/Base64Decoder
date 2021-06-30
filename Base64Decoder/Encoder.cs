using System.Text;

namespace Base64Decoder
{
    public class Encoder
    {
        public static string Encode(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var encoded = System.Convert.ToBase64String(bytes);
            return encoded;
        }
    }
}
