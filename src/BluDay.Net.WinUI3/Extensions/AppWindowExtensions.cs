using Microsoft.UI.Windowing;
using System;
using Windows.Graphics;

namespace BluDay.Net.WinUI3.Extensions;

public static class AppWindowExtensions
{
    public static PointInt32 GetCenterPositionForDisplay(this AppWindow source)
    {
        return source.GetCenterPositionForDisplay(source.GetDisplayArea());
    }

    public static PointInt32 GetCenterPositionForDisplay(this AppWindow source, DisplayArea displayArea)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(displayArea);

        SizeInt32 windowSize = source.Size;

        RectInt32 displayWorkArea = displayArea.WorkArea;

        return new(
            (displayWorkArea.Width  - windowSize.Width)  / 2,
            (displayWorkArea.Height - windowSize.Height) / 2
        );
    }

    public static DisplayArea GetDisplayArea(this AppWindow source)
    {
        return source.GetDisplayArea(DisplayAreaFallback.Nearest);
    }

    public static DisplayArea GetDisplayArea(this AppWindow source, DisplayAreaFallback displayAreaFallback)
    {
        ArgumentNullException.ThrowIfNull(source);

        return DisplayArea.GetFromWindowId(source.Id, displayAreaFallback);
    }

    public static void MoveToCenter(this AppWindow source)
    {
        source.MoveToCenter(source.GetDisplayArea());
    }

    public static void MoveToCenter(this AppWindow source, DisplayArea displayArea)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(displayArea);

        source.Move(source.GetCenterPositionForDisplay(displayArea));
    }

    public static void Resize(this AppWindow source, int width, int height)
    {
        source.Resize(width, height, scaleFactor: null);
    }

    public static void Resize(this AppWindow source, int width, int height, double? scaleFactor)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (scaleFactor.HasValue)
        {
            width  = (int)(width  / scaleFactor);
            height = (int)(height / scaleFactor);
        }

        source.Resize(new SizeInt32(width, height));
    }
}