using BluDay.Net.Common.Exceptions;

namespace BluDay.Net.DependencyInjection;

/// <inheritdoc />
/// <typeparam name="TService">The shared service type.</typeparam>
public interface IImplementationProvider<TService> : IImplementationProvider where TService : notnull
{
    /// <summary>
    /// Resolves an instance of the specified generic implementation type.
    /// </summary>
    /// <typeparam name="TImplementation">
    /// A derived type of <typeparamref name="TService"/>.
    /// </typeparam>
    /// <returns>
    /// An instance of the resolved implementation, cast to <typeparamref name="TImplementation"/>.
    /// </returns>
    /// <exception cref="InvalidImplementationTypeException">
    /// If <typeparamref name="TImplementation"/> is not assignable to <typeparamref name="TService"/>.
    /// </exception>
    TImplementation GetInstance<TImplementation>() where TImplementation : TService;
}