using Skeleton.Application.Common;

namespace Skeleton.Application.Services.ItemCategory;

public class ItemCategoryDto : BaseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}