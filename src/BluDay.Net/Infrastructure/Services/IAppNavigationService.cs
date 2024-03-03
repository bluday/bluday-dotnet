namespace BluDay.Net.Services;

public interface IAppNavigationService
{
    IReadOnlyDictionary<Guid, INavigator> NavigatorMap { get; }

    INavigator CreateNavigator(object source);
}