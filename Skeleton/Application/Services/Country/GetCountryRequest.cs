using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Country;

public class GetCountryRequest : BaseRequest
{
    public required int Id { get; set; }
}

public class GetCountryRequestValidator : BaseValidator<GetCountryRequest>
{
    public GetCountryRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}