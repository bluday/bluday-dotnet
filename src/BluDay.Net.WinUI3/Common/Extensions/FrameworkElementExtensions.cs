namespace BluDay.Net.WinUI3.Common.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="FrameworkElement"/> type.
/// </summary>
public static class FrameworkElementExtensions
{
    /// <summary>
    /// Gets the bounding box of a given <see cref="FrameworkElement"/>, optionally scaled.
    /// </summary>
    /// <param name="source">
    /// The <see cref="FrameworkElement"/> whose bounding box is to be determined.
    /// </param>
    /// <param name="scale">
    /// A scaling factor applied to the bounding box dimensions. If negative, defaults to 1.
    /// </param>
    /// <returns>
    /// A <see cref="RectInt32"/> representing the bounding box of the element, scaled accordingly.
    /// </returns>
    public static RectInt32 GetBoundingBox(this FrameworkElement source, double scale)
    {
        ArgumentNullException.ThrowIfNull(source);

        scale = scale < 0 ? 1 : scale;

        Rect rect = source
            .TransformToVisual(visual: null)
            .TransformBounds(new Rect(
                x:      0,
                y:      0,
                width:  source.ActualWidth,
                height: source.ActualHeight
            ));

        return new RectInt32(
            _X:      (int)(rect.X      * scale),
            _Y:      (int)(rect.Y      * scale),
            _Width:  (int)(rect.Width  * scale),
            _Height: (int)(rect.Height * scale)
        );
    }
}