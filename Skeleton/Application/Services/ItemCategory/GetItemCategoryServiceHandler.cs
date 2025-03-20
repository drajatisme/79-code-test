using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.ItemCategory;

public class GetItemCategoryServiceHandler : IServiceHandler<GetItemCategoryRequest, ItemCategoryDto>
{
    private readonly ApplicationDbContext _context;

    public GetItemCategoryServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public Response<ItemCategoryDto> Handle(GetItemCategoryRequest request)
    {
        var query = _context.ItemCategories.AsNoTracking();

        var data = query
            .Where(w => w.Id == request.Id)
            .Select(s => new ItemCategoryDto { Id = s.Id, Name = s.Name, Description = s.Description })
            .SingleOrDefault() ?? throw new NullReferenceException("Item Category");

        var response = new Response<ItemCategoryDto>().Ok(data);

        return response;
    }
}