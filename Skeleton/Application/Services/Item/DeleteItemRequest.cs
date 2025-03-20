using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Item;

public class DeleteItemRequest : UpdateItemRequest
{
}

public class DeleteItemRequestValidator : BaseValidator<DeleteItemRequest>
{
    public DeleteItemRequestValidator()
    {
        Include(new UpdateItemRequestValidator());
    }
}