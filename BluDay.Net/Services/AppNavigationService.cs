namespace BluDay.Net.Services;

public sealed class AppNavigationService : Service, IAppNavigationService
{
    private readonly Dictionary<ulong, ViewNavigator> _windowIdToViewNavigatorMap = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="IAppNavigationService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instance.
    /// </param>
    public AppNavigationService(WeakReferenceMessenger messenger) : base(messenger) { }

    public void Navigate<TViewModel>(Guid windowId) where TViewModel : ViewModel
    {
        throw new NotImplementedException();
    }

    public bool TryNavigate<TViewModel>(Guid windowId) where TViewModel : ViewModel
    {
        throw new NotImplementedException();
    }

    public ViewNavigator CreateNavigator<TWindow>(TWindow window) where TWindow : IBluWindow
    {
        ViewNavigator navigator = new(window);

        _windowIdToViewNavigatorMap.Add(window.Id, navigator);

        return navigator;
    }
}