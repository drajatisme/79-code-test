using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common;
using Skeleton.Infrastructure.Data;

namespace Skeleton.Application.Services.UserNotification;

public class ListUserNotificationServiceHandler : IListServiceHandler<ListUserNotificationRequest, UserNotificationDto>
{
    private readonly ApplicationDbContext _context;

    public ListUserNotificationServiceHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public ResponseList<UserNotificationDto> Handle(ListUserNotificationRequest request)
    {
        var query = _context.UserNotifications.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
            query = query.Where(w => w.Subject.ToLower().Contains(request.SearchKeyword.ToLower()));

        var total = query.Count();

        var data = query
            .Select(s => new UserNotificationDto { Id = s.Id, Subject = s.Subject, Body = s.Body, Read = s.Read })
            .ToList();

        var response = new ResponseList<UserNotificationDto>().Ok(data);
        response.SetPagination(request.Page, request.Size, total);

        return response;
    }
}