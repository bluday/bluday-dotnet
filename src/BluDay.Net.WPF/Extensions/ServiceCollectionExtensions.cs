using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
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
}