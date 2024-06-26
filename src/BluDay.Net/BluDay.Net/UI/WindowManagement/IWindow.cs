namespace BluDay.Net.UI.WindowManagement;

/// <summary>
/// Represents the control of a window.
/// </summary>
public interface IWindow
{
    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    string? Title { get; set; }

    /// <summary>
    /// Gets the ID of the current window.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Activates and shows the current window.
    /// </summary>
    void Activate();

    /// <summary>
    /// Closes the current window.
    /// </summary>
    void Close();

    /// <summary>
    /// Resizes the current window to the provided width and height values.
    /// </summary>
    /// <param name="width">The width of the window, in pixels.</param>
    /// <param name="height">The height of the window, in pixels</param>
    void Resize(int width, int height);
}