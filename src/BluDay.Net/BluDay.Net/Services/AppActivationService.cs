namespace BluDay.Net.Services;

/// <summary>
/// A service that handles the activation and deactivation of an app.
/// </summary>
public sealed class AppActivationService : Service, 
    IRecipient<AppActivationRequestMessage>,
    IRecipient<AppDeactivationRequestMessage>
{
    /// <summary>
    /// Gets a value indicating whether the app is activated.
    /// </summary>
    public bool IsActivated { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppActivationService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppActivationService(WeakReferenceMessenger messenger) : base(messenger) { }

    protected override void Subscribe()
    {
        _messenger.Register<AppActivationRequestMessage>(this);
        _messenger.Register<AppDeactivationRequestMessage>(this);
    }

    /// <summary>
    /// Activates the app.
    /// </summary>
    public void Activate()
    {
        if (IsActivated) return;

        _messenger.Send<AppActivatingMessage>();

        IsActivated = true;

        _messenger.Send<AppActivatedMessage>();
    }

    /// <summary>
    /// Deactivates the actve app.
    /// </summary>
    public void Deactivate()
    {
        if (!IsActivated) return;

        _messenger.Send<AppDeactivatingMessage>();

        IsActivated = false;

        _messenger.Send<AppDeactivatedMessage>();
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