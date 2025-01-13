namespace BluDay.Net.ViewModels;

/// <summary>
/// Represents the base of a view model class.
/// </summary>
public abstract partial class ViewModel : ObservableObject
{
    protected readonly WeakReferenceMessenger _messenger;

    /// <summary>
    /// Gets the current child instance.
    /// </summary>
    [ObservableProperty]
    public partial ViewModel? CurrentChild { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewModel"/> class.
    /// </summary>
    /// <param name="messenger">
    /// The <see cref="WeakReference"/>-based messenger instance.
    /// </param>
    public ViewModel(WeakReferenceMessenger messenger)
    {
        ArgumentNullException.ThrowIfNull(messenger);

        _messenger = messenger;
    }

    // TODO: Deactivate the previous one and activate the new one.

    /// <summary>
    /// Registers recipients of specified message types.
    /// </summary>
    protected virtual void Subscribe() { }

    /// <summary>
    /// Unregisters recipients of specified message types.
    /// </summary>
    protected virtual void Unsubscribe() { }
}