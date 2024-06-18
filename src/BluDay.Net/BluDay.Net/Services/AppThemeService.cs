namespace BluDay.Net.Services;

public sealed class AppThemeService : IAppThemeService
{
    private readonly IMessenger _messenger;

    public AppTheme CurrentTheme { get; set; }

    public AppThemeService(IMessenger messenger)
    {
        _messenger = messenger;
    }
}