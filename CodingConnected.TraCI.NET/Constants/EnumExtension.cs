#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
using static CodingConnected.TraCI.NET.Constants.TraciConstants;

namespace CodingConnected.TraCI.NET.Constants;

internal static class EnumExtension
    {
    public static byte ToByte(this DataType dataType) => (byte)dataType;
    }
