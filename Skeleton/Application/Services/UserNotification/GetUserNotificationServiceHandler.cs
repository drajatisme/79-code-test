using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.UserNotification;

public class GetUserNotificationServiceHandler : IServiceHandler<GetUserNotificationRequest, UserNotificationDto>
{
    private readonly ApplicationDbContext _context;

    public GetUserNotificationServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public Response<UserNotificationDto> Handle(GetUserNotificationRequest request)
    {
        var query = _context.UserNotifications.AsNoTracking();

        var data = query
            .Where(w => w.Id == request.Id)
            .Select(s => new UserNotificationDto { Id = s.Id, Subject = s.Subject, Body = s.Body, Read = s.Read })
            .SingleOrDefault() ?? throw new NullReferenceException("User Notification");

        var response = new Response<UserNotificationDto>().Ok(data);

        return response;
    }
}