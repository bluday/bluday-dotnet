namespace BluDay.Net.DependencyInjection;

public class ImplementationProvider<TService> : IImplementationProvider<TService> where TService : notnull
{
    private readonly Type _serviceType;

    private readonly IReadOnlyDictionary<Type, ObjectFactory> _typeToObjectFactoryMap;

    private readonly IServiceProvider _serviceProvider;

    public Type ServiceType => _serviceType;

    public IReadOnlyList<Type> ImplementationTypes => _typeToObjectFactoryMap.Keys.ToList();

    public ImplementationProvider(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        _serviceType = typeof(TService);

        _typeToObjectFactoryMap = CreateMappedObjectFactorySites();

        _serviceProvider = serviceProvider;
    }

    private object ResolveInstance(Type implementationType)
    {
        ObjectFactory factory = _typeToObjectFactoryMap[implementationType];

        return factory.Invoke(_serviceProvider, arguments: null);
    }

    private IReadOnlyDictionary<Type, ObjectFactory> CreateMappedObjectFactorySites()
    {
        return _serviceType
            .GetImplementationTypes()
            .Select(ObjectFactorySiteFactory.Create<TService>)
            .ToDictionary(
                site => site.Info.ImplementationType,
                site => site.Factory
            )
            .AsReadOnly();
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