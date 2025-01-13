namespace BluDay.Net.WinUI3.ViewModels;

/// <summary>
/// Represents the view model class for an app shell control.
/// </summary>
public abstract partial class ShellViewModel : ViewModel
{
    private AppNavigationService _navigationService;

    private ViewNavigator _viewNavigator;

    private Window _window;

    private AppWindow _appWindow;

    private AppWindowTitleBar _appWindowTitleBar;

    private DisplayArea _displayArea;

    private OverlappedPresenter _overlappedPresenter;

    private string? _iconPath;

    private ContentAlignment? _alignment;

    #region Properties
    /// <summary>
    /// Gets the view navigator instance.
    /// </summary>
    public ViewNavigator ViewNavigator => _viewNavigator;

    /// <inheritdoc/>
    public bool ExtendsContentIntoTitleBar
    {
        get => _appWindowTitleBar.ExtendsContentIntoTitleBar;
        set
        {
            _appWindowTitleBar.ExtendsContentIntoTitleBar = value;

            if (value)
            {
                ShowCustomTitleBar();

                return;
            }

            ShowDefaultTitleBar();

            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets a value indicating whether the window is visible.
    /// </summary>
    public bool IsVisible => _appWindow.IsVisible;

    /// <inheritdoc/>
    public string? IconPath
    {
        get => _iconPath;
        set
        {
            _appWindow.SetIcon(value);

            _iconPath = value;

            OnPropertyChanged();
        }
    }

    /// <inheritdoc/>
    public string? Title
    {
        get => _appWindow?.Title;
        set
        {
            _appWindow.Title = value;

            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets the id of the window.
    /// </summary>
    public ulong? Id => _appWindow.Id.Value;

    /// <inheritdoc/>
    public ContentAlignment? Alignment
    {
        get => _alignment;
        set
        {
            if (value is null) return;

            ContentAlignment alignment = value.Value;

            RectInt32 workArea = _displayArea!.WorkArea;

            SizeInt32 windowSize = _appWindow.Size;

            int x = windowSize.GetXFromAlignment(alignment, workArea);
            int y = windowSize.GetYFromAlignment(alignment, workArea);

            Move(x, y);

            _alignment = value;

            OnPropertyChanged();
        }
    }

    /// <inheritdoc/>
    public SizeInt32? Size
    {
        get => _appWindow.Size;
        set
        {
            _appWindow.ResizeClient(value!.Value);

            OnPropertyChanged();
        }
    }
    #endregion

    #region Observable properties
    /// <summary>
    /// Gets the default configuration instance.
    /// </summary>
    [ObservableProperty]
    public partial WindowConfiguration? DefaultConfiguration { get; set; }

    /// <summary>
    /// Gets the title bar control.
    /// </summary>
    [ObservableProperty]
    public partial UIElement? TitleBarControl { get; set; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">
    /// The navigation service.
    /// </param>
    /// <param name="messenger">
    /// The default <see cref="WeakReferenceMessenger"/> instance.
    /// </param>
    public ShellViewModel(
        AppNavigationService   navigationService,
        WeakReferenceMessenger messenger
    )
        : base(messenger)
    {
        _navigationService = navigationService;

        _viewNavigator       = null!;
        _window              = null!;
        _appWindow           = null!;
        _appWindowTitleBar   = null!;
        _displayArea         = null!;
        _overlappedPresenter = null!;
    }

    /// <summary>
    /// Shows the custom <see cref="TitleBar"/> control and hides the default Win32 title bar.
    /// </summary>
    private void ShowCustomTitleBar()
    {
        Windows.UI.Color color = Colors.Transparent;

        _appWindowTitleBar.BackgroundColor               = color;
        _appWindowTitleBar.ButtonBackgroundColor         = color;
        _appWindowTitleBar.ButtonInactiveBackgroundColor = color;

        if (TitleBarControl is not UIElement titleBar)
        {
            return;
        }

        titleBar.Visibility = Visibility.Visible;

        _window.SetTitleBar(titleBar);
    }

    /// <summary>
    /// Shows the defualt Win32 title bar and hides the custom <see cref="TitleBar"/> control.
    /// </summary>
    private void ShowDefaultTitleBar()
    {
        if (TitleBarControl is UIElement titleBar)
        {
            titleBar.Visibility = Visibility.Collapsed;
        }
    }

    /// <summary>
    /// Gets the current <see cref="DisplayArea"/> for this shell and updates
    /// <see cref="_displayArea"/> with the new instance.
    /// </summary>
    private void UpdateDisplayArea()
    {
        _displayArea = DisplayArea.GetFromWindowId(_appWindow.Id, DisplayAreaFallback.Nearest);
    }

    /// <summary>
    /// Attempts to activate the shell and bring it into the foreground.
    /// </summary>
    public void Activate()
    {
        _window.Activate();
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
        _window.Close();
    }

    /// <summary>
    /// Configures the shell using the provided properties.
    /// </summary>
    /// <param name="config">
    /// The configuration instance.
    /// </param>
    public void Configure(WindowConfiguration config)
    {
        Title                      = config.Title;
        ExtendsContentIntoTitleBar = config.ExtendsContentIntoTitleBar;
        IconPath                   = config.IconPath;
        Size                       = config.Size;
        Alignment                  = config.Alignment;
    }

    /// <summary>
    /// Hides the window.
    /// </summary>
    public void Hide()
    {
        _appWindow.Hide();

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
        _appWindow.Move(new PointInt32(x, y));
    }

    /// <summary>
    /// Resizes the shell using the provided width and height integer values.
    /// </summary>
    /// <param name="width">
    /// The width of the shell.
    /// </param>
    /// <param name="height">
    /// The height of the shell.
    /// </param>
    public void Resize(int width, int height)
    {
        _appWindow.Resize(new SizeInt32(width, height));
    }

    /// <summary>
    /// Sets the targeted window instance.
    /// </summary>
    /// <param name="window">
    /// The window instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="window"/> is null.
    /// </exception>
    public void SetWindow<TWindow>(TWindow window) where TWindow : Window, IBluWindow
    {
        ArgumentNullException.ThrowIfNull(window);

        _window = window;

        _viewNavigator = _navigationService.CreateNavigator(window);
        
        _appWindow = window.AppWindow;

        _appWindowTitleBar = _appWindow.TitleBar;

        _overlappedPresenter = (OverlappedPresenter)_appWindow.Presenter;

        UpdateDisplayArea();

        ApplyDefaultConfiguration();

        OnPropertyChanged(string.Empty);
    }

    /// <summary>
    /// Shows the window.
    /// </summary>
    public void Show()
    {
        _appWindow.Show();

        OnPropertyChanged(nameof(IsVisible));
    }
}