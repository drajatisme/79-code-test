using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Item;

public class UpdateItemRequest : CreateItemRequest
{
    public required int Id { get; set; }
}

public class UpdateItemRequestValidator : BaseValidator<UpdateItemRequest>
{
    public UpdateItemRequestValidator()
    {
        Include(new CreateItemRequestValidator());
        RuleFor(x => x.Id).NotEmpty();
    }
}