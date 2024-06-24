namespace BluDay.Net.DependencyInjection;

/// <inheritdoc />
/// <typeparam name="TService">The shared service type.</typeparam>
public interface IImplementationProvider<TService> : IImplementationProvider where TService : notnull
{
    /// <summary>
    /// Resolves an instance of the specificed generic implementation type.
    /// </summary>
    /// <typeparam name="TImplementation">
    /// A derived type of <see cref="TService"/>.
    /// </typeparam>
    /// <returns>
    /// An instance of the resolved implementation, cast to <typeparamref name="TImplementation"/>.
    /// </returns>
    TImplementation GetInstance<TImplementation>() where TImplementation : TService;
}