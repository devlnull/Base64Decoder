using System.Collections.Generic;

namespace Base64Decoder
{
    public class Base64Transformer
    {
        public static string TransformBase64(string input)
        {
            input = input.Replace("-", "+");
            input = input.Replace("_", "/");
            return input;
        }

        public static IEnumerable<string> SeparateByPipeBase64(string input)
        {
            if (input.Contains("|") == false)
                yield return input;

            var separated = input.Split('|');
            foreach (var item in separated)
            {
                if (string.IsNullOrWhiteSpace(item) == false)
                    yield return item;
            }
        }
    }
}
