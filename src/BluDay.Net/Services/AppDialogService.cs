namespace BluDay.Net.Services;

/// <summary>
/// Represents the default implementation class for the app dialog service.
/// </summary>
public sealed class AppDialogService : Service, IAppDialogService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDialogService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppDialogService(WeakReferenceMessenger messenger) : base(messenger) { }
}