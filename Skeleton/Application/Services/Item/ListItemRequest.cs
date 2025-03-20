using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Item;

public class ListItemRequest : PaginationBaseRequest;

public class ListItemRequestValidator : BaseValidator<ListItemRequest>;