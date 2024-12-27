using System.Text;
using CodingConnected.TraCI.NET.Response;

namespace CodingConnected.TraCI.NET;

public class TraCIResult
    {
    public int Length { get; set; }
    public byte Identifier { get; set; }
    public byte[] Response { get; set; }
    }


/// <summary>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#status_response"/>
/// </summary>
public class TraCIStatusResponse : TraCIResult
    {
    public ResultCode Result => (ResultCode)Response[0];
    public int DescriptionLength => BitConverter.ToInt32(Response.Take(4).ToArray());
    public string Description => Encoding.ASCII.GetString(Response.Skip(1 + 4).Take(DescriptionLength).ToArray());
    }