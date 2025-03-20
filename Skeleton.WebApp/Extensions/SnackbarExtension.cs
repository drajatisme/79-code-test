using MudBlazor;

namespace Skeleton.WebApp.Extensions;

public static class SnackbarExtension
{
    public static void AddCreated(this ISnackbar snackbar, string? message)
    {
        snackbar.Add(message ?? "Created", Severity.Success,
            options => { options.Icon = Icons.Material.Filled.CheckCircleOutline; });
    }

    public static void AddUpdated(this ISnackbar snackbar, string? message)
    {
        snackbar.Add(message ?? "Updated", Severity.Warning,
            options => { options.Icon = Icons.Material.Filled.CheckCircleOutline; });
    }

    public static void AddDeleted(this ISnackbar snackbar, string? message)
    {
        snackbar.Add(message ?? "Deleted", Severity.Error,
            options => { options.Icon = Icons.Material.Filled.CheckCircleOutline; });
    }

    public static void AddFailed(this ISnackbar snackbar, string? message)
    {
        snackbar.Add(message ?? "Failed", Severity.Error);
    }
}