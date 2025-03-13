namespace BluDay.Net.Services;

/// <summary>
/// A service that handles the activation and deactivation of an application.
/// </summary>
public interface IAppActivationService
{
    /// <summary>
    /// Activates the application asynchronously.
    /// </summary>
    /// <inheritdoc cref="ActivateAsync(object)"/>
    Task ActivateAsync();

    /// <summary>
    /// Activates the application asynchronously using the provided arguments.
    /// </summary>
    /// <inheritdoc cref="IAppActivationHandler.ActivateAsync(object?)"/>
    Task ActivateAsync(object args);

    /// <summary>
    /// Deactivates the currently active application asynchronously.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous deactivation operation.
    /// </returns>
    Task DeactivateAsync();
}