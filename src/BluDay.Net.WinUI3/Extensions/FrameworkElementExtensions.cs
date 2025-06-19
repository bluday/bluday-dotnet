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

        scale = scale < 0 ? 1 : scale;

        Rect rect = source
            .TransformToVisual(visual: null)
            .TransformBounds(new Rect(
                x: 0,
                y: 0,
                width:  source.ActualWidth,
                height: source.ActualHeight
            ));

        return new RectInt32(
            _X: (int)(rect.X * scale),
            _Y: (int)(rect.Y * scale),
            _Width:  (int)(rect.Width  * scale),
            _Height: (int)(rect.Height * scale)
        );
    }
}