namespace BluDay.Net.Common.Extensions;

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
    /// The instance of <see cref="IAppWindowService"/> used to create the window. Cannot be <c>null</c>.
    /// </param>
    /// <returns>
    /// A new instance of the specified <typeparamref name="TWindow"/> type.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static TWindow CreateWindow<TWindow>(this IAppWindowService source)
        where TWindow : class
    {
        ArgumentNullException.ThrowIfNull(source);

        return default!;
    }
}