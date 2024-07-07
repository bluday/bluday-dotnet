namespace BluDay.Net.Services;

/// <summary>
/// A service that handles the activation and deactivation of an app.
/// </summary>
public sealed class AppActivationService
{
    private bool _isActivated;

    private readonly WeakReferenceMessenger _messenger;

    /// <summary>
    /// Gets a value indicating whether the app is activated.
    /// </summary>
    public bool IsActivated => _isActivated;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppActivationService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppActivationService(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;
    }

    /// <summary>
    /// Activates the application.
    /// </summary>
    public void Activate()
    {
        _messenger.Send<AppActivatingMessage>();

        _isActivated = true;

        _messenger.Send<AppActivatedMessage>();
    }
}