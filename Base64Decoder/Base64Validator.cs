using System.Linq;

namespace Base64Decoder
{
    public class Base64Validator
    {
        public static bool IsValid(string input)
        {
            foreach (var character in input)
                if (Base64Info.ValidCharacters.Contains(character) == false)
                    return false;
            return true;
        }
    }
}
