using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Item;

public class GetItemRequest : BaseRequest
{
    public required int Id { get; set; }
}

public class GetItemRequestValidator : BaseValidator<GetItemRequest>
{
    public GetItemRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}