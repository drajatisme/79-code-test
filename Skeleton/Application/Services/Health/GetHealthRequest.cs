using FluentValidation;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Health;

public class GetHealthRequest : BaseRequest;

public class GetHealthRequestValidator : AbstractValidator<GetHealthRequest>;
