using System.Text.Json.Serialization;

namespace Skeleton.Application.Common;

public abstract class BaseRequest
{
    [JsonIgnore]
    public string? CurrentUserId { get; set; }
    public DateTime CurrentDateTime => DateTime.UtcNow;
}

public class PaginationBaseRequest : BaseRequest
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public int Offset => Page < 1 ? 0 : (Page - 1) * Size;

    public string? SearchKeyword { get; set; }
}