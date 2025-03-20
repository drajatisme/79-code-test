using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Country;

public class UpdateCountryServiceHandlerAsync : IServiceHandlerAsync<UpdateCountryRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public UpdateCountryServiceHandlerAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public async Task<Response> HandleAsync(UpdateCountryRequest request, CancellationToken cancellationToken)
    {
        var validator = _serviceProvider.GetService<IValidator<UpdateCountryRequest>>();
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var codeExist =
            await _context.Countries.AnyAsync(
                a => request.CountryCode.Equals(a.Code, StringComparison.OrdinalIgnoreCase), cancellationToken);

        var data = await _context.Countries
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ?? throw new NullReferenceException("Country");

        if (codeExist && !request.CountryCode.Equals(data.Code, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException(string.Format(ErrorMessages.DataExist, request.CountryCode));

        data.Code = request.CountryCode.ToUpper();
        data.Name = request.CountryName.ToUpper();
        data.UpdatedBy = request.CurrentUserId;
        data.UpdatedAt = request.CurrentDateTime;

        await _context.SaveChangesAsync(cancellationToken);

        return new Response().Ok();
    }
}