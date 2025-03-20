using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Country;

public class GetCountryServiceHandlerAsync : IServiceHandlerAsync<GetCountryRequest, CountryDto>
{
    private readonly ApplicationDbContext _context;

    public GetCountryServiceHandlerAsync(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Response<CountryDto>> HandleAsync(GetCountryRequest request, CancellationToken cancellationToken)
    {
        var query = _context.Countries.AsNoTracking();

        var data = await query
            .Where(w => w.Id == request.Id)
            .Select(s => new CountryDto
            {
                Id = s.Id,
                CountryCode = s.Code,
                CountryName = s.Name,
                CreatedBy = s.CreatedBy,
                CreatedAt = s.CreatedAt,
                UpdateBy = s.UpdatedBy,
                UpdateAt = s.UpdatedAt,
            })
            .SingleOrDefaultAsync(cancellationToken) ?? throw new NullReferenceException("Country");

        var response = new Response<CountryDto>().Ok(data);

        return response;
    }
}