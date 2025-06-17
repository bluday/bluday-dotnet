namespace BluDay.Net.Abstractions.Handlers;

/// <summary>
/// Defines a contract for handling app deactivation.
/// </summary>
public interface IAppDeactivationHandler
{
    /// <summary>
    /// Deactivates the application asynchronously.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous deactivation operation.
    /// </returns>
    Task DeactivateAsync();
}