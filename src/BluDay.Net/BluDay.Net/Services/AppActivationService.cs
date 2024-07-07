namespace BluDay.Net.Services;

/// <summary>
/// A service that handles the activation and deactivation of an app.
/// </summary>
public sealed class AppActivationService : Service, 
    IRecipient<AppActivationRequestMessage>,
    IRecipient<AppDeactivationRequestMessage>
{
    private bool _isActivated;

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
    public AppActivationService(WeakReferenceMessenger messenger) : base(messenger) { }

    protected override void Subscribe()
    {
        Messenger.Register<AppActivationRequestMessage>(this);
        Messenger.Register<AppDeactivationRequestMessage>(this);
    }

    /// <summary>
    /// Activates the app.
    /// </summary>
    public void Activate()
    {
        Messenger.Send<AppActivatingMessage>();

        _isActivated = true;

        Messenger.Send<AppActivatedMessage>();
    }

    /// <summary>
    /// Deactivates the actve app.
    /// </summary>
    public void Deactivate()
    {
        Messenger.Send<AppDeactivatingMessage>();

        _isActivated = false;

        Messenger.Send<AppDeactivatedMessage>();
    }

    /// <summary>
    /// Handles a received <see cref="AppActivationRequestMessage"/> message.
    /// </summary>
    /// <param name="message">
    /// The received message.
    /// </param>
    public void Receive(AppActivationRequestMessage message)
    {
        Activate();
    }

    /// <summary>
    /// Handles a received <see cref="AppDeactivationRequestMessage"/> message.
    /// </summary>
    /// <param name="message">
    /// The received message.
    /// </param>
    public void Receive(AppDeactivationRequestMessage message)
    {
        Deactivate();
    }
}