namespace Skeleton.Domain.Entities;

public class ItemCategoryEntity : ICreateAuditable, IUpdateAuditable
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<ItemEntity>? Items { get; set; }

    public string? CreatedBy { get; set; }
    public UserEntity? CreatedUser { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public UserEntity? UpdatedUser { get; set; }
    public DateTime? UpdatedAt { get; set; }
}