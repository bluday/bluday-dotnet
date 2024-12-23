namespace BluDay.Net.Messaging;

/// <summary>
/// Represents a message for a window that was destroyed in the app.
/// </summary>
public sealed class WindowDestroyedMessage : ValueChangedMessage<ulong>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowCreatedMessage"/> class.
    /// </summary>
    /// <param name="windowId">
    /// The id of the destroyed window.
    /// </param>
    public WindowDestroyedMessage(IBluWindow window) : base(window.Id) { }
}