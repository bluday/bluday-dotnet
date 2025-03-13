namespace BluDay.Net.Abstractions.Handlers;

/// <summary>
/// Defines a contract for handling app activation events specific to a platform.
/// </summary>
public interface IAppActivationHandler
{
    /// <summary>
    /// Activates the application asynchronously.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous activation operation.
    /// </returns>
    Task ActivateAsync();
}