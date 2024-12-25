namespace CodingConnected.TraCI.NET
    {
    public class TraCIResult
        {
        public int Length { get; set; }
        public byte Identifier { get; set; }
        public byte[] Response { get; set; }
        }
    }