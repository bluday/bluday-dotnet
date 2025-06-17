namespace BluDay.Net.Common.Extensions;

/// <summary>
/// A utility with method extensions for the <see cref="Type"/> type.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Gets a value indicating whether the implementation type is instantiatable and if it is assignable to
    /// the provided <paramref name="serviceType"/>.
    /// </summary>
    /// <param name="source">
    /// The implementation type. Cannot be <c>null</c>.
    /// </param>
    /// <param name="serviceType">
    /// The service type to check against. Cannot be <c>null</c>.
    /// </param>
    /// <returns>
    /// <c>true</c> if valid, <c>false</c> otherwise.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> or <paramref name="serviceType"/> is <c>null</c>.
    /// </exception>
    public static bool IsImplementationType(this Type source, Type serviceType)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(serviceType);

        return source != serviceType
            && source.IsClass
            && source.IsAbstract is false
            && source.IsAssignableTo(serviceType);
    }

    /// <summary>
    /// Gets all implementation types from the calling assembly and the entry assembly, as an enumerable.
    /// </summary>
    /// <param name="source">
    /// The base implementation type for derived types to find. Cannot be <c>null</c>.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> with all of the found types.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<Type> GetImplementationTypes(this Type source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.GetImplementationTypes(Assembly.GetEntryAssembly()!);
    }

    /// <summary>
    /// Gets all implementation types from the provided <paramref name="assembly"/>.
    /// </summary>
    /// <param name="source">
    /// The base implementation type for derived types to find. Cannot be <c>null</c>.
    /// </param>
    /// <param name="assembly">
    /// The assembly to search for the qualifying types in. Cannot be <c>null</c>.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> with all of the found types.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> or <paramref name="assembly"/> is <c>null</c>.
    /// </exception>
    public static IEnumerable<Type> GetImplementationTypes(this Type source, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(assembly);

        return assembly
            .GetTypes()
            .Where(type => type.IsImplementationType(serviceType: source));
    }
}