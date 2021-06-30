using System.Text;

namespace Base64Decoder
{
    public static class Decoder
    {
        public static string Decode(string input)
        {
            input = PrepareInput(input);
            var decoded = System.Convert.FromBase64String(input);
            string result = Encoding.UTF8.GetString(decoded);
            return result;
        }

        private static string PrepareInput(string input)
        {
            input = input.Trim();
            input = input.Replace('-', '+').Replace('_', '/').PadRight(4 * ((input.Length + 3) / 4), '=');


            return input;
        }
    }
}
