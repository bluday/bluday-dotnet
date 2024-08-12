namespace BluDay.Net.WinUI3.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="IServiceProvider"/> type.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Starts the application host and instantiates a new <see cref="App"/> instance.
    /// </summary>
    /// <param name="source">
    /// A service provider instance.
    /// </param>
    /// <returns>
    /// The created app instance.
    /// </returns>
    /// <typeparam name="TApp">
    /// The derived <see cref="Application"/> type for the WinUI 3 app.
    /// </typeparam>
    public static TApp CreateWinui3App<TApp>(this IServiceProvider source) where TApp : Application
    {
        return Winui3Application<TApp>.Create(source.GetRequiredService<TApp>);
    }
}