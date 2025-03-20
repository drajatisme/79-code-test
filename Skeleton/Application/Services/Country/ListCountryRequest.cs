using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Country;

public class ListCountryRequest : PaginationBaseRequest;

public class ListCountryRequestValidator : BaseValidator<ListCountryRequest>;
