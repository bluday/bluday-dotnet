namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Represents a Dependency Injection (DI) container with information of registered services and more.
/// </summary>
public class BluContainer
{
    private IKeyedServiceProvider? _serviceProvider;

    private readonly BluContainerServices _services = new();

    /// <summary>
    /// Gets the root service provider instance.
    /// </summary>
    public IKeyedServiceProvider? ServiceProvider => _serviceProvider;

    /// <summary>
    /// Gets a value indicative whether the container has been activated.
    /// </summary>
    public bool IsActivated => _serviceProvider is not null;

    /// <summary>
    /// Registers the specified service <paramref name="services"/> of the specified service <paramref name="kind"/>.
    /// </summary>
    /// <param name="services">
    /// A <see cref="ServiceDescriptor"/> enumerable of descriptors for all core services.
    /// </param>
    /// <param name="kind">
    /// A <see cref="BluContainerServiceKind"/> value of the service <paramref name="kind"/>.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// If the service provider already has been built.
    /// </exception>
    private BluContainer RegisterServices(IEnumerable<ServiceDescriptor> services, BluContainerServiceKind kind)
    {
        if (_serviceProvider is not null)
        {
            // TODO: Throw a specific exception about how services cannot be registered after building a provider.
            throw new InvalidOperationException();
        }

        foreach (ServiceDescriptor service in services)
        {
            _services.AddService(service, kind);
        }

        return this;
    }

    /// <summary>
    /// Registers core services to the container.
    /// </summary>
    /// <param name="services">
    /// An <see cref="ServiceDescriptor"/> enumerable with services for all of the core services.
    /// </param>
    /// <returns>
    /// The <see cref="BluContainer"/> so that additional calls can be chained.
    /// </returns>
    public BluContainer RegisterCoreServices(IEnumerable<ServiceDescriptor> services)
    {
        return RegisterServices(services, BluContainerServiceKind.Core);
    }

    /// <summary>
    /// Registers user services to the container.
    /// </summary>
    /// <remarks>
    /// Used for registering user specific services after the registration of all core services.
    /// </remarks>
    /// <param name="services">
    /// An <see cref="ServiceDescriptor"/> enumerable with services for all of the core services.
    /// </param>
    /// <returns>
    /// The <see cref="BluContainer"/> so that additional calls can be chained.
    /// </returns>
    public BluContainer RegisterUserServices(IEnumerable<ServiceDescriptor> services)
    {
        return RegisterServices(services, BluContainerServiceKind.User);
    }

    /// <summary>
    /// Creates the root service provider and initializes the container with all registered service services.
    /// </summary>
    /// <remarks>
    /// Will return if the provider already has been created.
    /// </remarks>
    public IKeyedServiceProvider CreateServiceProvider()
    {
        return _serviceProvider ??= _services.CreateServiceCollection().BuildServiceProvider();
    }
}