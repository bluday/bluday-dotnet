using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using System.Threading.Tasks;

namespace BluDay.Net.WinUI3.Extensions;

public static class ServiceProviderExtensions
{
    public static Task<TApp> RunWinUI3AppAsync<TApp>(this IKeyedServiceProvider source)
        where TApp : Application
    {
        ArgumentNullException.ThrowIfNull(source);

        return source
            .GetRequiredService<WinUI3ApplicationFactory<TApp>>()
            .CreateAsync(source.GetRequiredService<TApp>);
    }
}