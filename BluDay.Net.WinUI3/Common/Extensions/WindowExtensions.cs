namespace BluDay.Net.WinUI3.Common.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="Window"/> type.
/// </summary>
public static class WindowExtensions
{
    #region Constants
    /// <summary>
    /// Used for setting a new parent for a top-level window.
    /// </summary>
    public const int GWLP_HWNDPARENT = -8;
    #endregion

    #region External methods
    [DllImport("user32.dll")]
    public static extern int GetDpiForWindow(nint hwnd);

    [DllImport("user32.dll")]
    public static extern nint SetWindowLongPtr(nint hWnd, int nIndex, nint dwNewLong);
    #endregion

    #region Public static methods
    /// <summary>
    /// Gets the system-set DPI scale for the target window.
    /// </summary>
    /// <remarks>
    /// The scale range is typically between 100% to 250%, but can be lesser
    /// or greater depending on what the operating system has configured.
    /// </remarks>
    /// <param name="source">
    /// The targted window instance.
    /// </param>
    /// <returns>
    /// The scale factor as a decimal.
    /// </returns>
    public static double GetDpiScaleFactorInDecimal(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return GetDpiForWindow(WindowNative.GetWindowHandle(source)) / 96.0;
    }

    /// <summary>
    /// Sets the parent of the provided window instance.
    /// </summary>
    /// <param name="source">
    /// The child window instance.
    /// </param>
    /// <param name="parent">
    /// The targeted window instance to be set as the new parent.
    /// </param>
    public static void SetParent(this Window source, Window parent)
    {
        ArgumentNullException.ThrowIfNull(source);

        SetWindowLongPtr(
            WindowNative.GetWindowHandle(source),
            GWLP_HWNDPARENT,
            WindowNative.GetWindowHandle(parent)
        );

        void Parent_Closed(object sender, WindowEventArgs e)
        {
            source.Close();

            parent.Closed -= Parent_Closed;
        }

        parent.Closed += Parent_Closed;
    }
    #endregion
}