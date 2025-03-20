using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Skeleton.Application.Common;
using Skeleton.Domain.Entities;

namespace Skeleton.Application.Services.Token;

public class GetTokenServiceHandler : IServiceHandler<GetTokenRequest, TokenDto>
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly ConfigurationWrapper _configuration;

    public GetTokenServiceHandler(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, ConfigurationWrapper configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public Response<TokenDto> Handle(GetTokenRequest request)
    {
        var user = _userManager.FindByEmailAsync(request.Username).GetAwaiter().GetResult();
        if (user == null || !_userManager.CheckPasswordAsync(user, request.Password).GetAwaiter().GetResult())
            throw new UnauthorizedAccessException();

        var token = GenerateJwtToken(user);
        var data = new TokenDto
        {
            AccessToken = token,
        };

        var response = new Response<TokenDto>().Ok(data);
        return response;
    }

    private string GenerateJwtToken(UserEntity user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Jwt.Secret)), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration.Jwt.Issuer,
            audience: _configuration.Jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}