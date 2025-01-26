namespace BluDay.Net.Services;

/// <summary>
/// A service that manages view navigation within an app, for all active windows.
/// </summary>
public interface IAppNavigationService
{
    /// <summary>
    /// Creates a new view navigator for the provided <paramref name="window"/> instance.
    /// </summary>
    /// <typeparam name="TWindow">
    /// The window type of the owner instance.
    /// </typeparam>
    /// <param name="window">
    /// The window and the owner of the new navigator instance.
    /// </param>
    /// <returns>
    /// A <see cref="ViewNavigator"/> instance for the window.
    /// </returns>
    ViewNavigator CreateNavigator<TWindow>(TWindow window) where TWindow : IBluWindow;

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