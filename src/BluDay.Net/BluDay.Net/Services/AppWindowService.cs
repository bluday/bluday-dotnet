namespace BluDay.Net.Services;

/// <summary>
/// A service that manages windows within an app.
/// </summary>
public sealed class AppWindowService : Service
{
    private readonly ImplementationProvider<IBluWindow> _windowFactory;

    private readonly HashSet<IBluWindow> _windows = new();

    /// <summary>
    /// Gets the main window.
    /// </summary>
    public IBluWindow? MainWindow => _windows.FirstOrDefault();

    /// <summary>
    /// Gets the count of all windows.
    /// </summary>
    public int WindowCount => _windows.Count;

    /// <summary>
    /// Gets an enumerable of all windows.
    /// </summary>
    public IEnumerable<IBluWindow> Windows => _windows;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppWindowService"/> class.
    /// </summary>
    /// <param name="windowFactory">
    /// An <see cref="IImplementationProvider"/> instance for resolving transient
    /// window instances of type <see cref="IBluWindow"/>.
    /// </param>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppWindowService(
        ImplementationProvider<IBluWindow> windowFactory,
        WeakReferenceMessenger          messenger
    )
        : base(messenger)
    {
        _windowFactory = windowFactory;
    }

    /// <summary>
    /// Creates a new window instance of type <see cref="IBluWindow"/>.
    /// </summary>
    /// <param name="config">
    /// The window configuration instance.
    /// </param>
    /// <returns>
    /// The window instance.
    /// </returns>
    public TWindow CreateWindow<TWindow>() where TWindow : IBluWindow
    {
        TWindow window = _windowFactory.GetInstance<TWindow>();

        _windows.Add(window);

        return window;
    }

    /// <summary>
    /// Closes and destroys the provided <see cref="IBluWindow"/> window instance if it
    /// has been registered within this service.
    /// </summary>
    /// <param name="window">
    /// The window instance.
    /// </param>
    /// <returns>
    /// <c>true</c> if destroyed, otherwise <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="window"/> is null.
    /// </exception>
    public bool DestroyWindow(IBluWindow window)
    {
        if (!_windows.Contains(window))
        {
            return false;
        }
        
        window.Close();

        return _windows.Remove(window);
    }

    /// <inheritdoc cref="DestroyWindow(IBluWindow)"/>
    /// <param name="windowId">
    /// The id of the window.
    /// </param>
    public bool DestroyWindow(ulong windowId)
    {
        IBluWindow? window = _windows.FirstOrDefault(window => window.Id == windowId);

        if (window is null) return false;

        window.Close();

        return _windows.Remove(window);
    }

    /// <summary>
    /// Gets a value indicating whether the provided window instance exists and if it
    /// has been registered within the service.
    /// </summary>
    /// <param name="window">
    /// The window instance.
    /// </param>
    /// <returns>
    /// <c>true</c> if the window exists, <c>false</c> otherwise.
    /// </returns>
    public bool HasWindow(IBluWindow window)
    {
        return _windows.Contains(window);
    }

    /// <param name="windowId">
    /// The id of the window.
    /// </param>
    /// <inheritdoc cref="HasWindow(IBluWindow)"/>
    public bool HasWindow(ulong windowId)
    {
        return _windows.Any(window => window.Id == windowId);
    }
}