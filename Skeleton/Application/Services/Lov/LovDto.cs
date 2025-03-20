using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Lov;

public class LovDto<TValue> : BaseDto
{
    public TValue? Value { get; set; }
    public string? Text { get; set; }
}