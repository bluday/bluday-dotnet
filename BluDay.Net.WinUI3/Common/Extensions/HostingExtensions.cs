namespace BluDay.Net.WinUI3.Extensions;

/// <summary>
/// A utility class with method extensions for types in the <see cref="Microsoft.Extensions.Hosting"/> namespace.
/// </summary>
public static class HostingExtensions
{
    /// <summary>
    /// Starts the application host and instantiates a <typeparamref name="TApp"/> instance.
    /// </summary>
    /// <param name="source">
    /// The application host instance.
    /// </param>
    /// <returns>
    /// The created app instance.
    /// </returns>
    /// <inheritdoc cref="ServiceProviderExtensions.CreateWinui3App{TApp}(IServiceProvider)"/>
    public static TApp CreateWinui3App<TApp>(this IHost source) where TApp : Application
    {
        return source.Services.CreateWinui3App<TApp>();
    }
}