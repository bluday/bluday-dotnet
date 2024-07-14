namespace BluDay.Net.Domain.ViewModels;

/// <summary>
/// Represents the base of a view model class.
/// </summary>
public abstract class ViewModel : ObservableObject, IViewModel
{
    protected readonly WeakReferenceMessenger _messenger;

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