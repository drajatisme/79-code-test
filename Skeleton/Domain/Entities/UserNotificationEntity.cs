namespace Skeleton.Domain.Entities;

public class UserNotificationEntity
{
    public int Id { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public bool Read { get; set; }

    public required string UserId { get; set; }
    public UserEntity? User { get; set; }
    public DateTime? CreatedAt { get; set; }
}