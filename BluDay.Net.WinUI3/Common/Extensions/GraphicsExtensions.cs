namespace BluDay.Net.WinUI3.Common.Extensions;

/// <summary>
/// A utility class with method extensions for types in the <see cref="Windows.Graphics"/> namespace.
/// </summary>
public static class GraphicsExtensions
{
    /// <summary>
    /// The translated X value of the given <paramref name="alignment"/> value.
    /// </summary>
    /// <param name="source">
    /// The size of the targeted window or control. Cannot be <c>null</c>.
    /// </param>
    /// <param name="alignment">
    /// The alignment value.
    /// </param>
    /// <param name="workArea">
    /// The targeted "work" area of a display. Cannot be <c>null</c>.
    /// </param>
    /// <returns>
    /// The translated X value.
    /// </returns>
    public static int GetXFromAlignment(this SizeInt32 source, ContentAlignment alignment, RectInt32 workArea)
    {
        switch (alignment)
        {
            case ContentAlignment.BottomCenter:
            case ContentAlignment.MiddleCenter:
            case ContentAlignment.TopCenter:
                return (workArea.Width - source.Width) / 2;
            case ContentAlignment.BottomRight:
            case ContentAlignment.MiddleRight:
            case ContentAlignment.TopRight:
                return workArea.Width - source.Width;
        }

        return 0;
    }

    /// <summary>
    /// The translated Y value of the given <paramref name="alignment"/> value.
    /// </summary>
    /// <param name="source">
    /// The size of the targeted window or control. Cannot be <c>null</c>.
    /// </param>
    /// <param name="alignment">
    /// The alignment value.
    /// </param>
    /// <param name="workArea">
    /// The targeted "work" area of a display. Cannot be <c>null</c>.
    /// </param>
    /// <returns>
    /// The translated Y value.
    /// </returns>
    public static int GetYFromAlignment(this SizeInt32 source, ContentAlignment alignment, RectInt32 workArea)
    {
        switch (alignment)
        {
            case ContentAlignment.MiddleCenter:
            case ContentAlignment.MiddleLeft:
            case ContentAlignment.MiddleRight:
                return (workArea.Height - source.Height) / 2;
            case ContentAlignment.BottomCenter:
            case ContentAlignment.BottomLeft:
            case ContentAlignment.BottomRight:
                return workArea.Height - source.Height;
        }

        return 0;
    }
}