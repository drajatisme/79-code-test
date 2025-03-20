using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Skeleton.Application.Services.Health;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddHealthServices(this IServiceCollection services)
    {
        services
            .AddScoped<IListServiceHandlerAsync<GetHealthRequest, HealthDto>,
                GetHealthServiceHandlerAsync>();

        services.AddScoped<IValidator<GetHealthRequest>, GetHealthRequestValidator>();

        return services;
    }
}