namespace Skeleton.Domain.Entities;

public interface ICreateAuditable
{
    public string? CreatedBy { get; set; }
    public UserEntity? CreatedUser { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public interface IUpdateAuditable
{
    public string? UpdatedBy { get; set; }
    public UserEntity? UpdatedUser { get; set; }
    public DateTime? UpdatedAt { get; set; }
}