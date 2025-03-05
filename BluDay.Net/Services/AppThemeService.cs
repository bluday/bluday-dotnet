using BluDay.Net.Messaging.Messages;

namespace BluDay.Net.Services;

/// <inheritdoc cref="IAppThemeService"/>
public sealed class AppThemeService : Service,
    IAppThemeService,
    IRecipient<AppThemeChangeMessage>
{
    private AppTheme _currentTheme;

    /// <inheritdoc cref="IAppThemeService.CurrentTheme"/>
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

    /// <inheritdoc cref="IRecipient{TMessage}.Receive(TMessage)"/>
    public void Receive(AppThemeChangeMessage message)
    {
        CurrentTheme = message.Value;
    }
}