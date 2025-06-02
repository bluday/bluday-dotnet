namespace BluDay.Net.WinUI3.ComponentModel;

/// <summary>
/// Represents initial configuration for an <see cref="AppWindow"/> instance.
/// </summary>
public sealed class AppWindowConfiguration
{
    /// <summary>
    /// Gets or initializes the title bar configuration instance.
    /// </summary>
    public AppWindowTitleBarConfiguration? TitleBar { get; init; }

    /// <inheritdoc cref="AppWindow.Size"/>
    public SizeInt32? Size { get; init; }

    /// <summary>
    /// Gets the icon path for the title bar.
    /// </summary>
    public string? IconPath { get; init; }

    /// <inheritdoc cref="AppWindow.Title"/>
    public string? Title { get; init; }
}