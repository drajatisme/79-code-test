using Skeleton.Application.Common;

namespace Skeleton.Application.Services.ItemCategory;

public class DeleteItemCategoryRequest : UpdateItemCategoryRequest
{
}

public class DeleteItemCategoryRequestValidator : BaseValidator<DeleteItemCategoryRequest>
{
    public DeleteItemCategoryRequestValidator()
    {
        Include(new UpdateItemCategoryRequestValidator());
    }
}