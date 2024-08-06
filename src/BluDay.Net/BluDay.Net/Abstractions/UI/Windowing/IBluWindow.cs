namespace BluDay.Net.UI.Windowing;

/// <summary>
/// Represents the control of a window.
/// </summary>
public interface IBluWindow
{
    /// <summary>
    /// Gets the id of the window.
    /// </summary>
    ulong Id { get; }

    /// <summary>
    /// Activates and shows the current window.
    /// </summary>
    void Activate();

    /// <summary>
    /// Closes the current window.
    /// </summary>
    void Close();

    /// <summary>
    /// Resizes the window using the provided width and height values.
    /// </summary>
    /// <param name="width">The width of the window, in pixels.</param>
    /// <param name="height">The height of the window, in pixels</param>
    void Resize(int width, int height);
}