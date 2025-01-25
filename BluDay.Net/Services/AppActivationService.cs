namespace BluDay.Net.Services;

public sealed class AppActivationService : Service, IAppActivationService
{
    public bool IsActivated { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppActivationService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppActivationService(WeakReferenceMessenger messenger) : base(messenger) { }

    public void Activate()
    {
        if (IsActivated) return;

        // TODO: Activate the main window and the app.

        IsActivated = true;
    }

    public void Deactivate()
    {
        if (!IsActivated) return;

        // TODO: Deactivate the activated main window and the app.

        IsActivated = false;
    }
}