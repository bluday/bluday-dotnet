namespace BluDay.Net.Services;

public sealed class AppNavigationService
{
    private readonly WeakReferenceMessenger _messenger;

    private readonly Dictionary<Guid, IViewNavigator> _navigatorMap;

    public IReadOnlyDictionary<Guid, IViewNavigator> NavigatorMap
    {
        get => _navigatorMap.AsReadOnly();
    }

    public AppNavigationService(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;

        _navigatorMap = new Dictionary<Guid, IViewNavigator>();
    }

    public IViewNavigator CreateNavigator(object source)
    {
        throw new NotImplementedException();
    }
}