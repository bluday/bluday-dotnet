namespace BluDay.Net.Messaging.Messages;

/// <summary>
/// Represents a message for a new window that was created in the app.
/// </summary>
public sealed class WindowCreatedMessage : ValueChangedMessage<ulong>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowCreatedMessage"/> class.
    /// </summary>
    /// <param name="window">
    /// The created window instance.
    /// </param>
    public WindowCreatedMessage(IBluWindow window) : base(window.Id) { }
}