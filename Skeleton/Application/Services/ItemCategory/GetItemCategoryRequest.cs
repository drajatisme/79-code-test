using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.ItemCategory;

public class GetItemCategoryRequest : BaseRequest
{
    public required int Id { get; set; }
}

public class GetItemCategoryRequestValidator : BaseValidator<GetItemCategoryRequest>
{
    public GetItemCategoryRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}