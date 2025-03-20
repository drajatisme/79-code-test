using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Skeleton.Application.Services.UserNotification;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddUserNotificationServices(this IServiceCollection services)
    {
        services
            .AddScoped<IListServiceHandler<ListUserNotificationRequest, UserNotificationDto>,
                ListUserNotificationServiceHandler>();
        
        services
            .AddScoped<IServiceHandler<GetUserNotificationRequest, UserNotificationDto>,
                GetUserNotificationServiceHandler>();


        services.AddScoped<IValidator<GetUserNotificationRequest>, GetUserNotificationRequestValidator>();
        services.AddScoped<IValidator<ListUserNotificationRequest>, ListUserNotificationRequestValidator>();

        return services;
    }
}