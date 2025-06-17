using Microsoft.UI.Windowing;
using System;
using Windows.Graphics;

namespace BluDay.Net.WinUI3.Extensions;

public static class AppWindowExtensions
{
    public static void Resize(this AppWindow source, int width, int height)
    {
        ArgumentNullException.ThrowIfNull(source);

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