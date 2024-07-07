namespace BluDay.Net.Services;

/// <summary>
/// A service that manages the theme state of an app.
/// </summary>
public sealed class AppThemeService
{
    private readonly WeakReferenceMessenger _messenger;

    /// <summary>
    /// Gets the current theme.
    /// </summary>
    public AppTheme CurrentTheme { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppThemeService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppThemeService(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;
    }
}