using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Health;

public class HealthDto : BaseDto
{
    public required string Name { get; set; }
    public required string Status { get; set; }
    public required double Duration { get; set; }
}