using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Lov;

public class GetItemCategoryLovServiceHandler : IListServiceHandler<GetItemCategoryLovRequest, LovDto<int>>
{
    private readonly ApplicationDbContext _context;

    public GetItemCategoryLovServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public ResponseList<LovDto<int>> Handle(GetItemCategoryLovRequest lovRequest)
    {
        var query = _context.ItemCategories.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(lovRequest.SearchKeyword))
        {
            query = query.Where(i => i.Name.Contains(lovRequest.SearchKeyword));
        }

        var data = query
            .Select(s => new LovDto<int>
            {
                Value = s.Id,
                Text = s.Name
            })
            .ToList() ?? throw new Exception();

        var response = new ResponseList<LovDto<int>>().Ok(data);

        return response;
    }
}