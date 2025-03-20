using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Country;

public class DeleteCountryRequest : BaseRequest
{
    public required int Id { get; set; }
}

public class DeleteCountryRequestValidator : BaseValidator<DeleteCountryRequest>
{
    public DeleteCountryRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}