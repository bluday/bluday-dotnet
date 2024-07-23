namespace BluDay.Net.Abstractions.UI.Windowing;

/// <summary>
/// Represents a window factory for creating windows of a concrete type.
/// </summary>
/// <typeparam name="TWindow">
/// The concrete window type.
/// </typeparam>
public interface IWindowFactory<out TWindow> : IWindowFactory where TWindow : IWindow
{
    /// <summary>
    /// Creates a new window instance of the concrete type.
    /// </summary>
    /// <returns>
    /// An <see cref="TWindow"/> instance of the created window.
    /// </returns>
    TWindow Create();

    /// <param name="config">
    /// The configuration instance for the window.
    /// </param>
    /// <inheritdoc cref="Create()"/>
    TWindow Create(WindowConfiguration config);
}