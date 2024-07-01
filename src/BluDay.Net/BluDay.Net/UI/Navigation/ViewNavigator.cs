namespace BluDay.Net.UI.Navigation;

/// <inheritdoc cref="IViewNavigator"/>
public sealed class ViewNavigator : IViewNavigator
{
    private bool _canGoBack;

    private bool _canGoForward;

    private Type? _currentViewModelType;

    private readonly Stack<Type> _viewModelTypeStack;

    public bool CanGoBack => _canGoBack;

    public bool CanGoForward => _canGoForward;

    public Guid WindowId { get; }

    public Type? CurrentView => _currentViewModelType;

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

    public void Push(Type viewModelType)
    {
        InvalidViewModelTypeException.ThrowIfInvalid(viewModelType);

        _viewModelTypeStack.Push(viewModelType);

        _currentViewModelType = viewModelType;
    }

    public void Push<TViewModel>() where TViewModel : IViewModel
    {
        Push(typeof(TViewModel));
    }

    public void Reset()
    {
        _viewModelTypeStack.Clear();

        _currentViewModelType = null;
    }
}