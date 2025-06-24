using BluDay.Net.WinUI3.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Input;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Graphics;

namespace BluDay.Net.WinUI3.Abstractions.ViewModels;

/// <summary>
/// Represents the base view model for <see cref="Window"/> controls.
/// </summary>
public abstract partial class WindowViewModel : ObservableObject
{
    private InputNonClientPointerSource _inputNonClientPointerSource;

    private AppWindow _appWindow;

    private AppWindowTitleBar _appWindowTitleBar;

    private Window _window;

    private bool _hasActivated;

    private bool _hasClosed;

    private double _currentDpiScaleFactor;

    private string? _iconPath;

    /// <summary>
    /// Gets the non-client input pointer source instance.
    /// </summary>
    public InputNonClientPointerSource InputNonClientPointerSource => _inputNonClientPointerSource;

    /// <inheritdoc cref="AppWindowTitleBar.PreferredHeightOption"/>
    public TitleBarHeightOption PreferredTitleBarHeight
    {
        get => _appWindowTitleBar?.PreferredHeightOption ?? default;
        set
        {
            if (_appWindowTitleBar is null) return;

            _appWindowTitleBar.PreferredHeightOption = value;

            OnPropertyChanged();
        }
    }

    /// <inheritdoc cref="Window.Content"/>
    public UIElement? Content
    {
        get => _window?.Content;
        set
        {
            if (_window is null) return;

            _window.Content = value;

            OnPropertyChanged();
        }
    }

    /// <inheritdoc cref="AppWindow.Size"/>
    public SizeInt32 Size => _appWindow.Size;

    /// <inheritdoc cref="AppWindowTitleBar.ExtendsContentIntoTitleBar"/>
    public bool ExtendsContentIntoTitleBar
    {
        get => _appWindowTitleBar?.ExtendsContentIntoTitleBar ?? false;
        set
        {
            if (_appWindowTitleBar is null) return;

            _appWindowTitleBar.ExtendsContentIntoTitleBar = value;

            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets a value indicative whether the window has been activated.
    /// </summary>
    public bool HasActivated => _hasActivated;

    /// <summary>
    /// Gets a value indicative whether the window has been closed.
    /// </summary>
    public bool HasClosed => _hasClosed;

    /// <summary>
    /// Gets a value indicative whether the window is currently active.
    /// </summary>
    public bool IsActive => _hasActivated && !_hasClosed;

    /// <summary>
    /// Gets the current DPI scale factor as a decimal value.
    /// </summary>
    public double CurrentDpiScaleFactor => _currentDpiScaleFactor;

    /// <summary>
    /// Gets or sets the absolute or relative path for the application icon.
    /// </summary>
    public string? IconPath
    {
        get => _iconPath;
        set
        {
            _iconPath = value;

            _appWindow.SetIcon(value);

            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the current view model instance.
    /// </summary>
    [ObservableProperty]
    public partial ObservableObject? CurrentViewModel { get; set; }

    /// <summary>
    /// Gets or sets the client title bar control.
    /// </summary>
    [ObservableProperty]
    public partial FrameworkElement? TitleBarControl { get; set; }

    /// <summary>
    /// Gets or sets the root frame control.
    /// </summary>
    [ObservableProperty]
    public partial Frame? RootFrame { get; set; }

    /// <inheritdoc cref="Window.SystemBackdrop"/>
    [ObservableProperty]
    public partial SystemBackdrop? SystemBackdrop { get; set; }

    /// <inheritdoc cref="Window.Title"/>
    [ObservableProperty]
    public partial string Title { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowViewModel"/> class.
    /// </summary>
    public WindowViewModel()
    {
        _inputNonClientPointerSource = null!;

        _appWindow = null!;

        _appWindowTitleBar = null!;

        _window = null!;

        Title = string.Empty;
    }

    private void RegisterEventHandlers()
    {
        _window.Activated += _window_Activated;
        _window.Closed    += _window_Closed;
    }

    private void UnregisterEventHandlers()
    {
        _window.Activated -= _window_Activated;
        _window.Closed    -= _window_Closed;
    }

    private void _window_Activated(object sender, WindowActivatedEventArgs args)
    {
        if (_hasActivated || _hasClosed) return;

        _hasActivated = true;

        _window.DispatcherQueue.TryEnqueue(OnActivated);

        _window.Activated -= _window_Activated;
    }

    private void _window_Closed(object sender, WindowEventArgs args)
    {
        if (!IsActive) return;

        _hasClosed = true;

        OnClosed();

        UnregisterEventHandlers();
    }

    /// <summary>
    /// Called when the window is activated.
    /// </summary>
    protected virtual void OnActivated()
    {
        ApplyDefaultPostActivationConfiguration();
    }

    /// <summary>
    /// Called when the window is closed.
    /// </summary>
    protected virtual void OnClosed() { }

    /// <inheritdoc cref="Window.Activate()"/>
    public void Activate()
    {
        if (IsActive) return;

        _window.Activate();
    }

    /// <inheritdoc cref="InputNonClientPointerSource.ClearAllRegionRects()"/>
    public void ClearAllRegionRects()
    {
        if (!IsActive) return;

        _inputNonClientPointerSource.ClearAllRegionRects();
    }

    /// <inheritdoc cref="InputNonClientPointerSource.ClearRegionRects(NonClientRegionKind)"/>
    public void ClearRegionRects(NonClientRegionKind region)
    {
        if (!IsActive) return;

        _inputNonClientPointerSource.ClearRegionRects(region);
    }

    /// <inheritdoc cref="Window.Close()"/>
    [RelayCommand]
    public void Close()
    {
        if (IsActive) _window.Close();
    }

    /// <summary>
    /// Focuses on the root element of the window.
    /// </summary>
    public void Focus()
    {
        if (!IsActive) return;

        Content?.Focus(FocusState.Programmatic);
    }

    /// <inheritdoc cref="AppWindow.Hide()"/>
    public void Hide()
    {
        _appWindow.Hide();
    }

    /// <summary>
    /// Moves the window to the center of the screen
    /// </summary>
    public void MoveToCenter()
    {
        _appWindow.MoveToCenter();
    }

    /// <inheritdoc cref="Resize(int, int, double?)"/>
    /// <summary>
    /// Resizes the window using the provided width and height values.
    /// </summary>
    public void Resize(int width, int height)
    {
        Resize(width, height, scaleFactor: null);
    }

    /// <summary>
    /// Resizes the window using the provided width, height and scale factor values.
    /// </summary>
    /// <param name="width">
    /// The new width value, in pixels.
    /// </param>
    /// <param name="height">
    /// The new height value, in pixels.
    /// </param>
    /// <param name="scaleFactor">
    /// The scale factor value to scale the width and height values with.
    /// </param>
    public void Resize(int width, int height, double? scaleFactor)
    {
        _appWindow.Resize(width, height, scaleFactor);

        OnPropertyChanged(nameof(Size));
    }

    /// <summary>
    /// Sets the target <see cref="Window"/> instance to configure and maintain.
    /// </summary>
    /// <typeparam name="TWindow">
    /// The derived window type.
    /// </typeparam>
    /// <param name="window">
    /// The window instance.
    /// </param>
    public void SetWindow<TWindow>(TWindow window) where TWindow : Window
    {
        if (_window is not null)
        {
            UnregisterEventHandlers();
        }

        _window = window;

        _appWindow = window.AppWindow;

        _appWindowTitleBar = _appWindow.TitleBar;

        _currentDpiScaleFactor = window.GetDpiScaleFactorInDecimal();

        _inputNonClientPointerSource = InputNonClientPointerSource.GetForWindowId(_appWindow.Id);

        RegisterEventHandlers();
    }

    /// <inheritdoc cref="AppWindow.Show()"/>
    public void Show()
    {
        _appWindow.Show();
    }

    /// <summary>
    /// Applies the default configuration for the window.
    /// </summary>
    public virtual void ApplyDefaultConfiguration()
    {
        ApplyDefaultPreActivationConfiguration();
        ApplyDefaultPostActivationConfiguration();

        ApplyDefaultIcon();
        ApplyDefaultSystemBackdrop();
        ApplyDefaultTitle();
    }

    /// <summary>
    /// Applies the default icon.
    /// </summary>
    public virtual void ApplyDefaultIcon() { }

    /// <summary>
    /// Applies the default post-activation configuration.
    /// </summary>
    public virtual void ApplyDefaultPostActivationConfiguration() { }

    /// <summary>
    /// Applies the default pre-activation configuration.
    /// </summary>
    public virtual void ApplyDefaultPreActivationConfiguration() { }

    /// <summary>
    /// Applies the default system backdrop.
    /// </summary>
    public virtual void ApplyDefaultSystemBackdrop() { }

    /// <summary>
    /// Applies the default title.
    /// </summary>
    public virtual void ApplyDefaultTitle() { }
}