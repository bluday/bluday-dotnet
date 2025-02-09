namespace BluDay.Net.Services;

/// <inheritdoc cref="IAppActivationService"/>
public sealed class AppActivationService : Service, IAppActivationService
{
    /// <inheritdoc cref="IAppActivationService.IsActivated"/>
    public bool IsActivated { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppActivationService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppActivationService(WeakReferenceMessenger messenger) : base(messenger) { }

    /// <inheritdoc cref="IAppActivationService.Activate"/>
    public void Activate()
    {
        if (IsActivated) return;

        // TODO: Activate the main window and the app.

        IsActivated = true;
    }

    /// <inheritdoc cref="IAppActivationService.Deactivate"/>
    public void Deactivate()
    {
        if (!IsActivated) return;

        // TODO: Deactivate the activated main window and the app.

        IsActivated = false;
    }
}