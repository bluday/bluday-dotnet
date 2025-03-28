namespace BluDay.Net.Abstractions.Services;

/// <summary>
/// A service that manages windows within an app.
/// </summary>
public interface IAppWindowService
{
    /// <summary>
    /// Gets the main window.
    /// </summary>
    IBluWindow? MainWindow { get; }

    /// <summary>
    /// Gets the count of all windows.
    /// </summary>
    int WindowCount { get; }

    /// <summary>
    /// Gets an enumerable of all windows.
    /// </summary>
    IEnumerable<IBluWindow> Windows { get; }

    /// <summary>
    /// Creates a new window instance of type <see cref="IBluWindow"/>.
    /// </summary>
    /// <returns>
    /// The window instance.
    /// </returns>
    IBluWindow CreateWindow(Type windowType);

    /// <summary>
    /// Closes and destroys the provided <see cref="IBluWindow"/> window instance if it
    /// has been registered within this service.
    /// </summary>
    /// <param name="window">
    /// The window instance.
    /// </param>
    /// <returns>
    /// <c>true</c> if destroyed, otherwise <c>false</c>.
    /// </returns>
    bool DestroyWindow(IBluWindow window);

    /// <summary>
    /// Gets a value indicating whether the provided window instance exists and if it
    /// has been registered within the service.
    /// </summary>
    /// <param name="window">
    /// The window instance.
    /// </param>
    /// <returns>
    /// <c>true</c> if the window exists, <c>false</c> otherwise.
    /// </returns>
    bool HasWindow(IBluWindow window);
}