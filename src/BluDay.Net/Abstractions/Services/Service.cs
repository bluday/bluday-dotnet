namespace BluDay.Net.Abstractions.Services;

/// <summary>
/// A service that manages dialogs within an app.
/// </summary>
public abstract class Service
{
    protected readonly WeakReferenceMessenger _messenger;

    /// <summary>
    /// Initializes a new instance of the <see cref="Service"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The <see cref="WeakReference"/>-based messenger instance.
    /// </param>
    public Service(WeakReferenceMessenger messenger)
    {
        ArgumentNullException.ThrowIfNull(messenger);

        _messenger = messenger;
    }
}