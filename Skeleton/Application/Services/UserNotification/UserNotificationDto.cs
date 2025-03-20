using Skeleton.Application.Common;

namespace Skeleton.Application.Services.UserNotification;

public class UserNotificationDto : BaseDto
{
    public int Id { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public required bool Read { get; set; }
}