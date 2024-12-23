namespace BluDay.Net.Messaging;

/// <summary>
/// Represents a message for a new window that was created in the app.
/// </summary>
public sealed class WindowCreatedMessage : ValueChangedMessage<ulong>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowCreatedMessage"/> class.
    /// </summary>
    /// <param name="windowId">
    /// The id of the created window.
    /// </param>
    public WindowCreatedMessage(IBluWindow window) : base(window.Id) { }
}