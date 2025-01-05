using CodingConnected.TraCI.NET.Constants;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Types;

/// <summary>
/// 实现该接口说明该类型是一个TraCI类型
/// </summary>
public interface ITraCIType
    {
    public byte TYPE { get; }
    byte[] ToBytes() { return []; }

    };


public class TraCICompoundObject : List<ITraCIType>, ITraCIType
    {
    public byte TYPE { get; } = TraCIConstants.TYPE_COMPOUND;


    public byte[] ToBytes()
        {
        List<byte> bytes = [];
        bytes.AddRange(Count.ToTraCIBytes());
        foreach (var item in this)
            {
            bytes.Add(item.TYPE);
            bytes.AddRange(item.ToBytes());
            }
        return [.. bytes];
        }
    }
