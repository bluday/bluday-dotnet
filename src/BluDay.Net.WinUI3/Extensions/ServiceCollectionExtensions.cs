using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Reflection;

namespace BluDay.Net.WinUI3.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPages(this IServiceCollection source)
    {
        return source.AddPages(Assembly.GetCallingAssembly());
    }

    public static IServiceCollection AddPages(this IServiceCollection source, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(assembly);

        return source.AddConcreteTypes<Page>(ServiceLifetime.Transient, assembly);
    }

    public static IServiceCollection AddWindows(this IServiceCollection source)
    {
        return source.AddWindows(Assembly.GetCallingAssembly());
    }

    public static IServiceCollection AddWindows(this IServiceCollection source, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.AddConcreteTypes<Window>(ServiceLifetime.Transient, assembly);
    }
}