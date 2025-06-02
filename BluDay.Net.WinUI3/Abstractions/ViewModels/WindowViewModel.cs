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

    private AppWindowTitleBar _appWindowTitleBar;

    private Window _window;
    #endregion

    #region Observable properties
    /// <summary>
    /// Gets the title bar control of the current window.
    /// </summary>
    [ObservableProperty]
    public partial UIElement? TitleBarControl { get; set; }

    /// <inheritdoc cref="Window.SystemBackdrop"/>
    [ObservableProperty]
    public partial SystemBackdrop SystemBackdrop { get; set; }


    /// <inheritdoc cref="Window.ExtendsContentIntoTitleBar"/>
    [ObservableProperty]
    public partial bool ExtendsContentIntoTitleBar { get; set; }

    /// <summary>
    /// Gets or sets the current path of the title bar icon.
    /// </summary>
    [ObservableProperty]
    public partial string IconPath { get; set; }

    /// <inheritdoc cref="Window.Title"/>
    [ObservableProperty]
    public partial string Title { get; set; }
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

    /// <inheritdoc cref="AppWindow.TitleBar"/>
    public AppWindowTitleBar TitleBar
    {
        get => _appWindow.TitleBar;
    }

    /// <inheritdoc cref="AppWindow.Size"/>
    public SizeInt32 Size
    {
        get => _appWindow.Size;
        set
        {
            _appWindow.Resize(value);

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
        _appWindow         = null!;
        _appWindowTitleBar = null!;
        _window            = null!;

        IconPath = string.Empty;
        Title    = string.Empty;

        SystemBackdrop = new MicaBackdrop();
    }
    #endregion

    #region Partial property changing/changed callbacks
    partial void OnIconPathChanged(string value)
    {
        if (_appWindow is null) return;

        _appWindow.SetIcon(value);
    }
    #endregion

    #region Event handlers
    private void _window_Activated(object sender, WindowActivatedEventArgs args)
    {
        ApplyDefaultPostActivationAppWindowConfiguration();

        _window.Activated -= _window_Activated;
    }

    private void _window_Closed(object sender, WindowEventArgs args)
    {
        _window.Closed -= _window_Closed;
    }
    #endregion

    #region Configuration methods
    private void RegisterEventHandlers()
    {
        _window.Activated += _window_Activated;
        _window.Closed    += _window_Closed;
    }

    /// <summary>
    /// Configures the current <see cref="AppWindow"/> instance if a default configuration
    /// is available post activation of the current window instance.
    /// </summary>
    public void ApplyDefaultPostActivationAppWindowConfiguration()
    {
        if (DefaultAppWindowConfiguration is AppWindowConfiguration config)
        {
            ConfigureAppWindowPostActivation(config);
        }
    }

    /// <summary>
    /// Configures the current <see cref="AppWindow"/> instance if a default configuration
    /// is available prior to the activation of the current window instance.
    /// </summary>
    public void ApplyDefaultPreActivationAppWindowConfiguration()
    {
        if (DefaultAppWindowConfiguration is AppWindowConfiguration config)
        {
            ConfigureAppWindowPreActivation(config);
        }
    }

    /// <summary>
    /// Configures the current <see cref="Window"/> instance if a default configuration is available.
    /// </summary>
    public void ApplyDefaultWindowConfiguration()
    {
        if (DefaultWindowConfiguration is WindowConfiguration config)
        {
            ConfigureWindow(config);
        }
    }

    /// <summary>
    /// Configures the current <see cref="AppWindow"/> instance using the provided
    /// configuration instance once the current window instance has been activated.
    /// </summary>
    /// <param name="config">
    /// The configuration instance.
    /// </param>
    public void ConfigureAppWindowPostActivation(AppWindowConfiguration config)
    {
        if (config.TitleBar?.PreferredHeightOption is TitleBarHeightOption titleBarHeightOption)
        {
            _appWindowTitleBar.PreferredHeightOption = titleBarHeightOption;
        }
    }

    /// <summary>
    /// Configures the current <see cref="AppWindow"/> instance using the provided
    /// configuration instance.
    /// </summary>
    /// <param name="config">
    /// The configuration instance.
    /// </param>
    public void ConfigureAppWindowPreActivation(AppWindowConfiguration config)
    {
        if (config.Size is SizeInt32 size)
        {
            Size = size;
        }

        if (config.IconPath is string iconPath)
        {
            IconPath = iconPath;
        }

        if (config.Title is string title)
        {
            Title = title;
        }
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
        if (config.ExtendsContentIntoTitleBar.HasValue)
        {
            ExtendsContentIntoTitleBar = config.ExtendsContentIntoTitleBar.Value;
        }

        if (config.SystemBackdrop is SystemBackdrop systemBackdrop)
        {
            SystemBackdrop = systemBackdrop;
        }

        if (config.Title is string title)
        {
            Title = title;
        }
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

        _appWindowTitleBar = _appWindow.TitleBar;

        RegisterEventHandlers();

        ApplyDefaultWindowConfiguration();
        ApplyDefaultPreActivationAppWindowConfiguration();
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
    /// Shows the window.
    /// </summary>
    public void Show()
    {
        _appWindow.Show();
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