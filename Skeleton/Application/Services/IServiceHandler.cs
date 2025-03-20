using Skeleton.Application.Common;

namespace Skeleton.Application.Services;

public interface IServiceHandler<TRequest> where TRequest : BaseRequest
{
    Response Handle(TRequest request);
}

public interface IServiceHandlerAsync<TRequest> where TRequest : BaseRequest
{
    Task<Response> HandleAsync(TRequest request, CancellationToken cancellationToken);
}


public interface IServiceHandler<TRequest, TDto> where TRequest : BaseRequest where TDto : BaseDto
{
    Response<TDto> Handle(TRequest request);
}

public interface IServiceHandlerAsync<TRequest, TDto> where TRequest : BaseRequest where TDto : BaseDto
{
    Task<Response<TDto>> HandleAsync(TRequest request, CancellationToken cancellationToken);
}

public interface IListServiceHandler<TRequest, TDto> where TRequest : BaseRequest where TDto : BaseDto
{
    ResponseList<TDto> Handle(TRequest request);
}

public interface IListServiceHandlerAsync<TRequest, TDto> where TRequest : BaseRequest where TDto : BaseDto
{
    Task<ResponseList<TDto>> HandleAsync(TRequest request, CancellationToken cancellationToken);
}