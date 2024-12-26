namespace CodingConnected.TraCI.NET.Types;

/// <summary>
/// 实现该接口说明该类型是一个TraCI类型
/// </summary>
public interface ITraCIType { };


public class TraCIObjects : List<ITraCIType>, ITraCIType
    {
    //public List<TraCIClassBase> Value { get; set; } = [];

    }

