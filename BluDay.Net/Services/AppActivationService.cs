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
    public Task ActivateAsync()
    {
        if (_isActivated)
        {
            return Task.CompletedTask;
        }

        // TODO: Activate the main window and the app.

        _isActivated = true;

        return Task.CompletedTask;
    }

    /// <inheritdoc cref="IAppActivationService.DeactivateAsync"/>
    public Task DeactivateAsync()
    {
        if (!_isActivated)
        {
            return Task.CompletedTask;
        }

        // TODO: Deactivate the activated main window and the app.

        _isActivated = false;

        return Task.CompletedTask;
    }
}