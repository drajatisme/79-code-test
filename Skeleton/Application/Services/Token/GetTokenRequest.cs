using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Token;

public class GetTokenRequest : BaseRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class GetTokenRequestValidator : AbstractValidator<GetTokenRequest>
{
    public GetTokenRequestValidator()
    {
        RuleFor(x => x.Username).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}