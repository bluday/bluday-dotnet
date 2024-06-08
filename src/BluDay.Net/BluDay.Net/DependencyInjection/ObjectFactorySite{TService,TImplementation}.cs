namespace BluDay.Net.DependencyInjection;

public sealed class ObjectFactorySite<TService, TImplementation> : IObjectFactorySite
    where TService        : class
    where TImplementation : TService, new()
{
    private readonly ObjectFactory _implicitFactory;

    public ObjectFactory<TImplementation> Factory { get; }

    public ObjectFactoryInfo<TService, TImplementation> Info { get; }

    IObjectFactoryInfo IObjectFactorySite.Info => Info;

    ObjectFactory IObjectFactorySite.Factory => _implicitFactory;

    public ObjectFactorySite()
    {
        ObjectFactory<TImplementation> factory = CreateImplementationFactory();

        _implicitFactory = CreateImplicitFactory(factory);

        Factory = factory;

        Info = new ObjectFactoryInfo<TService, TImplementation>();
    }

    public static ObjectFactory CreateImplicitFactory(ObjectFactory<TImplementation> factory)
    {
        return (serviceProvider, args) => factory.Invoke(serviceProvider, args)!;
    }

    public static ObjectFactory<TImplementation> CreateImplementationFactory()
    {
        return ActivatorUtilities.CreateFactory<TImplementation>(argumentTypes: []);
    }
}