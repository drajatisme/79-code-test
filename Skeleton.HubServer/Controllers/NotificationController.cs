using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Skeleton.HubServer.Hubs;

namespace Skeleton.HubServer.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationController(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpGet]
    public async Task<IActionResult> Send(string? message = null)
    {
        await _hubContext.Clients.All.SendAsync("NotificationReceived", message);
        return Ok();
    }
}