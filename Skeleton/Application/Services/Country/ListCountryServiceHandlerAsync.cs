using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Country;

public class ListCountryServiceHandlerAsync : IListServiceHandlerAsync<ListCountryRequest, CountryDto>
{
    private readonly ApplicationDbContext _context;

    public ListCountryServiceHandlerAsync(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseList<CountryDto>> HandleAsync(ListCountryRequest request, CancellationToken cancellationToken)
    {
        var query = _context.Countries.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
            query = query.Where(w => w.Name != null && w.Name.ToLower().Contains(request.SearchKeyword.ToLower()));

        var total = await query.CountAsync(cancellationToken);
        
        var data = await query
            .Skip(request.Offset)
            .Take(request.Size)
            .Select(s => new CountryDto { Id = s.Id, CountryCode = s.Code, CountryName = s.Name })
            .ToListAsync(cancellationToken);

        var response = new ResponseList<CountryDto>().Ok(data);
        response.SetPagination(request.Page, request.Size, total);

        return response;
    }
}