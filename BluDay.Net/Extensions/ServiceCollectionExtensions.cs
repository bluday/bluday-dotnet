using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> or <paramref name="factory"/> is <c>null</c>.
    /// </exception>
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
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/>, <paramref name="lifetime"/> or <paramref name="assembly"/> is
    /// <c>null</c>.
    /// </exception>
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
    /// Registers a factory delegate for the specified service type that resolves instances using the
    /// <see cref="IServiceProvider"/> at runtime.
    /// </summary>
    /// <typeparam name="TService">
    /// The service type to register a factory for.
    /// </typeparam>
    /// <param name="source">
    /// The service collection to register the factory with.
    /// </param>
    /// <param name="lifetime">
    /// The service lifetime to apply to the registration.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddFactory<TService>(this IServiceCollection source, ServiceLifetime lifetime)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(source);

        source.TryAddTransient<TService>();

        Func<IServiceProvider, Func<TService>> implementationFactory =
            serviceProvider => serviceProvider.GetRequiredService<TService>;

        source.Add(ServiceDescriptor.Describe(
            serviceType: typeof(Func<TService>),
            implementationFactory,
            lifetime
        ));

        return source;
    }

    /// <summary>
    /// Registers a factory delegate for the specified service type as a singleton, using the
    /// <see cref="IServiceProvider"/> to resolve instances.
    /// </summary>
    /// <typeparam name="TService">
    /// The service type to register as singleton.
    /// </typeparam>
    /// <param name="source">
    /// The service collection to register the singleton factory with.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddFactoryAsSingleton<TService>(this IServiceCollection source)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.AddFactory<TService>(ServiceLifetime.Singleton);
    }

    /// <summary>
    /// Registers a factory delegate for the specified service type as transient, using the
    /// <see cref="IServiceProvider"/> to resolve instances.
    /// </summary>
    /// <typeparam name="TService">
    /// The service type to register as transient.
    /// </typeparam>
    /// <param name="source">
    /// The service collection to register the transient factory with.
    /// </param>
    /// <returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddFactoryAsTransient<TService>(this IServiceCollection source)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.AddFactory<TService>(ServiceLifetime.Transient);
    }

    /// <summary>
    /// Registers all concrete view model types from the calling assembly in the service collection.
    /// </summary>
    /// <param name="source">
    /// The service collection to register view models with.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddViewModels(this IServiceCollection source)
    {
        ArgumentNullException.ThrowIfNull(source);

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
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> or <paramref name="assembly"/> is <c>null</c>.
    /// </exception>
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
