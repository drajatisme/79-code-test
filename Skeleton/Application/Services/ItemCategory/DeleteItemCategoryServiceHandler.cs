using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.ItemCategory;

public class DeleteItemCategoryServiceHandler : IServiceHandler<DeleteItemCategoryRequest>
{
    private readonly ApplicationDbContext _context;

    public DeleteItemCategoryServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public Response Handle(DeleteItemCategoryRequest request)
    {
        var data = _context.ItemCategories
            .FirstOrDefault(x => x.Id == request.Id) ?? throw new NullReferenceException("Item Category");

        _context.ItemCategories.Remove(data);

        _context.SaveChanges();
        return new Response().Ok();
    }
}