using BluDay.Net.Common.Exceptions;

namespace BluDay.Net.DependencyInjection;

/// <summary>
/// Represents a provider for resolving implementations of a shared service type.
/// </summary>
public interface IImplementationProvider
{
    /// <summary>
    /// Gets the shared service type.
    /// </summary>
    Type ServiceType { get; }

    /// <summary>
    /// Gets a read-only dictionary of implementation types and their object factories.
    /// </summary>
    IReadOnlyList<Type> ImplementationTypes { get; }

    /// <summary>
    /// Resolves an instance of the specificed <paramref name="implementationType"/>.
    /// </summary>
    /// <param name="implementationType">
    /// The type of implementation to resolve.
    /// </param>
    /// <returns>
    /// An instance of the resolved implementation.
    /// </returns>
    /// <exception cref="InvalidImplementationTypeException">
    /// If <paramref name="implementationType"/> is not assignable to the shared service type.
    /// </exception>
    object GetInstance(Type implementationType);
}