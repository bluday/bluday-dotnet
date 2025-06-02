namespace BluDay.Net.WinUI3.ComponentModel;

/// <summary>
/// Represents initial configuration for an <see cref="AppWindowTitleBar"/> instance.
/// </summary>
public sealed class AppWindowTitleBarConfiguration
{
    /// <inheritdoc cref="AppWindowTitleBar.PreferredHeightOption"/>
    public TitleBarHeightOption? PreferredHeightOption { get; init; }
}