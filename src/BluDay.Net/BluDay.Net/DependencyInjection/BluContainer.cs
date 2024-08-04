namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Represents a Dependency Injection (DI) container with information of registered services and more.
/// </summary>
public class BluContainer
{
    private IKeyedServiceProvider? _serviceProvider;

    protected readonly BluContainerServices _coreServices = new();

    protected readonly BluContainerServices _userServices = new();

    /// <summary>
    /// Gets the root service provider instance.
    /// </summary>
    public IKeyedServiceProvider? ServiceProvider => _serviceProvider;

    /// <summary>
    /// Gets a value indicative whether the container has been activated.
    /// </summary>
    public bool IsActivated => _serviceProvider is not null;

    /// <summary>
    /// Creates the root service provider and initializes the container with all registered service services.
    /// </summary>
    /// <remarks>
    /// Will return if the provider already has been created.
    /// </remarks>
    public IKeyedServiceProvider CreateServiceProvider()
    {
        if (_serviceProvider is not null)
        {
            return _serviceProvider;
        }

        ServiceCollection services = [
            .._coreServices.Descriptors,
            .._userServices.Descriptors
        ];

        return _serviceProvider = services.BuildServiceProvider();
    }
}