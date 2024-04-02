namespace BluDay.Net.Services;

public sealed class AppNavigationService : IAppNavigationService
{
    private readonly IMessenger _messenger;

    private readonly Dictionary<Guid, INavigator> _navigatorMap;

    public IReadOnlyDictionary<Guid, INavigator> NavigatorMap
    {
        get => _navigatorMap.AsReadOnly();
    }

    public AppNavigationService(IMessenger messenger)
    {
        ArgumentNullException.ThrowIfNull(messenger);

        _messenger = messenger;

        _navigatorMap = new();
    }

    public INavigator CreateNavigator(object source)
    {
        throw new NotImplementedException();
    }
}