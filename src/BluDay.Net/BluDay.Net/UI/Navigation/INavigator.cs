namespace BluDay.Net.UI.Navigation;

public interface INavigator
{
    bool CanGoBack { get; }

    bool CanGoForward { get; }

    int MaxCacheSize { get; set; }

    Guid WindowId { get; }

    IEnumerable<Type> Views { get; }

    bool Pop();

    bool Push(Type viewModelType);

    bool Push<TViewModel>() where TViewModel : IViewModel;

    void Reset();
}