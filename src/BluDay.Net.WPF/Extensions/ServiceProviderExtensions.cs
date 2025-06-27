using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BluDay.Net.WPF.Extensions;

/// <summary>
/// Provides extension methods for creating and initializing WPF applications using
/// a keyed service provider.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Creates and initializes a WPF application instance of the specified type using
    /// the registered <see cref="WpfApplicationFactory"/>.
    /// </summary>
    /// <typeparam name="TApp">
    /// The type of WPF application to create. Must inherit from <see cref="Application"/>.
    /// </typeparam>
    /// <param name="source">
    /// The keyed service provider from which dependencies are resolved.
    /// </param>
    /// <returns>
    /// A fully constructed and initialized instance of <typeparamref name="TApp"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static TApp CreateWpfApp<TApp>(this IKeyedServiceProvider source)
        where TApp : Application
    {
        ArgumentNullException.ThrowIfNull(source);

        return source
            .GetRequiredService<WpfApplicationFactory>()
            .Create(source.GetRequiredService<TApp>);
    }
}