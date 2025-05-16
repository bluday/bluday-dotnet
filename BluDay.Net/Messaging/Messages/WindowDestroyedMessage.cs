namespace BluDay.Net.Messaging.Messages;

/// <summary>
/// Represents a message for a window that was destroyed in the app.
/// </summary>
public sealed class WindowDestroyedMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowCreatedMessage"/> class.
    /// </summary>
    /// <param name="window">
    /// The instance of the destroyed window.
    /// </param>
    public WindowDestroyedMessage(IBluWindow window) { }
}