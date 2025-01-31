namespace BluDay.Net.Services;

/// <summary>
/// A service that manages view navigation within an app, for all active windows.
/// </summary>
public interface IAppNavigationService
{
    /// <summary>
    /// Navigates to the specified view within a window of type <see cref="IBluWindow"/>.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// The view model type.
    /// </typeparam>
    /// <param name="windowId">
    /// The id of the targeted window.
    /// </param>
    void Navigate<TViewModel>(Guid windowId) where TViewModel : ViewModel;

    /// <summary>
    /// Tries to navigate to the specified view within a window without throwing an exception.
    /// </summary>
    /// <inheritdoc cref="Navigate{TViewModel}(Guid)"/>
    bool TryNavigate<TViewModel>(Guid windowId) where TViewModel : ViewModel;
}