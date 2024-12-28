namespace BluDay.Net.WinUI3.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="IServiceProvider"/> type.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Creates a new task that represents the asynchronous creation of the app.
    /// </summary>
    /// <param name="source">
    /// A service provider instance.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous creation of the <typeparamref name="TApp"/> instance.
    /// </returns>
    /// <typeparam name="TApp">
    /// The derived <see cref="Application"/> type for the WinUI 3 app.
    /// </typeparam>
    public static Task<TApp> CreateWinui3AppAsync<TApp>(this IServiceProvider source) where TApp : Application
    {
        return Winui3Application.CreateAsync(source.GetRequiredService<TApp>);
    }
}