using FluentValidation;
using Skeleton.Application.Common;
using Skeleton.Application.Services.Lov;

namespace Skeleton.Application.Services.Item;

public class CreateItemRequest : BaseRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public LovDto<int>? Category { get; set; }
}

public class CreateItemRequestValidator : BaseValidator<CreateItemRequest>
{
    public CreateItemRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Category).NotEmpty();
    }
}