namespace BluDay.Net.Abstractions.UI.Windowing;

/// <summary>
/// Represents a window factory for creating windows of a concrete type.
/// </summary>
public interface IWindowFactory
{
    /// <summary>
    /// Gets the type of the targeted concrete window type.
    /// </summary>
    Type ConcreteTargetType { get; }

    /// <summary>
    /// Creates a new window instance of the concrete type.
    /// </summary>
    /// <returns>
    /// An <see cref="IWindow"/> instance of the created window.
    /// </returns>
    IWindow CreateImplicit();

    /// <param name="config">
    /// The configuration instance for the window.
    /// </param>
    /// <inheritdoc cref="Create()"/>
    IWindow CreateImplicit(WindowConfiguration config);
}