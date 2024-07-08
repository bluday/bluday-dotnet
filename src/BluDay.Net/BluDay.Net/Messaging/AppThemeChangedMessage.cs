namespace BluDay.Net.Messaging;

/// <summary>
/// Represents a message to be sent after the current theme of an app has changed.
/// </summary>
public sealed class AppThemeChangedMessage : ValueChangedMessage<AppTheme>
{
    /// <summary>
    /// Intiializes a new instance of the <see cref="AppThemeChangedMessage"/> class.
    /// </summary>
    /// <param name="value">
    /// The new <see cref="AppTheme"/> value.
    /// </param>
    public AppThemeChangedMessage(AppTheme value) : base(value) { }
}