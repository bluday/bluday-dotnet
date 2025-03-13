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

    /// <inheritdoc cref="IAppActivationService.ActivateAsync(IAppActivationHandler)"/>
    public Task ActivateAsync(IAppActivationHandler handler)
    {
        return handler.ActivateAsync();
    }

    /// <inheritdoc cref="IAppActivationService.DeactivateAsync(IAppDeactivationHandler)"/>
    public Task DeactivateAsync(IAppDeactivationHandler handler)
    {
        return handler.DeactivateAsync();
    }
}