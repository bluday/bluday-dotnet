namespace BluDay.Net.Services;

/// <summary>
/// A service that manages dialogs within an app.
/// </summary>
public sealed class AppDialogService : Service
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDialogService"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppDialogService(WeakReferenceMessenger messenger) : base(messenger) { }
}