using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Skeleton.Application.Services.Token;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddTokenServices(this IServiceCollection services)
    {
        services
            .AddScoped<IServiceHandler<GetTokenRequest, TokenDto>,
                GetTokenServiceHandler>();

        services.AddScoped<IValidator<GetTokenRequest>, GetTokenRequestValidator>();

        return services;
    }
}