namespace BluDay.Net.Services;

/// <summary>
/// Represents the default implementation class for the app navigation service.
/// </summary>
public sealed class AppNavigationService : Service, IAppNavigationService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IAppNavigationService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instance.
    /// </param>
    public AppNavigationService(WeakReferenceMessenger messenger) : base(messenger) { }

    /// <inheritdoc cref="IAppNavigationService.NavigateAsync(Type, Guid)"/>
    public Task NavigateAsync(Type viewType, Guid windowId)
    {
        throw new NotImplementedException();
    }
}