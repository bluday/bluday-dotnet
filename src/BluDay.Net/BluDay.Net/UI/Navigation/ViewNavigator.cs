namespace BluDay.Net.UI.Navigation;

/// <summary>
/// Represents a view navigator for managing navigation between views.
/// </summary>
public sealed class ViewNavigator
{
    private bool _canGoBack;

    private bool _canGoForward;

    private Type? _currentViewType;

    private readonly Stack<Type> _viewTypeStack = new();

    /// <summary>
    /// Gets a value indicating whether navigation to the previous view is possible.
    /// </summary>
    public bool CanGoBack => _canGoBack;

    /// <summary>
    /// Gets a value indicating whether navigation to the next view is possible.
    /// </summary>
    public bool CanGoForward => _canGoForward;

    /// <summary>
    /// Gets the view type at the top of the current view type stack.
    /// </summary>
    public Type? CurrentView => _currentViewType;

    /// <summary>
    /// Gets an enumerable of types for all displayed views.
    /// </summary>
    public IEnumerable<Type> CurrentViews => _viewTypeStack;

    /// <summary>
    /// Removes the top view from the navigation stack.
    /// </summary>
    /// <returns>
    /// The current instance to allow additional chained calls.
    /// </returns>
    public ViewNavigator Pop()
    {
        if (!_viewTypeStack.TryPop(out Type? _))
        {
            return this;
        }

        _viewTypeStack.TryPeek(out Type? currentViewType);

        _currentViewType = currentViewType;

        return this;
    }

    /// <summary>
    /// Pushes a new view onto the navigation stack based on the specific view type.
    /// </summary>
    /// <param name="viewType">
    /// The type of the view associated with the view.
    /// </param>
    /// <returns>
    /// The current instance to allow additional chained calls.
    /// </returns>
    /// <exception cref="InvalidViewTypeException">
    /// If the provided view type is not of type <see cref="IView"/>.
    /// </exception>
    public ViewNavigator Push(Type viewType)
    {
        InvalidViewTypeException.ThrowIfInvalid(viewType);

        _viewTypeStack.Push(viewType);

        _currentViewType = viewType;

        return this;
    }

    /// <inheritdoc cref="Push(Type)"/>
    /// <typeparam name="TView">
    /// The type of the view associated with the view.
    /// </typeparam>
    public ViewNavigator Push<TView>() where TView : class
    {
        return Push(typeof(TView));
    }

    /// <summary>
    /// Resets the view navigation stack.
    /// </summary>
    /// <returns>
    /// The current instance to allow additional chained calls.
    /// </returns>
    public ViewNavigator Reset()
    {
        _viewTypeStack.Clear();

        _currentViewType = null;

        return this;
    }
}