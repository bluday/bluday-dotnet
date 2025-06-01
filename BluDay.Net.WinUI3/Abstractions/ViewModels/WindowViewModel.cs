namespace BluDay.Net.WinUI3.Abstractions.ViewModels;

/// <summary>
/// Represents the base view model class of a WinUI 3 window control.
/// </summary>
public abstract partial class WindowViewModel : ObservableObject,
    IActivatableWindow,
    IClosableWindow
{
    #region Fields
    private AppWindow _appWindow;

    private Window _window;
    #endregion

    #region Observable properties
    /// <summary>
    /// Gets the title bar control of the current window.
    /// </summary>
    [ObservableProperty]
    public partial UIElement? TitleBarControl { get; set; }

    /// <summary>
    /// Gets or sets the system backdrop of the window.
    /// </summary>
    [ObservableProperty]
    public partial SystemBackdrop? SystemBackdrop { get; set; }

    /// <inheritdoc cref="Window.ExtendsContentIntoTitleBar"/>
    [ObservableProperty]
    public partial bool ExtendsContentIntoTitleBar { get; set; }

    /// <summary>
    /// Gets or sets the current path of the title bar icon.
    /// </summary>
    [ObservableProperty]
    public partial string? IconPath { get; set; }

    /// <inheritdoc cref="Window.Title"/>
    [ObservableProperty]
    public partial string? Title { get; set; }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the default configuration for the <see cref="AppWindow"/> instance.
    /// </summary>
    public AppWindowConfiguration? DefaultAppWindowConfiguration { get; protected set; }

    /// <summary>
    /// Gets the default configuration for the <see cref="Window"/> control.
    /// </summary>
    public WindowConfiguration? DefaultWindowConfiguration { get; protected set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowViewModel"/> class.
    /// </summary>
    public WindowViewModel()
    {
        _appWindow = null!;
        _window    = null!;

        SystemBackdrop = new MicaBackdrop();
    }
    #endregion

    #region Configuration methods
    /// <summary>
    /// Configures the current <see cref="AppWindow"/> instance using the provided
    /// configuration instance.
    /// </summary>
    /// <param name="config">
    /// The configuration instance.
    /// </param>
    public void ConfigureAppWindow(AppWindowConfiguration config)
    {
        IconPath = config.IconPath;

        if (config.Size is SizeInt32 size)
        {
            Resize(size.Width, size.Height);
        }

        _appWindow.Title = config.Title;
    }

    /// <summary>
    /// Configures the current <see cref="Window"/> instance using the provided
    /// configuration instance.
    /// </summary>
    /// <param name="config">
    /// The configuration instance.
    /// </param>
    public void ConfigureWindow(WindowConfiguration config)
    {
        SystemBackdrop             = config.SystemBackdrop;
        ExtendsContentIntoTitleBar = config.ExtendsContentIntoTitleBar;
        Title                      = config.Title;
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

        _appWindow = window.AppWindow;

        OnPropertyChanged(string.Empty);
    }
    #endregion

    #region AppWindow methods
    /// <summary>
    /// Hides the window.
    /// </summary>
    public void Hide()
    {
        _appWindow.Hide();
    }

    /// <summary>
    /// Moves the window to the provided x and y coordinates on the screen.
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
        _appWindow.Resize(width, height);
    }

    /// <summary>
    /// Shows the window.
    /// </summary>
    public void Show()
    {
        _appWindow.Show();
    }
    #endregion

    #region Partial INotifyPropertyChanged methods
    partial void OnIconPathChanged(string? value)
    {
        _appWindow.SetIcon(value);
    }
    #endregion

    #region Window control methods
    /// <summary>
    /// Attempts to activate the shell and bring it into the foreground.
    /// </summary>
    public void Activate()
    {
        _window.Activate();
    }

    /// <summary>
    /// Closes the shell instance.
    /// </summary>
    public void Close()
    {
        _window.Close();
    }
    #endregion
}