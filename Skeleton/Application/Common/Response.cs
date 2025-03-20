using System.Net;

namespace Skeleton.Application.Common;

public class Response
{
    public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;
    public string? Message { get; set; } = HttpStatusCode.InternalServerError.ToString();
    public bool Succeeded => Errors.Count == 0 && Status == HttpStatusCode.OK;
    public List<string> Errors { get; set; } = [];

    public Response Ok()
    {
        Status = HttpStatusCode.OK;
        Message = HttpStatusCode.OK.ToString();

        return this;
    }

    public Response BadRequest()
    {
        Status = HttpStatusCode.BadRequest;
        Message = HttpStatusCode.BadRequest.ToString();

        return this;
    }
}

public class Response<TDto> : Response where TDto : BaseDto
{
    public TDto? Data { get; set; }

    public Response<TDto> Ok(TDto? data = null)
    {
        Status = HttpStatusCode.OK;
        Message = HttpStatusCode.OK.ToString();
        Data = data;

        return this;
    }
}

public class ResponseList<TDto> : Response where TDto : BaseDto
{
    public List<TDto>? Data { get; set; }
    public PaginationContainer? Pagination { get; set; }


    public ResponseList<TDto> Ok(List<TDto>? data = null)
    {
        Status = HttpStatusCode.OK;
        Message = HttpStatusCode.OK.ToString();
        Data = data;

        return this;
    }

    public ResponseList<TDto> SetPagination(int page, int size, int total)
    {
        Pagination = new PaginationContainer
        {
            Page = page,
            Size = size,
            TotalData = total
        };

        return this;
    }
}

public class PaginationContainer
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;

    public int TotalData { get; set; }
    public int TotalPages => Size == 0 ? 1 : (int)Math.Ceiling((double)TotalData / Size);

    public bool HasPrevious => Page > 1;
    public bool HasNext => Page < TotalPages;

}