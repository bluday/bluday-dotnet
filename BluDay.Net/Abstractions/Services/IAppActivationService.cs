namespace BluDay.Net.Services;

/// <summary>
/// A service that handles the activation and deactivation of an application.
/// </summary>
public interface IAppActivationService
{
    /// <summary>
    /// Gets a value indicating whether the application is currently activated.
    /// </summary>
    bool IsActivated { get; }

    /// <summary>
    /// Activates the application asynchronously.
    /// </summary>
    /// <param name="handler">
    /// The activation handler responsible for managing activation-related logic.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous activation operation.
    /// </returns>
    Task ActivateAsync(IAppActivationHandler handler);

    /// <summary>
    /// Deactivates the currently active application asynchronously.
    /// </summary>
    /// <param name="handler">
    /// The deactivation handler responsible for managing deactivation-related logic.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous deactivation operation.
    /// </returns>
    Task DeactivateAsync(IAppDeactivationHandler handler);
}