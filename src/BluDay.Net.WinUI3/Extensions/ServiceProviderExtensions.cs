using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using System.Threading.Tasks;

namespace BluDay.Net.WinUI3.Extensions;

/// <summary>
/// Provides extension methods for creating and initializing WinUI 3 applications using a keyed
/// service provider.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Asynchronously creates and initializes a WinUI 3 application instance of the specified
    /// type using the registered <see cref="WinUI3ApplicationFactory"/>.
    /// </summary>
    /// <typeparam name="TApp">
    /// The type of WinUI 3 application to create. Must inherit from <see cref="Application"/>.
    /// </typeparam>
    /// <param name="source">
    /// The keyed service provider used to resolve application dependencies.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the
    /// initialized instance of <typeparamref name="TApp"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static Task<TApp> CreateWinUI3AppAsync<TApp>(this IKeyedServiceProvider source)
        where TApp : Application
    {
        ArgumentNullException.ThrowIfNull(source);

        return source
            .GetRequiredService<WinUI3ApplicationFactory>()
            .CreateAsync(source.GetRequiredService<TApp>);
    }
}