namespace BluDay.Net.UI.Windowing;

/// <summary>
/// Represents the control of a window.
/// </summary>
public interface IWindow
{
    /// <summary>
    /// Gets the navigator instance for handling view navigation within the window.
    /// </summary>
    IViewNavigator ViewNavigator { get; }

    /// <summary>
    /// Gets a value indicating whether the window is resizable.
    /// </summary>
    bool IsResizable { get; set; }

    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    string? Title { get; set; }

    /// <summary>
    /// Gets the ID of the window.
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
    /// Resizes the window using the provided width and height values.
    /// </summary>
    /// <param name="width">The width of the window, in pixels.</param>
    /// <param name="height">The height of the window, in pixels</param>
    void Resize(int width, int height);
}