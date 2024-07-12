namespace BluDay.Net.UI.Windowing;

/// <summary>
/// Represents the control of a window.
/// </summary>
public interface IWindowInfo
{
    /// <summary>
    /// Gets a value indicating whether the window is resizable.
    /// </summary>
    bool IsResizable { get; }

    /// <summary>
    /// Gets the title of the window.
    /// </summary>
    string? Title { get; }

    /// <summary>
    /// Gets the size of the window.
    /// </summary>
    Size Size { get; }
}