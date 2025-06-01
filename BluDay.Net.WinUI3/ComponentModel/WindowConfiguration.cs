namespace BluDay.Net.WinUI3.ComponentModel;

/// <summary>
/// Represents initial configuration for a <see cref="Window"/> control.
/// </summary>
public sealed class WindowConfiguration
{
    /// <inheritdoc cref="Window.SystemBackdrop"/>
    public SystemBackdrop? SystemBackdrop { get; init; }

    /// <inheritdoc cref="Window.ExtendsContentIntoTitleBar"/>
    public bool ExtendsContentIntoTitleBar { get; init; }

    /// <inheritdoc cref="Window.Title"/>
    public string? Title { get; init; }
}