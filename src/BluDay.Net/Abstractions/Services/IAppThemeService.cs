namespace BluDay.Net.Abstractions.Services;

/// <summary>
/// A service that manages the theme state of an app.
/// </summary>
public interface IAppThemeService
{
    /// <summary>
    /// Gets the current theme.
    /// </summary>
    AppTheme CurrentTheme { get; set; }
}