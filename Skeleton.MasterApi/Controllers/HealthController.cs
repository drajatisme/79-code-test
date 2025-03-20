using Microsoft.AspNetCore.Mvc;
using Skeleton.Application.Services;
using Skeleton.Application.Services.Health;

namespace Skeleton.MasterApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetHealth(
        [FromServices] IListServiceHandlerAsync<GetHealthRequest, HealthDto> service,
        CancellationToken cancellationToken)
    {
        var response = await service.HandleAsync(new GetHealthRequest(), cancellationToken);
        return StatusCode((int)response.Status, response);
    }
}