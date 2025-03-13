namespace BluDay.Net.Abstractions.Handlers;

/// <summary>
/// Defines a contract for handling application activation.
/// </summary>
public interface IAppActivationHandler
{
    /// <summary>
    /// Activates the application asynchronously using the provided arguments.
    /// </summary>
    /// <param name="args">
    /// The arguments required for the activation process. This can include
    /// initialization data or configuration settings.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous activation operation.
    /// </returns>
    Task ActivateAsync(object? args);
}