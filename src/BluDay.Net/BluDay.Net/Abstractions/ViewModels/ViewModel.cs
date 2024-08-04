namespace BluDay.Net.ViewModels;

/// <summary>
/// Represents the base of a view model class.
/// </summary>
public abstract class ViewModel : ObservableObject
{
    protected ViewModel? _currentChild;

    protected readonly WeakReferenceMessenger _messenger;

    /// <summary>
    /// Gets the current child instance.
    /// </summary>
    public ViewModel? CurrentChild
    {
        get => _currentChild;
        protected set
        {
            _currentChild = value;

            // TODO: Deactivate the previous one and activate the new one.

            OnPropertyChanged(nameof(CurrentChild));
        }
    }

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

    /// <summary>
    /// Registers recipients of specified message types.
    /// </summary>
    protected virtual void Subscribe() { }

    /// <summary>
    /// Unregisters recipients of specified message types.
    /// </summary>
    protected virtual void Unsubscribe() { }
}