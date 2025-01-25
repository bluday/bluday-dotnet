namespace BluDay.Net.Services;

public sealed class AppWindowService : Service, IAppWindowService
{
    private readonly ImplementationProvider<IBluWindow> _windowFactory;

    private readonly HashSet<IBluWindow> _windows;

    public IBluWindow? MainWindow => _windows.FirstOrDefault();

    public int WindowCount => _windows.Count;

    public IEnumerable<IBluWindow> Windows => _windows;

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

    public TWindow CreateWindow<TWindow>() where TWindow : IBluWindow
    {
        TWindow window = _windowFactory.GetInstance<TWindow>()!;

        _windows.Add(window);

        _messenger.Send(new WindowCreatedMessage(window));

        return window;
    }

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

    public bool HasWindow(IBluWindow window)
    {
        return _windows.Contains(window);
    }
}