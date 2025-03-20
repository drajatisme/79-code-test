using Microsoft.AspNetCore.SignalR;

namespace Skeleton.HubServer.Hubs;

public class NotificationHub : Hub
{
    private readonly ILogger<NotificationHub> _logger;

    public NotificationHub(ILogger<NotificationHub> logger)
    {
        _logger = logger;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"OnConnectedAsync: {Context.User?.Identity?.Name}");

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"OnDisconnectedAsync: {Context.User?.Identity?.Name}");
        return base.OnDisconnectedAsync(exception);
    }

    public async Task SendNotification(string message)
    {
        await Clients.All.SendAsync("NotificationReceived", message);
    }
}