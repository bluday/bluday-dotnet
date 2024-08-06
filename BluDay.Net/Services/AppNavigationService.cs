namespace BluDay.Net.Services;

/// <summary>
/// A service that manages view navigation within an app, for all active windows.
/// </summary>
public sealed class AppNavigationService : Service
{
    private readonly Dictionary<ulong, ViewNavigator> _windowIdToViewNavigatorMap = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="AppNavigationService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instance.
    /// </param>
    public AppNavigationService(WeakReferenceMessenger messenger) : base(messenger) { }

    /// <summary>
    /// Navigates to the specified view within a window of type <see cref="IBluWindow"/>.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// The view model type.
    /// </typeparam>
    /// <param name="windowId">
    /// The id of the targeted window.
    /// </param>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public void Navigate<TViewModel>(Guid windowId) where TViewModel : ViewModel
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries to navigate to the specified view within a window without throwing an exception.
    /// </summary>
    /// <inheritdoc cref="Navigate{TViewModel}(Guid)"/>
    public bool TryNavigate<TViewModel>(Guid windowId) where TViewModel : ViewModel
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a new view navigator for the provided <paramref name="window"/> instance.
    /// </summary>
    /// <typeparam name="TWindow">
    /// The window type of the owner instance.
    /// </typeparam>
    /// <param name="window">
    /// The window and the owner of the new navigator instance.
    /// </param>
    /// <returns>
    /// A <see cref="ViewNavigator"/> instance for the window.
    /// </returns>
    public ViewNavigator CreateNavigator<TWindow>(TWindow window) where TWindow : IBluWindow
    {
        ViewNavigator navigator = new(window);

        _windowIdToViewNavigatorMap.Add(window.Id, navigator);

        return navigator;
    }
}