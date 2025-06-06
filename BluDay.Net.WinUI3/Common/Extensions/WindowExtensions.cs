namespace BluDay.Net.WinUI3.Common.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="Window"/> type.
/// </summary>
public static class WindowExtensions
{
    #region External methods
    [DllImport("user32.dll")]
    public static extern int GetDpiForWindow(IntPtr handle);
    #endregion

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
}