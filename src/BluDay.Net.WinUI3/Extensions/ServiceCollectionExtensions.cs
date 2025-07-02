using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace BluDay.Net.WinUI3.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddViews<TView>(this IServiceCollection source) where TView : class
    {
        return source.AddViews<TView>(Assembly.GetCallingAssembly());
    }

    public static IServiceCollection AddViews<TView>(this IServiceCollection source, Assembly assembly)
        where TView : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(assembly);

        return source.AddConcreteTypes<TView>(ServiceLifetime.Transient, assembly);
    }
}