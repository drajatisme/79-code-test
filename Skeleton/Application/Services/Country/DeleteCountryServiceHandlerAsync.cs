using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Country;

public class DeleteCountryServiceHandlerAsync : IServiceHandlerAsync<DeleteCountryRequest>
{
    private readonly ApplicationDbContext _context;

    public DeleteCountryServiceHandlerAsync(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Response> HandleAsync(DeleteCountryRequest request, CancellationToken cancellationToken)
    {
        var data = await _context.Countries
                       .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ??
                   throw new NullReferenceException("Country");

        _context.Countries.Remove(data);

        await _context.SaveChangesAsync(cancellationToken);

        return new Response().Ok();
    }
}