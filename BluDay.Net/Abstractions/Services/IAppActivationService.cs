namespace BluDay.Net.Services;

/// <summary>
/// A service that handles the activation and deactivation of an app.
/// </summary>
public interface IAppActivationService
{
    /// <summary>
    /// Gets a value indicating whether the app is activated.
    /// </summary>
    bool IsActivated { get; }

    /// <summary>
    /// Activates the app.
    /// </summary>
    void Activate();

    /// <summary>
    /// Deactivates the actve app.
    /// </summary>
    void Deactivate();
}