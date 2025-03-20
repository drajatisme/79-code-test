using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Skeleton.Application.Common;

namespace Skeleton.Application;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        Response errorResponse;
        // Details = exception.StackTrace

        switch (exception)
        {
            case OperationCanceledException:
                errorResponse = new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Client closed request."
                };
                response.StatusCode = (int)errorResponse.Status;
                break;
            case ValidationException validationException:
                errorResponse = new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Validation failed",
                    Errors = validationException.Errors.Select(s => s.ErrorMessage).ToList()
                };
                response.StatusCode = (int)errorResponse.Status;
                break;
            case ArgumentException:
                errorResponse = new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = exception.Message,
                };
                response.StatusCode = (int)errorResponse.Status;
                break;
            case UnauthorizedAccessException:
                errorResponse = new Response
                {
                    Status = HttpStatusCode.Unauthorized,
                    Message = "Unauthorized access",
                };
                response.StatusCode = (int)errorResponse.Status;
                break;
            default:
                errorResponse = new Response
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = exception.Message,
                };
                response.StatusCode = (int)errorResponse.Status;
                break;
        }

        var json = JsonSerializer.Serialize(errorResponse);
        return response.WriteAsync(json);
    }
}