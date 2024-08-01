namespace BluDay.Net.Extensions;

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
    /// The implementation type.
    /// </param>
    /// <param name="serviceType">
    /// The service type to check against.
    /// </param>
    /// <returns>
    /// <c>true</c> if valid, <c>false</c> otherwise.
    /// </returns>
    public static bool IsImplementationType(this Type source, Type serviceType)
    {
        return source != serviceType
            && source.IsClass
            && source.IsAbstract is false
            && source.IsAssignableTo(serviceType);
    }

    /// <summary>
    /// Gets all implementation types from the calling assembly and the entry assembly, as an enumerable.
    /// </summary>
    /// <param name="source">
    /// The service type.
    /// </param>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> with all of the found types.
    /// </returns>
    public static IEnumerable<Type> GetImplementationTypes(this Type source)
    {
        IEnumerable<Type> types = source.Assembly.GetTypes();

        if (Assembly.GetEntryAssembly() is Assembly entryAssembly)
        {
            types = types.Union(entryAssembly.GetTypes());
        }

        return types.Where(type => type.IsImplementationType(source));
    }
}