namespace BluDay.Net.UI.Windowing;

/// <summary>
/// Represents configuration for an <see cref="IWindow"/> instance.
/// </summary>
public sealed class WindowConfiguration : IWindowInfo
{
    public bool IsResizable { get; init; } = true;

    public string? Title { get; init; }

    public Size Size { get; init; }
}