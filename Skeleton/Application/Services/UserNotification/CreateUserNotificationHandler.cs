using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Application.Common;
using Skeleton.Domain.Entities;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.UserNotification;

public class CreateUserNotificationHandler : IServiceHandler<CreateUserNotificationRequest>
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public CreateUserNotificationHandler(ApplicationDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public Response Handle(CreateUserNotificationRequest request)
    {
        var validator = _serviceProvider.GetService<IValidator<CreateUserNotificationRequest>>();
        validator.ValidateAndThrow(request);

        _context.UserNotifications.Add(new UserNotificationEntity
        {
            Subject = request.Subject,
            Body = request.Body,
            UserId = request.CurrentUserId
        });

        _context.SaveChanges();

        return new Response().Ok();
    }
}