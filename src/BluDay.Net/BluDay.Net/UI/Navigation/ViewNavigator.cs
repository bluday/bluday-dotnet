namespace BluDay.Net.UI.Navigation;

/// <summary>
/// Represents a view navigator for managing navigation between views.
/// </summary>
public sealed class ViewNavigator
{
    private bool _canGoBack;

    private bool _canGoForward;

    private Type? _currentViewModelType;

    private readonly Stack<Type> _viewModelTypeStack;

    /// <summary>
    /// Gets a value indicating whether navigation to the previous view is possible.
    /// </summary>
    public bool CanGoBack => _canGoBack;

    /// <summary>
    /// Gets a value indicating whether navigation to the next view is possible.
    /// </summary>
    public bool CanGoForward => _canGoForward;

    /// <summary>
    /// Gets the unique identifier associated with the window.
    /// </summary>
    public Guid WindowId { get; }

    /// <summary>
    /// Gets the view type at the top of the current view type stack.
    /// </summary>
    public Type? CurrentView => _currentViewModelType;

    /// <summary>
    /// Gets an enumerable of types for all displayed views.
    /// </summary>
    public IEnumerable<Type> CurrentViews => _viewModelTypeStack;

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewNavigator"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="window"/> is null.
    /// </exception>
    public ViewNavigator(IWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);

        _viewModelTypeStack = new Stack<Type>();
    }

    /// <summary>
    /// Removes the top view from the navigation stack.
    /// </summary>
    /// <returns>
    /// <c>true</c> if successful, <c>false</c> if the stack is empty.
    /// </returns>
    public bool Pop()
    {
        if (!_viewModelTypeStack.TryPop(out Type? _))
        {
            return false;
        }

        _viewModelTypeStack.TryPeek(out Type? currentViewModelType);

        _currentViewModelType = currentViewModelType;

        return true;
    }

    /// <summary>
    /// Pushes a new view onto the navigation stack based on the specific view model type.
    /// </summary>
    /// <param name="viewModelType">
    /// The type of the view model associated with the view.
    /// </param>
    /// <exception cref="InvalidViewModelTypeException">
    /// If the provided view model type is not of type <see cref="ViewModel"/>.
    /// </exception>
    public void Push(Type viewModelType)
    {
        InvalidViewModelTypeException.ThrowIfInvalid(viewModelType);

        _viewModelTypeStack.Push(viewModelType);

        _currentViewModelType = viewModelType;
    }

    /// <summary>
    /// Pushes a new view onto the navigation stack based on the specific view model type.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// The type of the view model associated with the view.
    /// </typeparam>
    public void Push<TViewModel>() where TViewModel : IViewModel
    {
        Push(typeof(TViewModel));
    }

    /// <summary>
    /// Resets the view navigation stack.
    /// </summary>
    public void Reset()
    {
        _viewModelTypeStack.Clear();

        _currentViewModelType = null;
    }
}