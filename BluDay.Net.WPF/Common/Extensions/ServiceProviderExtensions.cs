namespace BluDay.Net.WPF.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="IServiceProvider"/> type.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Starts the application host and instantiates a new <see cref="Application"/> instance.
    /// </summary>
    /// <param name="source">
    /// A service provider instance.
    /// </param>
    /// <typeparam name="TApp">
    /// The derived <see cref="Application"/> type for the WinUI 3 app.
    /// </typeparam>
    public static IServiceProvider CreateWpfApp<TApp>(this IServiceProvider source) where TApp : Application
    {
        WpfApplication.Create(source.GetRequiredService<TApp>);

        return source;
    }
}