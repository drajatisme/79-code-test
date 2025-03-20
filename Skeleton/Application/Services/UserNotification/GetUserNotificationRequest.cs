using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.UserNotification;

public class GetUserNotificationRequest : BaseRequest
{
    public required int Id { get; set; }
}

public class GetUserNotificationRequestValidator : BaseValidator<GetUserNotificationRequest>
{
    public GetUserNotificationRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}