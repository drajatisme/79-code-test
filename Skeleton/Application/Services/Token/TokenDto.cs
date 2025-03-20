using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Token;

public class TokenDto : BaseDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}