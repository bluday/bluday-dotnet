namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Represents a provider for resolving implementation instances of a service type.
/// </summary>
public interface IImplementationProvider
{
    /// <summary>
    /// Gets the shared service type.
    /// </summary>
    Type ServiceType { get; }

    /// <summary>
    /// Gets an enumerable of implementation types and their object factories.
    /// </summary>
    IEnumerable<Type> ImplementationTypes { get; }

    /// <summary>
    /// Resolves an instance of the specificed implementation type.
    /// </summary>
    /// <param name="implementationType">
    /// The type of implementation to resolve.
    /// </param>
    /// <returns>
    /// An instance of the resolved implementation if found, <c>null</c> otherwise.
    /// </returns>
    /// <exception cref="InvalidImplementationTypeException">
    /// If <paramref name="implementationType"/> is not assignable to the shared service type.
    /// </exception>
    object? GetInstance(Type implementationType);
}