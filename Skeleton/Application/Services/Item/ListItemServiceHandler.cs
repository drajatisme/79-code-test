using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Item;

public class ListItemServiceHandler : IListServiceHandler<ListItemRequest, ItemDto>
{
    private readonly ApplicationDbContext _context;

    public ListItemServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public ResponseList<ItemDto> Handle(ListItemRequest request)
    {
        var query = _context.Items.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
            query = query.Where(w => w.Name != null && w.Name.ToLower().Contains(request.SearchKeyword.ToLower()));

        var total = query.Count();

        var data = query
            .Select(s => new ItemDto
            {
                Id = s.Id, Name = s.Name, Description = s.Description, ItemCategoryId = s.ItemCategoryId,
                ItemCategoryName = s.ItemCategory!.Name
            })
            .ToList();

        var response = new ResponseList<ItemDto>().Ok(data);
        response.SetPagination(request.Page, request.Size, total);

        return response;
    }
}