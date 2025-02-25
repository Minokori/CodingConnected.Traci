#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.TraCI.NET.DataTypes;
public sealed class ControlledLinks : TraciArrayType
    {
    public int NumberOfSignals => ((TraciInteger)this[0]).Value;
    public List<List<string>> Links => [.. this.Skip(1).Select(i => ((TraciStringList)i).Value)];
    }