using BluDay.Net.Common.Extensions;

namespace BluDay.Net.DependencyInjection;

/// <inheritdoc cref="IImplementationProvider{TService}"/>
public class ImplementationProvider<TService> : IImplementationProvider<TService> where TService : notnull
{
    private readonly Type _serviceType;

    private readonly IReadOnlyDictionary<Type, ObjectFactory> _typeToObjectFactoryMap;

    private readonly IServiceProvider _serviceProvider;

    public Type ServiceType => _serviceType;

    public IReadOnlyList<Type> ImplementationTypes => _typeToObjectFactoryMap.Keys.ToList();

    /// <summary>
    /// Initializes a new instance of the <see cref="ImplementationProvider{TService}"/> class.
    /// </summary>
    /// <param name="serviceProvider">
    /// The <see cref="IServiceProvider"/> used for resolving implementation instances.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="serviceProvider"/> is null.
    /// </exception>
    public ImplementationProvider(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        _serviceType = typeof(TService);

        _typeToObjectFactoryMap = _serviceType
            .GetImplementationTypes()
            .ToDictionary(
                type => type,
                CreateImplementationResolver
            );

        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Resolves an instance of the specificed <paramref name="implementationType"/>.
    /// </summary>
    /// <param name="implementationType">
    /// The type of implementation to resolve.
    /// </param>
    /// <returns>
    /// An instance of the resolved implementation.
    /// </returns>
    private object ResolveInstance(Type implementationType)
    {
        ObjectFactory factory = _typeToObjectFactoryMap[implementationType];

        return factory.Invoke(_serviceProvider, arguments: null);
    }

    /// <summary>
    /// Creates an implementation resolver for the specificed <paramref name="implementationType"/>.
    /// </summary>
    /// <param name="implementationType">
    /// The type of implementation to resolve.
    /// </param>
    /// <returns>
    /// An implementation resolver function.
    /// </returns>
    private static ObjectFactory CreateImplementationResolver(Type implementationType)
    {
        Type genericFactoryType = typeof(ObjectFactory<>).MakeGenericType(implementationType);

        ObjectFactory factory = ActivatorUtilities.CreateFactory(genericFactoryType, argumentTypes: []);

        return (serviceProvider, args) =>
        {
            return factory.Invoke(serviceProvider, args)!;
        };
    }

    public object GetInstance(Type implementationType)
    {
        if (!implementationType.IsAssignableTo(_serviceType))
        {
            throw new InvalidImplementationTypeException(implementationType, _serviceType);
        }

        return ResolveInstance(implementationType);
    }

    public TImplementation GetInstance<TImplementation>() where TImplementation : TService
    {
        return (TImplementation)ResolveInstance(typeof(TImplementation));
    }
}