namespace BluDay.Net.Services;

/// <summary>
/// A service that manages dialogs within an app.
/// </summary>
public abstract class Service
{
    private readonly WeakReferenceMessenger _messenger;

    /// <summary>
    /// Gets the messenger instance.
    /// </summary>
    public WeakReferenceMessenger Messenger => _messenger;

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

        Subscribe();
    }

    /// <summary>
    /// Creates recipients or subscribers for specified message types.
    /// </summary>
    protected virtual void Subscribe() { }

    /// <summary>
    /// Removes recipients or subscribers for specified message types.
    /// </summary>
    protected virtual void Unsubscribe() { }
}