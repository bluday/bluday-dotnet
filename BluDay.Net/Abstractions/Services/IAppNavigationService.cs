namespace BluDay.Net.Services;

/// <summary>
/// A service that manages view navigation within an app, for all active windows.
/// </summary>
public interface IAppNavigationService
{
    /// <summary>
    /// Navigates to the specified view within a window of type <see cref="IBluWindow"/>.
    /// </summary>
    /// <param name="viewType">
    /// The view model type.
    /// </typeparam>
    /// <param name="windowId">
    /// The id of the targeted window.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// </returns>
    Task NavigateAsync(Type viewType, Guid windowId);
}