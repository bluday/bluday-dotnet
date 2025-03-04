namespace BluDay.Net.Services;

/// <summary>
/// Represents the implementation class for the app window service.
/// </summary>
public sealed class AppWindowService : Service, IAppWindowService
{
    private readonly ImplementationProvider<IBluWindow> _windowFactory;

    private readonly HashSet<IBluWindow> _windows;

    /// <inheritdoc cref="IAppWindowService.MainWindow"/>
    public IBluWindow? MainWindow
    {
        get => _windows.FirstOrDefault();
    }

    /// <inheritdoc cref="IAppWindowService.WindowCount"/>
    public int WindowCount
    {
        get => _windows.Count;
    }

    /// <inheritdoc cref="IAppWindowService.Windows"/>
    public IEnumerable<IBluWindow> Windows
    {
        get => _windows;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppWindowService"/> class.
    /// </summary>
    /// <param name="windowFactory">
    /// An implementation provider instance for resolving transient window instances
    /// of type <see cref="IBluWindow"/>.
    /// </param>
    /// <param name="messenger">
    /// The event messenger instance.
    /// </param>
    public AppWindowService(
        ImplementationProvider<IBluWindow> windowFactory,
        WeakReferenceMessenger             messenger
    )
        : base(messenger)
    {
        _windowFactory = windowFactory;

        _windows = new HashSet<IBluWindow>();
    }

    /// <inheritdoc cref="IAppWindowService.CreateWindow"/>
    public IBluWindow CreateWindow(Type windowType)
    {
        var window = (IBluWindow)_windowFactory.GetInstance(windowType);

        _windows.Add(window);

        _messenger.Send(new WindowCreatedMessage(window));

        return window;
    }

    /// <inheritdoc cref="IAppWindowService.DestroyWindow(IBluWindow)"/>
    public bool DestroyWindow(IBluWindow window)
    {
        if (!_windows.Remove(window))
        {
            return false;
        }
        
        window.Close();

        _messenger.Send(new WindowDestroyedMessage(window));

        return true;
    }

    /// <inheritdoc cref="IAppWindowService.HasWindow(IBluWindow)"/>
    public bool HasWindow(IBluWindow window)
    {
        return _windows.Contains(window);
    }
}