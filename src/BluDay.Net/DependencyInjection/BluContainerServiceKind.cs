namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Represents different kinds of services.
/// </summary>
public enum BluContainerServiceKind
{
    /// <summary>
    /// Represents a core service for an app.
    /// </summary>
    Core,

    /// <summary>
    /// Represents a user-registered service for an app.
    /// </summary>
    User
};