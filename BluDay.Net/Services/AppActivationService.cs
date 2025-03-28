namespace BluDay.Net.Services;

/// <summary>
/// Represents the default implementation class for the app activation service.
/// </summary>
public sealed class AppActivationService : Service, IAppActivationService
{
    private readonly IAppActivationHandler _activationHandler;

    private readonly IAppDeactivationHandler _deactivationHandler;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppActivationService"/> class.
    /// </summary>
    /// <param name="activationHandler">
    /// The handler responsible for managing application activation logic.
    /// </param>
    /// <param name="deactivationHandler">
    /// The handler responsible for managing application deactivation logic.
    /// </param>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppActivationService(
        IAppActivationHandler   activationHandler,
        IAppDeactivationHandler deactivationHandler,
        WeakReferenceMessenger  messenger
    )
        : base(messenger)
    {
        _activationHandler   = activationHandler;
        _deactivationHandler = deactivationHandler;
    }

    /// <inheritdoc cref="IAppActivationService.ActivateAsync()"/>
    public Task ActivateAsync()
    {
        return ActivateAsync(null!);
    }

    /// <inheritdoc cref="IAppActivationService.ActivateAsync(object)"/>
    public async Task ActivateAsync(object args)
    {
        await _activationHandler.ActivateAsync(args);

        _messenger.Send(new AppActivatedMessage());
    }

    /// <inheritdoc cref="IAppActivationService.DeactivateAsync()"/>
    public async Task DeactivateAsync()
    {
        await _deactivationHandler.DeactivateAsync();

        _messenger.Send(new AppDeactivatedMessage());
    }
}