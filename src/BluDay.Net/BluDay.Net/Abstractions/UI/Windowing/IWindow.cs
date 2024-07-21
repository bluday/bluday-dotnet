namespace BluDay.Net.Abstractions.UI.Windowing;

/// <summary>
/// Represents the control of a window.
/// </summary>
public interface IWindow : IWindowInfo
{
    /// <summary>
    /// Gets the navigator instance for handling view navigation within the window.
    /// </summary>
    ViewNavigator ViewNavigator { get; }

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
    /// Configures the window using the provided <see cref="WindowConfiguration"/> instance.
    /// </summary>
    /// <param name="config">
    /// The configuration instance.
    /// </param>
    void Configure(WindowConfiguration config);

    /// <summary>
    /// Resizes the window using the provided width and height values.
    /// </summary>
    /// <param name="width">The width of the window, in pixels.</param>
    /// <param name="height">The height of the window, in pixels</param>
    void Resize(int width, int height);
}