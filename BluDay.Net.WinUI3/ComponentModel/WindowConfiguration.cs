namespace BluDay.Net.WinUI3.ComponentModel;

/// <summary>
/// Represents initial configuration for a window.
/// </summary>
public sealed class WindowConfiguration
{
    /// <summary>
    /// Gets a value indicating whether the content extends into the title bar area.
    /// </summary>
    public bool ExtendsContentIntoTitleBar { get; init; }

    /// <summary>
    /// Gets the window title.
    /// </summary>
    public string? Title { get; init; }

    /// <summary>
    /// Gets the app icon path for the title bar.
    /// </summary>
    public Uri? IconPath { get; init; }

    /// <summary>
    /// Gets the initial alignment to be set for the window.
    /// </summary>
    public ContentAlignment? InitialAlignment { get; init; }

    /// <summary>
    /// Gets the size of the window.
    /// </summary>
    public SizeInt32? Size { get; init; }
}