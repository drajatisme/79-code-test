using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Skeleton.Application.Services.ItemCategory;

public  static class IServiceCollectionExtension
{
    public static IServiceCollection AddItemCategoryServices(this IServiceCollection services)
    {
        services
            .AddScoped<IListServiceHandler<ListItemCategoryRequest, ItemCategoryDto>,
                ListItemCategoryServiceHandler>();
        services
            .AddScoped<IServiceHandler<GetItemCategoryRequest, ItemCategoryDto>,
                GetItemCategoryServiceHandler>();
        services
            .AddScoped<IServiceHandler<CreateItemCategoryRequest>,
                CreateItemCategoryServiceHandler>();
        services
            .AddScoped<IServiceHandler<DeleteItemCategoryRequest>,
                DeleteItemCategoryServiceHandler>();
        services
            .AddScoped<IServiceHandler<UpdateItemCategoryRequest>,
                UpdateItemCategoryServiceHandler>();

        services.AddScoped<IValidator<ListItemCategoryRequest>, ListItemCategoryRequestValidator>();
        services.AddScoped<IValidator<GetItemCategoryRequest>, GetItemCategoryRequestValidator>();
        services.AddScoped<IValidator<UpdateItemCategoryRequest>, UpdateItemCategoryRequestValidator>();
        services.AddScoped<IValidator<DeleteItemCategoryRequest>, DeleteItemCategoryRequestValidator>();
        
        return services;
    }
}