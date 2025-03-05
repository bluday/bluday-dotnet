namespace BluDay.Net.Messaging.Messages;

/// <summary>
/// Represents a message that is sent when the current application theme has been changed.
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