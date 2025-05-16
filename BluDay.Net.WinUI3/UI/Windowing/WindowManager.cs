namespace BluDay.Net.WinUI3.UI.Windowing;

/// <summary>
/// A utility that manages native window instances, such as retrieving DPI information.
/// </summary>
public sealed class WindowManager
{
    private readonly AppWindow _appWindow;

    private readonly Window _window;

    private readonly nint _windowHandle;

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
    /// 
    /// </summary>
    /// <param name="width">
    /// </param>
    /// <param name="height">
    /// </param>
    public void ResizeUsingScaleFactorValue(int width, int height)
    {
        ResizeUsingScaleFactorValue(width, height, GetScaleFactorForWindow(_windowHandle));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width">
    /// </param>
    /// <param name="height">
    /// </param>
    /// <param name="scaleFactor">
    /// </param>
    public void ResizeUsingScaleFactorValue(int width, int height, double scaleFactor)
    {
        width  *= (int)(width  * scaleFactor);
        height *= (int)(height * scaleFactor);

        _appWindow.Resize(new SizeInt32(width, height));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// </returns>
    public PointInt32 GetCenterPositionForWindow()
    {
        return GetCenterPositionForWindow(
            DisplayArea.GetFromWindowId(_appWindow.Id, DisplayAreaFallback.Primary)
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="displayArea">
    /// </param>
    /// <returns>
    /// '</returns>
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
    /// 
    /// </summary>
    /// <param name="windowHandle">
    /// </param>
    /// <returns>
    /// </returns>
    public static double GetScaleFactorForWindow(nint windowHandle)
    {
        return GetDpiForWindow(windowHandle) / 96.0;
    }
}