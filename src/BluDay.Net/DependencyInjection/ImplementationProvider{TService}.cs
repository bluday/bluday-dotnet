namespace BluDay.Net.DependencyInjection;

public class ImplementationProvider<TService> : IImplementationProvider<TService> where TService : notnull
{
    private readonly Type _serviceType;

    private readonly IServiceProvider _serviceProvider;

    private readonly IReadOnlyDictionary<Type, ObjectFactory> _implementationTypeToFactoryMap;

    public Type ServiceType => _serviceType;

    public IEnumerable<Type> ImplementationTypes => _implementationTypeToFactoryMap.Keys;

    /// <summary>
    /// Initializes a new instance of the <see cref="ImplementationProvider{TService}"/> class.
    /// </summary>
    /// <param name="serviceProvider">
    /// The <see cref="IServiceProvider"/> used for resolving the dependencies a registered, concrete type.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="serviceProvider"/> is null.
    /// </exception>
    public ImplementationProvider(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        _serviceType = typeof(TService);

        _implementationTypeToFactoryMap = _serviceType
            .GetImplementationTypes()
            .ToDictionary(type => type, CreateImplementationResolver);

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
        return _implementationTypeToFactoryMap[implementationType].Invoke(_serviceProvider, null);
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
        ObjectFactory factory = ActivatorUtilities.CreateFactory(implementationType, argumentTypes: []);

        return (serviceProvider, args) => factory.Invoke(serviceProvider, args)!;
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