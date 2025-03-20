using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Skeleton.Application.Services.Lov;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddLovServices(this IServiceCollection services)
    {
        services
            .AddScoped<IListServiceHandler<GetItemCategoryLovRequest, LovDto<int>>,
                GetItemCategoryLovServiceHandler>();

        services.AddScoped<IValidator<GetItemCategoryLovRequest>, GetItemCategoryLovRequestValidator>();

        return services;
    }
}