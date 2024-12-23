namespace BluDay.Net.Messaging;

/// <summary>
/// Represents a message to update the application's theme.
/// </summary>
public sealed class AppThemeChangeMessage : ValueChangedMessage<AppTheme>
{
    /// <summary>
    /// Intiializes a new instance of the <see cref="AppThemeChangedMessage"/> class.
    /// </summary>
    /// <param name="value">
    /// The new <see cref="AppTheme"/> value.
    /// </param>
    public AppThemeChangeMessage(AppTheme value) : base(value) { }
}