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
            .ToDictionary(
                keySelector:     implementationType => implementationType,
                elementSelector: GetImplementationFactory
            );

        _serviceProvider = serviceProvider;
    }

    private static ObjectFactory GetImplementationFactory(Type implementationType)
    {
        ObjectFactory factory = ActivatorUtilities.CreateFactory(
            implementationType,
            argumentTypes: []
        );

        object GetFactory(IServiceProvider serviceProvider, object?[]? args)
        {
            return factory.Invoke(serviceProvider, args)!;
        };

        return GetFactory;
    }

    public object? GetInstance(Type implementationType)
    {
        if (!implementationType.IsAssignableTo(_serviceType))
        {
            throw new InvalidImplementationTypeException(implementationType, _serviceType);
        }

        return _implementationTypeToFactoryMap
            .GetValueOrDefault(implementationType)?
            .Invoke(_serviceProvider, arguments: null);
    }

    public TImplementation? GetInstance<TImplementation>() where TImplementation : TService
    {
        return (TImplementation)GetInstance(typeof(TImplementation))!;
    }
}