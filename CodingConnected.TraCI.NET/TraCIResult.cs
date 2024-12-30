using System.Text;
using CodingConnected.TraCI.NET.Response;

namespace CodingConnected.TraCI.NET;

public class TraCIResult : IStatusResponse
    {
    /// <summary>
    /// The length of the content
    /// </summary>
    public int ContentLength { get; set; }
    public byte Identifier { get; set; }
    public byte[] Response { get; set; }

    ResultCode IStatusResponse.Result => (ResultCode)Response[0];

    int IStatusResponse.DescriptionLength => BitConverter.ToInt32(Response.Take(4).ToArray());

    string IStatusResponse.Description => Encoding.ASCII.GetString(Response.Skip(1 + 4).Take(((IStatusResponse)this).DescriptionLength).ToArray());
    }

/// <summary>
/// see <see href="https://sumo.dlr.de/docs/TraCI/Protocol.html#status_response"/>
/// </summary>
public interface IStatusResponse
    {
    public ResultCode Result { get; }
    public int DescriptionLength { get; }
    public string Description { get; }
    }

