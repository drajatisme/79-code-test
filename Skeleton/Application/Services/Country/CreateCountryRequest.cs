using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Country;

public class CreateCountryRequest : BaseRequest
{
    public required string CountryCode { get; set; }
    public required string CountryName { get; set; }
}

public class CreateCountryRequestValidator : BaseValidator<CreateCountryRequest>
{
    public CreateCountryRequestValidator()
    {
        RuleFor(x => x.CountryCode).NotEmpty().MaximumLength(3);
        RuleFor(x => x.CountryName).NotEmpty().MaximumLength(100);
    }
}