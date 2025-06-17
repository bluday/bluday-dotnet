namespace BluDay.Net.WinUI3.Common.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="AppWindow"/> type.
/// </summary>
public static class AppWindowExtensions
{
    /// <inheritdoc cref="Resize(AppWindow, int, int, double?)"/>
    /// <summary>
    /// Resizes the app window using the provided width and height values.
    /// </summary>
    public static void Resize(this AppWindow source, int width, int height)
    {
        ArgumentNullException.ThrowIfNull(source);

        source.Resize(width, height, scaleFactor: null);
    }

    /// <summary>
    /// Resizes the app window using the provided width, height and scale factor values.
    /// </summary>
    /// <param name="source">
    /// The targeted window.
    /// </param>
    /// <param name="width">
    /// The new pixel width to be set.
    /// </param>
    /// <param name="height">
    /// The new pixel height to be set.
    /// </param>
    /// <param name="scaleFactor">
    /// The scale factor to apply if set.
    /// </param>
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