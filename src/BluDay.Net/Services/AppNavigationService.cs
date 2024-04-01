namespace BluDay.Net.Services;

public sealed class AppNavigationService : IAppNavigationService
{
    private readonly IMessenger _messenger;

    private readonly Dictionary<Guid, INavigator> _navigatorMap = new();

    public IReadOnlyDictionary<Guid, INavigator> NavigatorMap => _navigatorMap.AsReadOnly();

    public AppNavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public INavigator CreateNavigator(object source)
    {
        throw new NotImplementedException();
    }
}