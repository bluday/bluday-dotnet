namespace BluDay.Net.Services;

/// <summary>
/// A service that manages view navigation within an app, for all active windows.
/// </summary>
public sealed class AppNavigationService
{
    private readonly WeakReferenceMessenger _messenger;

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
    public AppNavigationService(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;

        _navigatorMap = new Dictionary<Guid, ViewNavigator>();
    }

    /// <summary>
    /// Creates a <see cref="ViewNavigator"/> instance for the specified object.
    /// </summary>
    /// <param name="source">
    /// The owner of the navigator.
    /// </param>
    /// <returns>
    /// The view navigator instance.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public ViewNavigator CreateNavigator(object source)
    {
        throw new NotImplementedException();
    }
}