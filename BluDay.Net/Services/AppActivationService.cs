namespace BluDay.Net.Services;

/// <summary>
/// A service that handles the activation and deactivation of an app.
/// </summary>
public sealed class AppActivationService : Service
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

    /// <summary>
    /// Activates the app.
    /// </summary>
    public void Activate()
    {
        if (IsActivated) return;

        // TODO: Activate the main window and the app.

        IsActivated = true;
    }

    /// <summary>
    /// Deactivates the actve app.
    /// </summary>
    public void Deactivate()
    {
        if (!IsActivated) return;

        // TODO: Deactivate the activated main window and the app.

        IsActivated = false;
    }
}