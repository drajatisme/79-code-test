using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.ItemCategory;

public class ListItemCategoryServiceHandler : IListServiceHandler<ListItemCategoryRequest, ItemCategoryDto>
{
    private readonly ApplicationDbContext _context;

    public ListItemCategoryServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public ResponseList<ItemCategoryDto> Handle(ListItemCategoryRequest request)
    {
        var query = _context.ItemCategories.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
            query = query.Where(w => w.Name != null && w.Name.ToLower().Contains(request.SearchKeyword.ToLower()));

        var total = query.Count();

        var data = query
            .Select(s => new ItemCategoryDto { Id = s.Id, Name = s.Name, Description = s.Description })
            .ToList();

        var response = new ResponseList<ItemCategoryDto>().Ok(data);
        response.SetPagination(request.Page, request.Size, total);

        return response;
    }
}