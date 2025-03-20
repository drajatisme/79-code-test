using Microsoft.AspNetCore.Components;
using Skeleton.WebApp.Services;

namespace Skeleton.WebApp.Common;

public abstract class MyComponentBase : ComponentBase, IAsyncDisposable
{
    protected bool FirstRender;
    protected bool OnLoading;

    [Inject] private ILifecycleLogger Logger { get; set; } = default!;

    private string? ComponentName => GetType().FullName;

    public virtual async ValueTask DisposeAsync()
    {
        Logger.Log(ComponentName, "DisposeAsync", "Component is being disposed");
        await Task.CompletedTask;
    }

    protected override void OnInitialized()
    {
        Logger.Log(ComponentName, "OnInitialized");
    }

    protected override async Task OnInitializedAsync()
    {
        Logger.Log(ComponentName, "OnInitializedAsync");
        await Task.CompletedTask;
    }

    protected override void OnParametersSet()
    {
        Logger.Log(ComponentName, "OnParametersSet");
    }

    protected override async Task OnParametersSetAsync()
    {
        Logger.Log(ComponentName, "OnParametersSetAsync");
        await Task.CompletedTask;
    }

    protected override bool ShouldRender()
    {
        Logger.Log(ComponentName, "ShouldRender");
        return true;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        Logger.Log(ComponentName, "OnAfterRender", $"FirstRender: {firstRender}");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        Logger.Log(ComponentName, "OnAfterRenderAsync", $"FirstRender: {firstRender}");
        await Task.CompletedTask;
    }
}