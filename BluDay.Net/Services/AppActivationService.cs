namespace BluDay.Net.Services;

/// <summary>
/// Represents the implementation class for the app activation service.
/// </summary>
public sealed class AppActivationService : Service, IAppActivationService
{
    private bool _isActivated;

    /// <inheritdoc cref="IAppActivationService.IsActivated"/>
    public bool IsActivated
    {
        get => _isActivated;
    }

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
        if (_isActivated) return;

        // TODO: Activate the main window and the app.

        _isActivated = true;
    }

    /// <inheritdoc cref="IAppActivationService.Deactivate"/>
    public void Deactivate()
    {
        if (!_isActivated) return;

        // TODO: Deactivate the activated main window and the app.

        _isActivated = false;
    }
}