namespace BluDay.Net.WinUI3.UI.Windowing;

/// <summary>
/// A utility that manages native window instances, such as retrieving DPI information.
/// </summary>
public sealed class WindowManager
{
    #region Fields
    private readonly AppWindow _appWindow;

    private readonly Window _window;

    private readonly nint _windowHandle;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the targeted window control instance.
    /// </summary>
    public Window Window => _window;

    /// <summary>
    /// Gets the handle of the targeted native window instance.
    /// </summary>
    public nint WindowHandle => _windowHandle;
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowManager"/> class.
    /// </summary>
    /// <param name="window">
    /// The window control instance.
    /// </param>
    public WindowManager(Window window)
    {
        ArgumentNullException.ThrowIfNull(window);

        _appWindow = window.AppWindow;

        _window = window;

        _windowHandle = WindowNative.GetWindowHandle(window);
    }

    #region External methods
    [DllImport("user32.dll")]
    public static extern int GetDpiForWindow(nint hwnd);
    #endregion

    /// <summary>
    /// Resizes the window to the specified dimensions.
    /// </summary>
    /// <param name="width">
    /// The target width of the window.
    /// </param>
    /// <param name="height">
    /// The target height of the window.
    /// </param>
    public void Resize(int width, int height)
    {
        Resize(width, height, GetScaleFactorForWindow(_windowHandle));
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
        width  *= (int)(width  * scaleFactor);
        height *= (int)(height * scaleFactor);

        _appWindow.Resize(new SizeInt32(width, height));
    }

    /// <summary>
    /// Gets the center position for the window.
    /// </summary>
    /// <returns>
    /// The center position as a <see cref="PointInt32"/>.
    /// </returns>
    public PointInt32 GetCenterPositionForWindow()
    {
        return GetCenterPositionForWindow(
            DisplayArea.GetFromWindowId(_appWindow.Id, DisplayAreaFallback.Primary)
        );
    }

    /// <summary>
    /// Calculates the center position of a window within a given display area.
    /// </summary>
    /// <param name="displayArea">
    /// The display area where the window is located.
    /// </param>
    /// <returns>
    /// The center position as a <see cref="PointInt32"/>.
    /// </returns>
    public PointInt32 GetCenterPositionForWindow(DisplayArea displayArea)
    {
        RectInt32 displayWorkArea = displayArea.WorkArea;

        SizeInt32 windowSize = _appWindow.Size;

        return new(
            (displayWorkArea.Width  - windowSize.Width)  / 2,
            (displayWorkArea.Height - windowSize.Height) / 2
        );
    }

    /// <summary>
    /// Gets the scale factor for a given window handle.
    /// </summary>
    /// <param name="windowHandle">
    /// The handle of the window.
    /// </param>
    /// <returns>
    /// The scale factor as a <see cref="double"/>.
    /// </returns>
    public static double GetScaleFactorForWindow(nint windowHandle)
    {
        return GetDpiForWindow(windowHandle) / 96.0;
    }
}