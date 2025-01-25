namespace BluDay.Net.Services;

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