namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Represents a collection of <see cref="BluContainerService"/> instances.
/// </summary>
public sealed class BluContainerServices
{
    private readonly HashSet<BluContainerService> _services = new();

    /// <summary>
    /// Gets an enumerable of all registered core services.
    /// </summary>
    public IEnumerable<BluContainerService> CoreServices
    {
        get => _services.Where(service => service.Kind is BluContainerServiceKind.Core);
    }

    /// <summary>
    /// Gets an enumerable of all registered user services.
    /// </summary>
    public IEnumerable<BluContainerService> UserServices
    {
        get => _services.Where(service => service.Kind is BluContainerServiceKind.User);
    }

    /// <summary>
    /// Gets an enumerable of all registered descriptors.
    /// </summary>
    public IEnumerable<ServiceDescriptor> Descriptors
    {
        get => _services.Select(service => service.Descriptor);
    }

    /// <summary>
    /// Adds the specified <paramref name="descriptor"/> as a specific <paramref name="kind"/> of service.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// If a core service and a user service, with the same <paramref name="descriptor"/> instance, has
    /// been detected.
    /// </exception>
    /// <inheritdoc cref="BluContainerService(ServiceDescriptor, BluContainerServiceKind)"/>
    public void AddService(ServiceDescriptor descriptor, BluContainerServiceKind kind)
    {
        BluContainerService service = new(descriptor, kind);

        if (kind is BluContainerServiceKind.User)
        {
            bool isCoreService = _services
                .Where(service => service.Kind is BluContainerServiceKind.Core)
                .Any(service => service.Descriptor == descriptor);

            if (isCoreService)
            {
                // TODO: Create specific exception class or message for this type of exception.

                throw new InvalidOperationException();
            }
        }

        _services.Add(service);
    }

    /// <summary>
    /// Creates a <see cref="IServiceCollection"/> instance containing service descriptors for all of
    /// the registered services.
    /// </summary>
    /// <returns>
    /// An <see cref="IServiceCollection"/> instance with all of the registered services.
    /// </returns>
    public IServiceCollection CreateServiceCollection()
    {
        ServiceCollection services = [.. Descriptors];

        return services;
    }
}