namespace BluDay.Net.Services;

public sealed class AppNavigationService : Service, IAppNavigationService
{
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
}