namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Represents information for a service registered in a <see cref="BluContainer"/> instance.
/// </summary>
public sealed class BluContainerService : IEquatable<BluContainerService>
{
    /// <summary>
    /// Gets the kind of the registered service.
    /// </summary>
    public BluContainerServiceKind Kind { get; }

    /// <summary>
    /// Gets the descriptor of the registered service.
    /// </summary>
    public ServiceDescriptor Descriptor { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BluContainerService"/> class.
    /// </summary>
    /// <param name="descriptor">
    /// A <see cref="ServiceDescriptor"/> instance for the service descriptor.
    /// </param>
    /// <param name="kind">
    /// A <see cref="BluContainerServiceKind"/> value with the service type.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If <paramref name="descriptor"/> is null.
    /// </exception>
    public BluContainerService(ServiceDescriptor descriptor, BluContainerServiceKind kind)
    {
        ArgumentNullException.ThrowIfNull(descriptor);

        Kind = kind;

        Descriptor = descriptor;
    }

    public bool Equals(BluContainerService? other)
    {
        return Descriptor == other?.Descriptor;
    }
}