using System.Collections.ObjectModel;
using System.Diagnostics;
using static System.BitConverter;

namespace CodingConnected.Traci.ProtocolTypes;

/// <summary>
/// 发送到 TraCI 服务器的命令
/// </summary>
/// <param name="identifier">命令标识符</param>
/// <param name="content">命令内容</param>
[DebuggerDisplay("{DebugString}")]
public sealed class TraciCommand(byte identifier, IEnumerable<byte> content)
    {
    /// <summary>
    /// 命令标识符
    /// </summary>
    public byte Identifier { get; } = identifier;

    /// <summary>
    /// 命令内容
    /// </summary>
    public ReadOnlyCollection<byte> Contents { get; } = new([.. content]);

    /// <summary>
    /// 16进制调试字符串(每个字节以两位16进制表示，字节间以空格分隔)
    /// </summary>
    public string DebugString =>
        string.Concat(ToMessageBytes().Select(i => $"{i:X2} "));

    public byte[] ToMessageBytes()
        {
        List<byte> contentPart = [];

        // add length for content
        switch (Contents?.Count)
            {
            case <= 255 - 2 /* one byte fot length ,one byte for identifier*/:
                {
                contentPart.Add((byte)(Contents.Count + 2));
                break;
                }
            case > 255 - 2:
                {
                contentPart.Add(0);
                contentPart.AddRange(GetBytes(Contents.Count + 6).Reverse());
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
        }

    public ReadOnlySpan<byte> ToMessageSpan()
        {
        int contentCount = Contents?.Count ?? 0;
        bool useShort = contentCount <= 255 - 2; // 255 - 2 == 253

        int contentLengthFieldSize = useShort ? 1 : 5; // short: 1 byte, long: 1 (zero) + 4 bytes
        int contentPartCount = contentLengthFieldSize + 1 /* identifier */ + contentCount;
        int totalLengthValue = contentPartCount + 4; // 与原实现相同的长度值
        int totalSize = 4 /* total length bytes */ + contentPartCount;

        var buffer = new byte[totalSize];

        // 写入总长度（4 字节，大端）
        var totalLenBytes = GetBytes(totalLengthValue);
        buffer[0] = totalLenBytes[3];
        buffer[1] = totalLenBytes[2];
        buffer[2] = totalLenBytes[1];
        buffer[3] = totalLenBytes[0];

        int offset = 4;

        // 写入内容长度部分
        if (useShort)
            {
            buffer[offset++] = (byte)(contentCount + 2);
            }
        else
            {
            buffer[offset++] = 0;
            var extLenBytes = GetBytes(contentCount + 6);
            buffer[offset++] = extLenBytes[3];
            buffer[offset++] = extLenBytes[2];
            buffer[offset++] = extLenBytes[1];
            buffer[offset++] = extLenBytes[0];
            }

        // 写入 identifier
        buffer[offset++] = Identifier;

        // 写入内容（如果有）
        if (contentCount > 0)
            {
            // ReadOnlyCollection<T> 实现了 CopyTo(T[] array, int arrayIndex)
            Contents!.CopyTo(buffer, offset);
            }

        return new ReadOnlySpan<byte>(buffer);
        }
    }
