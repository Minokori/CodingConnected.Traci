using static System.BitConverter;

namespace CodingConnected.TraCI.NET
    {
    public class TraCICommand
        {
        public byte Identifier { get; set; }
        public byte[] Contents { get; set; }

        public byte[] ToMessageBytes()
            {
            List<byte> cmessage = [];

            switch (Contents?.Length)
                {
                case <= 255 - 2:
                        {
                        cmessage.Add((byte)(Contents.Length + 2));
                        break;
                        }
                case > 255 - 2:
                        {
                        cmessage.Add(0);
                        cmessage.AddRange(GetBytes(Contents.Length + 6).Reverse());
                        break;
                        }
                case null:
                        {
                        cmessage.Add(2);
                        break;
                        }
                }
            cmessage.Add(Identifier);
            cmessage = Contents is null ? cmessage : [.. cmessage, .. Contents];
            var totmessage = GetBytes(cmessage.Count + 4).Reverse();
            return [.. totmessage, .. cmessage];

            }
        }
    }