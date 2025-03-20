using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Skeleton.Application.Services.Item;

public  static class IServiceCollectionExtension
{
    public static IServiceCollection AddItemServices(this IServiceCollection services)
    {
        services
            .AddScoped<IListServiceHandler<ListItemRequest, ItemDto>,
                ListItemServiceHandler>();
        services
            .AddScoped<IServiceHandler<GetItemRequest, ItemDto>,
                GetItemServiceHandler>();
        services
            .AddScoped<IServiceHandler<CreateItemRequest>,
                CreateItemServiceHandler>();
        services
            .AddScoped<IServiceHandler<DeleteItemRequest>,
                DeleteItemServiceHandler>();
        services
            .AddScoped<IServiceHandler<UpdateItemRequest>,
                UpdateItemServiceHandler>();

        services.AddScoped<IValidator<ListItemRequest>, ListItemRequestValidator>();
        services.AddScoped<IValidator<GetItemRequest>, GetItemRequestValidator>();
        services.AddScoped<IValidator<UpdateItemRequest>, UpdateItemRequestValidator>();
        services.AddScoped<IValidator<DeleteItemRequest>, DeleteItemRequestValidator>();
        
        return services;
    }
}