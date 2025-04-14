namespace BluDay.Net.WinUI3.ViewModels;

/// <summary>
/// Represents the base view model class of a WinUI 3 window control.
/// </summary>
public abstract partial class WindowViewModel : ObservableObject
{
    private Window _window;

    private AppWindow _appWindow;

    private AppWindowTitleBar _appWindowTitleBar;

    private DisplayArea _displayArea;

    private OverlappedPresenter _overlappedPresenter;

    private string? _iconPath;

    private ContentAlignment? _alignment;

    protected WindowConfiguration? _defaultConfiguration;

    #region Observable properties
    /// <summary>
    /// Gets the title bar control.
    /// </summary>
    [ObservableProperty]
    public partial UIElement? TitleBarControl { get; set; }
    #endregion

    #region Properties
    /// <inheritdoc cref="Window.ExtendsContentIntoTitleBar"/>
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

    /// <inheritdoc cref="AppWindow.IsVisible"/>
    public bool IsVisible
    {
        get => _appWindow.IsVisible;
    }

    /// <summary>
    /// Gets the current icon path of the window.
    /// </summary>
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

    /// <inheritdoc cref="AppWindow.Title"/>
    public string? Title
    {
        get => _appWindow?.Title;
        set
        {
            _appWindow.Title = value;

            OnPropertyChanged();
        }
    }

    /// <inheritdoc cref="AppWindow.Id"/>
    public ulong? Id
    {
        get => _appWindow.Id.Value;
    }

    /// <summary>
    /// Gets or sets the content aligment of the displayed window.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the size of the current window in screen coordinates.
    /// </summary>
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

    #region Virtual properties
    /// <summary>
    /// Gets the default configuration instance.
    /// </summary>
    public WindowConfiguration? DefaultConfiguration
    {
        get => _defaultConfiguration;
    }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowViewModel"/> class.
    /// </summary>
    public WindowViewModel()
    {
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
        _displayArea = DisplayArea.GetFromWindowId(
            _appWindow.Id,
            DisplayAreaFallback.Nearest
        );
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
        if (_defaultConfiguration is not null)
        {
            Configure(_defaultConfiguration);
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