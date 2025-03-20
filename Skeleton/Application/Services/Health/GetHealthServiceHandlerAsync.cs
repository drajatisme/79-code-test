using System.Net;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Health;

public class GetHealthServiceHandlerAsync : IListServiceHandlerAsync<GetHealthRequest, HealthDto>
{
    private readonly HealthCheckService _healthCheckService;

    public GetHealthServiceHandlerAsync(HealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
    }

    public async Task<ResponseList<HealthDto>> HandleAsync(GetHealthRequest request, CancellationToken cancellationToken = default)
    {
        var report = await _healthCheckService.CheckHealthAsync(cancellationToken);
        
        var status = report.Status == HealthStatus.Healthy ? HttpStatusCode.OK : HttpStatusCode.ServiceUnavailable;

        var data = report.Entries.Select(e => new HealthDto
        {
            Name = e.Key,
            Status = e.Value.Status.ToString(),
            Duration = e.Value.Duration.TotalMilliseconds
        }).ToList();

        var response = new ResponseList<HealthDto>
        {
            Status = status,
            Message = status.ToString(),
            Data = data
        };

        return response;
    }
}