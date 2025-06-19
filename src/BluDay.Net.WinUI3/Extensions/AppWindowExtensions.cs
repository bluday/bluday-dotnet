using Microsoft.UI.Windowing;
using System;
using Windows.Graphics;

namespace BluDay.Net.WinUI3.Extensions;

public static class AppWindowExtensions
{
    public static DisplayArea GetDisplayArea(this AppWindow source)
    {
        return source.GetDisplayArea(DisplayAreaFallback.Nearest);
    }

    public static DisplayArea GetDisplayArea(this AppWindow source, DisplayAreaFallback displayAreaFallback)
    {
        ArgumentNullException.ThrowIfNull(source);

        return DisplayArea.GetFromWindowId(source.Id, displayAreaFallback);
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