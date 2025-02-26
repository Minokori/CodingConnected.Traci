using static System.BitConverter;

namespace CodingConnected.TraCI.NET.ProtocolTypes;

public class TraCICommand(byte identifier, IEnumerable<byte> content)
    {
    public byte Identifier { get; set; } = identifier;
    public byte[] Contents { get; set; } = [.. content];

    public byte[] ToMessageBytes()
        {
        List<byte> contentPart = [];

        switch (Contents?.Length)
            {
            case <= 255 - 2:
                    {
                    contentPart.Add((byte)(Contents.Length + 2));
                    break;
                    }
            case > 255 - 2:
                    {
                    contentPart.Add(0);
                    contentPart.AddRange(GetBytes(Contents.Length + 6).Reverse());
                    break;
                    }
            case null:
                    {
                    contentPart.Add(2);
                    break;
                    }
            }
        contentPart.Add(Identifier);
        contentPart = Contents is null ? contentPart : [.. contentPart, .. Contents];
        var lengthPart = GetBytes(contentPart.Count + 4).Reverse();
        return [.. lengthPart, .. contentPart];
        }
    }
