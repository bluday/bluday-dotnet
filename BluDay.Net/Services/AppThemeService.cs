namespace BluDay.Net.Services;

/// <summary>
/// A service that manages the theme state of an app.
/// </summary>
public sealed class AppThemeService : Service, IRecipient<AppThemeChangeMessage>
{
    private AppTheme _currentTheme;

    /// <summary>
    /// Gets the current theme.
    /// </summary>
    public AppTheme CurrentTheme
    {
        get => _currentTheme;
        set
        {
            _currentTheme = value;

            _messenger.Send(new AppThemeChangedMessage(value));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppThemeService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppThemeService(WeakReferenceMessenger messenger) : base(messenger) { }

    public void Receive(AppThemeChangeMessage message)
    {
        CurrentTheme = message.Value;
    }
}