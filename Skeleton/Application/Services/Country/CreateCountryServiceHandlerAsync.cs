using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Common;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.Country;

public class CreateCountryServiceHandlerAsync : IServiceHandlerAsync<CreateCountryRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public CreateCountryServiceHandlerAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public async Task<Response> HandleAsync(CreateCountryRequest request, CancellationToken cancellationToken)
    {
        var validator = _serviceProvider.GetService<IValidator<CreateCountryRequest>>();
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var codeExist =
            await _context.Countries.AnyAsync(
                a => request.CountryCode.Equals(a.Code, StringComparison.OrdinalIgnoreCase), cancellationToken);

        if (codeExist)
            throw new InvalidOperationException(string.Format(ErrorMessages.DataExist, request.CountryCode));

        _context.Countries.Add(new CountryEntity
        {
            Code = request.CountryCode.ToUpper(),
            Name = request.CountryName.ToUpper(),
            CreatedAt = request.CurrentDateTime,
            CreatedBy = request.CurrentUserId,
            UpdatedAt = request.CurrentDateTime,
            UpdatedBy = request.CurrentUserId
        });

        await _context.SaveChangesAsync(cancellationToken);

        return new Response().Ok();
    }
}