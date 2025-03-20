using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Item;

public class GetItemServiceHandler : IServiceHandler<GetItemRequest, ItemDto>
{
    private readonly ApplicationDbContext _context;

    public GetItemServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public Response<ItemDto> Handle(GetItemRequest request)
    {
        var query = _context.Items.AsNoTracking();

        var data = query
            .Where(w => w.Id == request.Id)
            .Select(s => new ItemDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ItemCategoryId = s.ItemCategoryId,
                ItemCategoryName = s.ItemCategory!.Name
            })
            .SingleOrDefault() ?? throw new NullReferenceException("Item");

        var response = new Response<ItemDto>().Ok(data);

        return response;
    }
}