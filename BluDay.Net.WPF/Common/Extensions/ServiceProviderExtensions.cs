namespace BluDay.Net.WPF.Extensions;

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
    /// The derived <see cref="Application"/> type for the WPF app.
    /// </typeparam>
    public static Task<TApp> CreateWpfAppAsync<TApp>(this IServiceProvider source) where TApp : Application
    {
        return WpfApplication.CreateAsync(source.GetRequiredService<TApp>);
    }
}