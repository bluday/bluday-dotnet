namespace BluDay.Net.WinUI3.Abstractions.Handlers;

/// <summary>
/// Defines a contract for handling app activation within the context of a WinUI 3 application.
/// </summary>
public interface IWinUI3AppActivationHandler : IAppActivationHandler
{
    /// <summary>
    /// Activates the application asynchronously, preparing it to run by handling the launch
    /// event arguments.
    /// </summary>
    /// <param name="e">
    /// The event arguments associated with the application's launch, containing details about
    /// how the app was launched.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation of activating the application.
    /// </returns>
    Task ActivateAsync(LaunchActivatedEventArgs? e);
}