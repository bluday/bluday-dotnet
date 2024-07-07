namespace BluDay.Net.Services;

public sealed class AppNavigationService
{
    private readonly WeakReferenceMessenger _messenger;

    private readonly Dictionary<Guid, ViewNavigator> _navigatorMap;

    public IReadOnlyDictionary<Guid, ViewNavigator> NavigatorMap
    {
        get => _navigatorMap.AsReadOnly();
    }

    public AppNavigationService(WeakReferenceMessenger messenger)
    {
        _messenger = messenger;

        _navigatorMap = new Dictionary<Guid, ViewNavigator>();
    }

    public ViewNavigator CreateNavigator(object source)
    {
        throw new NotImplementedException();
    }
}