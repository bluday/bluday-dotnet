using BluDay.Net.Exceptions;
using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BluDay.Net.DependencyInjection;

public class ImplementationProvider<TService> : IImplementationProvider where TService : notnull
{
    private readonly Type _serviceType;

    private readonly IServiceProvider _serviceProvider;

    private readonly IReadOnlyDictionary<Type, ObjectFactory> _implementationTypeToFactoryMap;

    public Type ServiceType => _serviceType;

    public IEnumerable<Type> ImplementationTypes => _implementationTypeToFactoryMap.Keys;

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

    public TImplementation GetInstance<TImplementation>() where TImplementation : TService
    {
        return (TImplementation)GetInstance(typeof(TImplementation));
    }
}