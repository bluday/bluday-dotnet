namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Represents the implementation class for <see cref="IImplementationProvider"/>.
/// </summary>
public class ImplementationProvider<TService> : IImplementationProvider
    where TService : notnull
{
    private readonly Type _serviceType;

    private readonly IServiceProvider _serviceProvider;

    private readonly IReadOnlyDictionary<Type, ObjectFactory> _implementationTypeToFactoryMap;

    /// <inheritdoc cref="IImplementationProvider.ServiceType"/>
    public Type ServiceType
    {
        get => _serviceType;
    }

    /// <inheritdoc cref="IImplementationProvider.ImplementationTypes"/>
    public IEnumerable<Type> ImplementationTypes
    {
        get => _implementationTypeToFactoryMap.Keys;
    }

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
                elementSelector: CreateImplementationFactory
            );

        _serviceProvider = serviceProvider;
    }

    private static ObjectFactory CreateImplementationFactory(Type implementationType)
    {
        ObjectFactory factory = ActivatorUtilities.CreateFactory(
            implementationType,
            argumentTypes: []
        );

        return (IServiceProvider serviceProvider, object?[]? args) =>
        {
            return factory.Invoke(serviceProvider, args)!;
        };
    }

    /// <inheritdoc cref="IImplementationProvider.GetInstance(Type)"/>
    public object GetInstance(Type implementationType)
    {
        if (!implementationType.IsAssignableTo(_serviceType))
        {
            throw new InvalidImplementationTypeException(implementationType, _serviceType);
        }

        return _implementationTypeToFactoryMap[implementationType].Invoke(
            _serviceProvider,
            arguments: null
        );
    }
}