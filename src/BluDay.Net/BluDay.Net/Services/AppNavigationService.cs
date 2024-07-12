namespace BluDay.Net.Services;

/// <summary>
/// A service that manages view navigation within an app, for all active windows.
/// </summary>
public sealed class AppNavigationService : Service
{
    private readonly Dictionary<Guid, ViewNavigator> _navigatorMap;

    /// <summary>
    /// Gets a read-only dictionary of the concrete id-to-view-navigator map.
    /// </summary>
    public IReadOnlyDictionary<Guid, ViewNavigator> NavigatorMap
    {
        get => _navigatorMap.AsReadOnly();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppNavigationService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppNavigationService(WeakReferenceMessenger messenger) : base(messenger)
    {
        _navigatorMap = new Dictionary<Guid, ViewNavigator>();
    }

    /// <summary>
    /// Navigates to the specified view within a window of type <see cref="IWindow"/>.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <param name="windowId">
    /// The id of the targeted window.
    /// </param>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public void Navigate<TView>(Guid windowId) where TView : IView
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries to navigate to the specified view within a window without throwing an exception.
    /// </summary>
    /// <inheritdoc cref="Navigate{TView}(Guid)"/>
    public bool TryNavigate<TView>(Guid windowId) where TView : IView
    {
        throw new NotImplementedException();
    }
}