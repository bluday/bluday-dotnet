using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using WinRT.Interop;

namespace BluDay.Net.WinUI3.Extensions;

public static class WindowExtensions
{
    public const double STANDARD_DPI = 96.0;

    public const int GWLP_HWNDPARENT = -8;

    [DllImport("user32.dll")]
    public static extern int GetDpiForWindow(nint hwnd);

    [DllImport("user32.dll")]
    public static extern nint SetWindowLongPtr(nint hWnd, int nIndex, nint dwNewLong);

    public static double GetDpiScaleFactorInDecimal(this Window source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return GetDpiForWindow(WindowNative.GetWindowHandle(source)) / STANDARD_DPI;
    }

    public static void SetParent(this Window source, Window parent)
    {
        ArgumentNullException.ThrowIfNull(source);

        SetWindowLongPtr(
            hWnd:      WindowNative.GetWindowHandle(source),
            nIndex:    GWLP_HWNDPARENT,
            dwNewLong: WindowNative.GetWindowHandle(parent)
        );

        void Parent_Closed(object sender, WindowEventArgs e)
        {
            source.Close();

            parent.Closed -= Parent_Closed;
        }

        parent.Closed += Parent_Closed;
    }
}