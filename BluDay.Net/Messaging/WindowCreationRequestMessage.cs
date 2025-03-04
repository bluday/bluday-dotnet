namespace BluDay.Net.Messaging;

/// <summary>
/// Represents a request message for creating a window.
/// </summary>
public sealed class WindowCreationRequestMessage : RequestMessage<IBluWindow>
{
    /// <summary>
    /// Gets the targeted window type.
    /// </summary>
    public Type WindowType { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowCreationRequestMessage"/> class.
    /// </summary>
    /// <param name="windowType">
    /// The type of the targeted, derived window class.
    /// </param>
    public WindowCreationRequestMessage(Type windowType)
    {
        ArgumentNullException.ThrowIfNull(windowType);

        WindowType = windowType;
    }
}