using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Skeleton.Application.Services.Country;

public  static class IServiceCollectionExtension
{
    public static IServiceCollection AddCountryServices(this IServiceCollection services)
    {
        services
            .AddScoped<IListServiceHandlerAsync<ListCountryRequest, CountryDto>,
                ListCountryServiceHandlerAsync>();
        services
            .AddScoped<IServiceHandlerAsync<GetCountryRequest, CountryDto>,
                GetCountryServiceHandlerAsync>();
        services
            .AddScoped<IServiceHandlerAsync<CreateCountryRequest>,
                CreateCountryServiceHandlerAsync>();
        services
            .AddScoped<IServiceHandlerAsync<DeleteCountryRequest>,
                DeleteCountryServiceHandlerAsync>();
        services
            .AddScoped<IServiceHandlerAsync<UpdateCountryRequest>,
                UpdateCountryServiceHandlerAsync>();

        services.AddScoped<IValidator<GetCountryRequest>, GetCountryRequestValidator>();
        services.AddScoped<IValidator<ListCountryRequest>, ListCountryRequestValidator>();
        services.AddScoped<IValidator<CreateCountryRequest>, CreateCountryRequestValidator>();
        services.AddScoped<IValidator<UpdateCountryRequest>, UpdateCountryRequestValidator>();
        services.AddScoped<IValidator<DeleteCountryRequest>, DeleteCountryRequestValidator>();
        
        return services;
    }
}