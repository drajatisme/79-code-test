using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.ItemCategory;

public class UpdateItemCategoryRequest : CreateItemCategoryRequest
{
    public required int Id { get; set; }
}

public class UpdateItemCategoryRequestValidator : BaseValidator<UpdateItemCategoryRequest>
{
    public UpdateItemCategoryRequestValidator()
    {
        Include(new CreateItemCategoryRequestValidator());
        RuleFor(x => x.Id).NotEmpty();
    }
}