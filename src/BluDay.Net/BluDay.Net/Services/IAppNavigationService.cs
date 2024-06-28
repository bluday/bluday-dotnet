namespace BluDay.Net.Services;

public interface IAppNavigationService
{
    IReadOnlyDictionary<Guid, IViewNavigator> NavigatorMap { get; }

    IViewNavigator CreateNavigator(object source);
}