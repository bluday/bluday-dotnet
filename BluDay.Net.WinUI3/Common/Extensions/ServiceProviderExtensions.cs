namespace BluDay.Net.WinUI3.Common.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="IServiceProvider"/> type.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Creates a new task that represents the asynchronous creation of the app.
    /// </summary>
    /// <typeparam name="TApp">
    /// The derived <see cref="Application"/> type for the WinUI 3 app.
    /// </typeparam>
    /// <param name="source">
    /// A service provider instance. Cannot be <c>null</c>.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous creation of the <typeparamref name="TApp"/>
    /// instance.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static Task<TApp> CreateWinui3AppAsync<TApp>(this IServiceProvider source)
        where TApp : Application
    {
        ArgumentNullException.ThrowIfNull(source);

        return Winui3Application.CreateAsync(source.GetRequiredService<TApp>);
    }
}