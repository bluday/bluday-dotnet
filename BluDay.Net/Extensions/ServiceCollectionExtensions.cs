using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BluDay.Net.Extensions;

public static class ServiceCollectionExtensions
{
    public const string ViewModel = "ViewModel";

    public static IServiceCollection Add(this IServiceCollection source, Action<IServiceCollection> factory)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(factory);

        factory(source);

        return source;
    }

    public static IServiceCollection AddConcreteTypes<TBase>(
        this IServiceCollection source,
             ServiceLifetime    lifetime,
             Assembly           assembly
    )
        where TBase : class
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(assembly);

        foreach (Type concreteType in typeof(TBase).GetConcreteTypes(assembly))
        {
            source.Add(new ServiceDescriptor(concreteType, concreteType, lifetime));
        }

        return source;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection source)
    {
        return source.AddViewModels(Assembly.GetCallingAssembly());
    }

    public static IServiceCollection AddViewModels(this IServiceCollection source, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(assembly);

        IEnumerable<Type> concreteTypes = assembly
            .GetTypes()
            .Where(type => type.Name.EndsWith("ViewModel") && type.IsConcreteType());

        foreach (Type concreteType in concreteTypes)
        {
            source.AddTransient(concreteType);
        }

        return source;
    }
}
