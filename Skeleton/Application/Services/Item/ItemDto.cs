using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Item;

public class ItemDto : BaseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ItemCategoryId { get; set; }
    public string? ItemCategoryName { get; set; }
}