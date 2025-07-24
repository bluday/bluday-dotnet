using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BluDay.Net.Extensions;

/// <summary>
/// Provides extension methods for registering concrete types and view models in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Applies the specified factory delegate to configure the service collection.
    /// </summary>
    /// <param name="source">
    /// The service collection to apply the configuration to.
    /// </param>
    /// <param name="factory">
    /// A delegate that defines how to configure the service collection.
    /// </param>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection Add(this IServiceCollection source, Action<IServiceCollection> factory)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(factory);

        factory(source);

        return source;
    }

    /// <summary>
    /// Registers all non-abstract types derived from <typeparamref name="TBase"/> found in the specified assembly
    /// with the given <see cref="ServiceLifetime"/>.
    /// </summary>
    /// <typeparam name="TBase">
    /// The base type used to filter concrete types.
    /// </typeparam>
    /// <param name="source">
    /// The service collection to register the types with.
    /// </param>
    /// <param name="lifetime">
    /// The lifetime to assign to each service descriptor.
    /// </param>
    /// <param name="assembly">
    /// The assembly to search for concrete types.
    /// </param>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
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

    /// <summary>
    /// Registers all concrete view model types from the calling assembly in the service collection.
    /// </summary>
    /// <param name="source">
    /// The service collection to register view models with.
    /// </param>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddViewModels(this IServiceCollection source)
    {
        return source.AddViewModels(Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// Registers all concrete view model types from the specified assembly in the service collection.
    /// View model types are identified by name convention (ending in "ViewModel") and concrete type checks.
    /// </summary>
    /// <param name="source">
    /// The service collection to register view models with.
    /// </param>
    /// <param name="assembly">
    /// The assembly to search for view model types.
    /// </param>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddViewModels(this IServiceCollection source, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(assembly);

        IEnumerable<Type> concreteTypes = assembly.GetTypes().Where(
            type => type.IsConcreteType() && type.Name.EndsWith("ViewModel")
        );

        foreach (Type concreteType in concreteTypes)
        {
            source.AddTransient(concreteType);
        }

        return source;
    }
}
