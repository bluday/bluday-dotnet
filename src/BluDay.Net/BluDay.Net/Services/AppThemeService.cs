namespace BluDay.Net.Services;

/// <summary>
/// A service that manages the theme state of an app.
/// </summary>
public sealed class AppThemeService : Service, IRecipient<AppThemeChangeRequestMessage>
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

            Notify();
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppThemeService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppThemeService(WeakReferenceMessenger messenger) : base(messenger) { }

    protected override void Subscribe()
    {
        _messenger.Register(this);
    }

    /// <summary>
    /// Notifies all subscribers of the value change of the <see cref="CurrentTheme"/> property.
    /// </summary>
    private void Notify()
    {
        _messenger.Send(new AppThemeChangedMessage(_currentTheme));
    }

    /// <summary>
    /// Handler for messages of type <see cref="AppThemeChangeRequestMessage"/>.
    /// </summary>
    /// <param name="message">
    /// The message instance.
    /// </param>
    public void Receive(AppThemeChangeRequestMessage message)
    {
        _currentTheme = message.Value;

        message.Reply(_currentTheme);

        Notify();
    }
}