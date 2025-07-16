using Microsoft.UI.Xaml;
using System;
using Windows.Foundation;
using Windows.Graphics;

namespace BluDay.Net.WinUI3.Extensions;

public static class FrameworkElementExtensions
{
    public static RectInt32 GetBoundingBox(this FrameworkElement source, double scale)
    {
        ArgumentNullException.ThrowIfNull(source);

        Rect rect = source
            .TransformToVisual(visual: null)
            .TransformBounds(
                new Rect(0, 0, source.ActualWidth, source.ActualHeight)
            );

        scale = scale < 0 ? 1 : scale;

        return new RectInt32(
            _X: (int)(rect.X * scale),
            _Y: (int)(rect.Y * scale),
            _Width:  (int)(rect.Width  * scale),
            _Height: (int)(rect.Height * scale)
        );
    }
}