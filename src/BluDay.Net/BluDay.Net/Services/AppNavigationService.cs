namespace BluDay.Net.Services;

public sealed class AppNavigationService : IAppNavigationService
{
    private readonly IMessenger _messenger;

    private readonly Dictionary<Guid, IViewNavigator> _navigatorMap;

    public IReadOnlyDictionary<Guid, IViewNavigator> NavigatorMap
    {
        get => _navigatorMap.AsReadOnly();
    }

    public AppNavigationService(IMessenger messenger)
    {
        _messenger = messenger;

        _navigatorMap = new Dictionary<Guid, IViewNavigator>();
    }

    public IViewNavigator CreateNavigator(object source)
    {
        throw new NotImplementedException();
    }
}