namespace BluDay.Net.Services;

/// <inheritdoc cref="IAppWindowService"/>
public sealed class AppThemeService : Service,
    IAppThemeService,
    IRecipient<AppThemeChangeMessage>
{
    private AppTheme _currentTheme;

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
    /// Initializes a new instance of the <see cref="IAppThemeService"/> class.
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