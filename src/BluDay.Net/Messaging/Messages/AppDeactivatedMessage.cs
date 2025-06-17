namespace BluDay.Net.Messaging.Messages;

/// <summary>
/// Represents a message for when an application has been deactivated.
/// </summary>
/// <remarks>
/// This is typically sent when <see cref="IAppActivationService"/> deactivates an
/// application successfully.
/// </remarks>
public sealed class AppDeactivatedMessage { }