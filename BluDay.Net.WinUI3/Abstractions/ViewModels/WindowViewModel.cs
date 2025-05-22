namespace BluDay.Net.WinUI3.Abstractions.ViewModels;

/// <summary>
/// Represents the base view model class of a WinUI 3 window control.
/// </summary>
public abstract partial class WindowViewModel : ObservableObject, IBluWindow
{
    #region Fields
    private WindowManager? _windowManager;

    private AppWindow? _appWindow;

    private AppWindowTitleBar? _appWindowTitleBar;

    private Window? _window;

    private Uri? _iconPath;

    private bool _hasRegisteredEventHandlers;
    #endregion

    #region Observable properties
    /// <summary>
    /// Gets or sets the system backdrop of the window.
    /// </summary>
    [ObservableProperty]
    public partial SystemBackdrop? SystemBackdrop { get; set; }

    /// <summary>
    /// Gets the title bar control of the current window.
    /// </summary>
    [ObservableProperty]
    public partial UIElement? TitleBarControl { get; set; }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the default configuration instance.
    /// </summary>
    public WindowConfiguration? DefaultConfiguration { get; protected set; }

    /// <inheritdoc cref="AppWindow.Id"/>
    public WindowId? Id
    {
        get => _appWindow?.Id;
    }

    /// <inheritdoc cref="AppWindowPresenter.Kind"/>
    public AppWindowPresenterKind? PresenterKind
    {
        get => _appWindow?.Presenter.Kind;
    }

    /// <inheritdoc cref="Window.ExtendsContentIntoTitleBar"/>
    public bool ExtendsContentIntoTitleBar
    {
        get => _appWindowTitleBar?.ExtendsContentIntoTitleBar ?? false;
        set
        {
            if (_appWindowTitleBar is not null)
            {
                _appWindowTitleBar.ExtendsContentIntoTitleBar = value;
            }

            OnPropertyChanged();
        }
    }

    /// <inheritdoc cref="AppWindow.IsVisible"/>
    public bool? IsVisible
    {
        get => _appWindow?.IsVisible;
    }

    /// <inheritdoc cref="XamlRoot.RasterizationScale"/>
    public double? RasterizationScale
    {
        get => _window?.Content?.XamlRoot.RasterizationScale;
    }

    /// <inheritdoc cref="AppWindow.Title"/>
    public string? Title
    {
        get => _appWindow?.Title;
        set
        {
            if (_appWindow is not null)
            {
                _appWindow.Title = value;
            }

            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets the current icon path of the window.
    /// </summary>
    public Uri? IconPath
    {
        get => _iconPath;
        set
        {
            _appWindow?.SetIcon(value?.AbsolutePath);

            _iconPath = value;

            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the size of the current window in screen coordinates.
    /// </summary>
    public SizeInt32? Size
    {
        get => _appWindow?.Size;
        set
        {
            if (_appWindow is null || value is not SizeInt32 size)
            {
                return;
            }

            Resize(size.Width, size.Height);

            OnPropertyChanged();
        }
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowViewModel"/> class.
    /// </summary>
    public WindowViewModel()
    {
        SystemBackdrop = new MicaBackdrop();
    }
    #endregion

    #region Event handlers
    private void _window_Activated(object sender, WindowActivatedEventArgs args)
    {
        ApplyDefaultConfiguration();

        OnPropertyChanged(string.Empty);
    }

    private void _window_Closed(object sender, WindowEventArgs args)
    {
        UnregisterEventHandlers();
    }
    #endregion

    #region Private methods
    private void RegisterEventHandlers()
    {
        if (_window is null || _hasRegisteredEventHandlers)
        {
            return;
        }

        _window.Activated += _window_Activated;
        _window.Closed    += _window_Closed;

        _hasRegisteredEventHandlers = true;
    }

    private void UnregisterEventHandlers()
    {
        if (_window is null || !_hasRegisteredEventHandlers)
        {
            return;
        }

        _window.Activated -= _window_Activated;
        _window.Closed    -= _window_Closed;

        _hasRegisteredEventHandlers = false;
    }
    #endregion

    #region Public methods
    /// <summary>
    /// Attempts to activate the shell and bring it into the foreground.
    /// </summary>
    public void Activate()
    {
        _window?.Activate();
    }

    /// <summary>
    /// Applies default configuration values that was provided at instantiation.
    /// </summary>
    public void ApplyDefaultConfiguration()
    {
        if (DefaultConfiguration is WindowConfiguration config)
        {
            Configure(config);
        }
    }

    /// <summary>
    /// Closes the shell instance.
    /// </summary>
    public void Close()
    {
        _window?.Close();
    }

    /// <summary>
    /// Configures the shell using the provided properties.
    /// </summary>
    /// <param name="config">
    /// The configuration instance.
    /// </param>
    public void Configure(WindowConfiguration config)
    {
        ExtendsContentIntoTitleBar = config.ExtendsContentIntoTitleBar;
        IconPath                   = config.IconPath;
        Size                       = config.Size;
        Title                      = config.Title;
    }

    /// <summary>
    /// Hides the window.
    /// </summary>
    public void Hide()
    {
        _appWindow?.Hide();

        OnPropertyChanged(nameof(IsVisible));
    }

    /// <summary>
    /// Moves the shell to the provided x and y coordinates on the screen.
    /// </summary>
    /// <param name="x">
    /// The x coordinate.
    /// </param>
    /// <param name="y">
    /// The y coordinate.
    /// </param>
    public void Move(int x, int y)
    {
        _appWindow?.Move(new PointInt32(x, y));
    }

    /// <summary>
    /// Resizes the window using the provided width and height integer values.
    /// </summary>
    /// <param name="width">
    /// The target width of the window.
    /// </param>
    /// <param name="height">
    /// The target height of the window.
    /// </param>
    public void Resize(int width, int height)
    {
        _windowManager?.Resize(width, height);
    }

    /// <summary>
    /// Resizes the window using a scaling factor.
    /// </summary>
    /// <param name="width">
    /// The base width before scaling.
    /// </param>
    /// <param name="height">
    /// The base height before scaling.
    /// </param>
    /// <param name="scaleFactor">
    /// The scaling factor to apply.
    /// </param>
    public void Resize(int width, int height, double scaleFactor)
    {
        _windowManager?.Resize(width, height, scaleFactor);
    }

    /// <summary>
    /// Sets the targeted window instance.
    /// </summary>
    /// <param name="window">
    /// The window instance.
    /// </param>
    /// <typeparam name="TWindow">
    /// The derived type of the window control.
    /// </typeparam>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="window"/> is null.
    /// </exception>
    public void SetWindow<TWindow>(TWindow window) where TWindow : Window
    {
        _window = window;

        _windowManager = new WindowManager(window);

        _appWindow = window?.AppWindow;

        _appWindowTitleBar = _appWindow?.TitleBar;

        RegisterEventHandlers();
    }

    /// <summary>
    /// Shows the window.
    /// </summary>
    public void Show()
    {
        _appWindow?.Show();

        OnPropertyChanged(nameof(IsVisible));
    }
    #endregion
}