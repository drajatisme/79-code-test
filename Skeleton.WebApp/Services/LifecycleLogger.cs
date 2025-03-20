namespace Skeleton.WebApp.Services;

public interface ILifecycleLogger
{
    void Log(string? componentName, string eventName, string details = "");
}

public class LifecycleLogger : ILifecycleLogger
{
    private readonly ILogger<LifecycleLogger> _logger;

    public LifecycleLogger(ILogger<LifecycleLogger> logger)
    {
        _logger = logger;
    }

    public void Log(string? componentName, string eventName, string details = "")
    {
#if DEBUG
        var message = $"[{DateTime.UtcNow}] {componentName} - {eventName} {details}";
        _logger.LogInformation(message.TrimEnd());
        // Console.WriteLine($"[{DateTime.UtcNow}] {componentName} - {eventName} {details}");
#endif
    }
}