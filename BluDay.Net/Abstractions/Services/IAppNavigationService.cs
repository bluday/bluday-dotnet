namespace BluDay.Net.Abstractions.Services;

/// <summary>
/// A service that manages view navigation within an app, for all active windows.
/// </summary>
public interface IAppNavigationService
{
    /// <summary>
    /// Retrieves a linked list containing the types of all currently visible
    /// views within a specified window.
    /// </summary>
    /// <param name="windowId">
    /// The unique identifier of the targeted window.
    /// </param>
    /// <returns>
    /// A linked list of view types representing the visible views within the
    /// specified window.
    /// </returns>
    LinkedList<Type> GetCurrentViews(Guid windowId);

    /// <summary>
    /// Initiates navigation to the specified view within a window that
    /// implements <see cref="IBluWindow"/>.
    /// </summary>
    /// <param name="viewType">
    /// The type of the view model to navigate to.
    /// </param>
    /// <param name="windowId">
    /// The unique identifier of the targeted window.
    /// </param>
    /// <returns>
    /// A task that encapsulates the asynchronous navigation operation.
    /// </returns>
    Task NavigateAsync(Type viewType, Guid windowId);
}