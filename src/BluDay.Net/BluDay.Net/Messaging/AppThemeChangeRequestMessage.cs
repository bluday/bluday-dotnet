namespace BluDay.Net.Messaging;

/// <summary>
/// Represents a message for requesting a theme change of the app.
/// </summary>
public sealed class AppThemeChangeRequestMessage : RequestMessage<AppTheme>
{
    /// <summary>
    /// Gets the app theme value to set.
    /// </summary>
    public AppTheme Value { get; }

    /// <summary>
    /// Intiializes a new instance of the <see cref="AppThemeChangeRequestMessage"/> class.
    /// </summary>
    /// <param name="value">
    /// The new <see cref="AppTheme"/> value to set.
    /// </param>
    public AppThemeChangeRequestMessage(AppTheme value)
    {
        Value = value;
    }
}