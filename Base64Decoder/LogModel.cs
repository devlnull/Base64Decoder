namespace Base64Decoder
{
    public class LogModel
    {
        public string Raw { get; set; }
        public string Result { get; set; }
        public bool IsDecode { get; set; }

        public override string ToString()
        {
            string operationName = IsDecode ? "Decoding operation" : "Encoding operation";
            return $"{operationName} => Raw:{Raw}, Result:{Result}";
        }
    }
}
