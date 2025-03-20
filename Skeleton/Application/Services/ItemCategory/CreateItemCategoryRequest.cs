using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.ItemCategory;

public class CreateItemCategoryRequest : BaseRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class CreateItemCategoryRequestValidator : BaseValidator<CreateItemCategoryRequest>
{
    public CreateItemCategoryRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Description).MaximumLength(100);
    }
}