using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Provides access to registered implementations of a given service type by resolving them via a provided
/// service provider. Supports multiple concrete types for a single service contract.
/// </summary>
/// <typeparam name="TService">
/// The service contract type that all resolved implementations must inherit from.
/// </typeparam>
public class ImplementationProvider<TService> where TService : class
{
    private readonly Type _serviceType;

    private readonly Dictionary<Type, Func<object>> _implementationResolvers;

    /// <summary>
    /// Gets an enumerable of the implementation types.
    /// </summary>
    public IEnumerable<Type> ImplementationTypes => _implementationResolvers.Keys;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImplementationProvider{TService}"/> class using the
    /// provided service provider instance for creating concrete factories.
    /// </summary>
    /// <param name="serviceProvider">
    /// The service provider for resolving concrete instances.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="serviceProvider"/> is <c>null</c>.
    /// </exception>
    public ImplementationProvider(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        _serviceType = typeof(TService);

        _implementationResolvers = _serviceType
            .GetConcreteTypes()
            .ToDictionary(
                type => type,
                type => CreateImplementationResolver(type, serviceProvider)
            );
    }

    /// <summary>
    /// Creates a function that resolves an implementation instance of the specified type using
    /// the given <see cref="IServiceProvider"/>.
    /// </summary>
    /// <param name="implementationType">
    /// The concrete implementation type to be resolved.
    /// </param>
    /// <param name="serviceProvider">
    /// The service provider to be used for resolving the implementation.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="implementationType"/> or <paramref name="serviceProvider"/> is
    /// <c>null</c>.
    /// </exception>
    /// <returns>
    /// A delegate that resolves an instance of <paramref name="implementationType"/>.
    /// </returns>
    private static Func<object> CreateImplementationResolver(
        Type             implementationType,
        IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(implementationType);
        ArgumentNullException.ThrowIfNull(serviceProvider);

        return () => serviceProvider.GetRequiredService(implementationType);
    }

    /// <summary>
    /// Resolves and returns a concrete instance of the specified implementation type.
    /// </summary>
    /// <typeparam name="TImplementation">
    /// The type of implementation to resolve, which must inherit from <typeparamref name="TService"/>.
    /// </typeparam>
    /// <exception cref="Exception">
    /// Thrown if the requested implementation type is not registered or cannot be resolved.
    /// </exception>
    /// <returns>
    /// An instance of type <typeparamref name="TImplementation"/>.
    /// </returns>
    public TImplementation GetInstance<TImplementation>() where TImplementation : TService
    {
        if (!_implementationResolvers.TryGetValue(typeof(TImplementation), out Func<object>? resolver))
        {
            throw new Exception();
        }

        return (TImplementation)resolver();
    }
}