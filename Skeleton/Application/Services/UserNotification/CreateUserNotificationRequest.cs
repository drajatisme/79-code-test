using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.UserNotification;

public class CreateUserNotificationRequest : BaseRequest
{
    public required string Subject { get; set; }
    public required string Body { get; set; }
}

public class CreateUserNotificationRequestValidator : BaseValidator<CreateUserNotificationRequest>
{
    public CreateUserNotificationRequestValidator()
    {
        RuleFor(x => x.Subject).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Body).MaximumLength(5000);
    }
}