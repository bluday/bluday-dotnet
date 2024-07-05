namespace BluDay.Net.Services;

public sealed class AppThemeService : IAppThemeService
{
    private readonly WeakReferenceMessenger _messenger;

    public AppTheme CurrentTheme { get; set; }

    public AppThemeService(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;
    }
}