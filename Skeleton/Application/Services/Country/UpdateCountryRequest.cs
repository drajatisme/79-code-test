using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Country;

public class UpdateCountryRequest : CreateCountryRequest
{
    public required int Id { get; set; }
}

public class UpdateCountryRequestValidator : BaseValidator<UpdateCountryRequest>
{
    public UpdateCountryRequestValidator()
    {
        Include(new CreateCountryRequestValidator());
        RuleFor(x => x.Id).NotEmpty();
    }
}