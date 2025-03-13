using static System.BitConverter;

namespace CodingConnected.TraCI.NET.ProtocolTypes;

public class TraCICommand(byte identifier, IEnumerable<byte> content)
    {
    public byte Identifier { get; } = identifier;
    public byte[] Contents { get; } = [.. content];

    public string DebugString => string.Concat(ToMessageBytes().Select(i => i.ToString("X2") + " "));


    public byte[] ToMessageBytes()
        {
        List<byte> contentPart = [];

        // add length for content
        switch (Contents?.Length)
            {
            case <= 255 - 2 /* one byte fot length ,one byte for identifier*/:
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


        // add the identifier part
        contentPart.Add(Identifier);

        // add the content part
        contentPart = Contents is null ? contentPart : [.. contentPart, .. Contents];

        // add the totals length for bytes
        var lengthPart = GetBytes(contentPart.Count + 4).Reverse();
        return [.. lengthPart, .. contentPart];
        //00 00 00 0b 07 ab 72 00 00 00 00
        }
    }
