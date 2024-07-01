namespace BluDay.Net.UI.Navigation;

/// <inheritdoc cref="IViewNavigator"/>
public sealed class ViewNavigator : IViewNavigator
{
    private bool _canGoBack;

    private bool _canGoForward;

    private readonly Stack<Type> _viewTypeStack;

    public bool CanGoBack => _canGoBack;

    public bool CanGoForward => _canGoForward;

    public Guid WindowId { get; }

    public IEnumerable<Type> Views => _viewTypeStack;

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewNavigator"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="window"/> is null.
    /// </exception>
    public ViewNavigator(IWindow window)
    {
        ArgumentNullException.ThrowIfNull(window);

        _viewTypeStack = new Stack<Type>();
    }

    public void Pop()
    {
        _viewTypeStack.Pop();
    }

    public void Push(Type viewModelType)
    {
        InvalidViewModelTypeException.ThrowIfInvalid(viewModelType);

        _viewTypeStack.Push(viewModelType);
    }

    public void Push<TViewModel>() where TViewModel : IViewModel
    {
        Push(typeof(TViewModel));
    }

    public void Reset()
    {
        _viewTypeStack.Clear();
    }
}