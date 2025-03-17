#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace CodingConnected.Traci.DataTypes;

public sealed class ControlledLinks(IEnumerable<ITraciType> innerObjects) : TraciArrayType(innerObjects)
    {
    public int NumberOfSignals => (TraciInteger)this[0];
    public List<List<string>> Links => [.. this.Skip(1).Select(i => (TraciStringList)i)];
    }
