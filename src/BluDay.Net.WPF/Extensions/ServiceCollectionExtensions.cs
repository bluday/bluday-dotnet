using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace BluDay.Net.WPF.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddViews(this IServiceCollection source)
    {
        return source.AddViews(Assembly.GetCallingAssembly());
    }

    public static IServiceCollection AddViews(this IServiceCollection source, Assembly assembly)
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