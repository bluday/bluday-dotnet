namespace BluDay.Net.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="IAppWindowService"/> interface.
/// </summary>
public static class AppWindowServiceExtensions
{
    /// <summary>
    /// Creates and returns a new window instance of the specified type.
    /// </summary>
    /// <typeparam name="TWindow">
    /// The type of window to be created. Must implement the <see cref="IBluWindow"/> interface.
    /// </typeparam>
    /// <param name="source">
    /// The instance of <see cref="IAppWindowService"/> used to create the window.
    /// </param>
    /// <returns>
    /// A new instance of the specified <typeparamref name="TWindow"/> type.
    /// </returns>
    public static TWindow CreateWindow<TWindow>(this IAppWindowService source)
        where TWindow : IBluWindow
    {
        return (TWindow)source.CreateWindow(typeof(TWindow));
    }
}
