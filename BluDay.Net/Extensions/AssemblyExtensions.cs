using System.Reflection;

namespace BluDay.Net.Extensions;

/// <summary>
/// Provides extension methods for retrieving information from <see cref="Assembly"/> instances
/// more easily.
/// </summary>
public static class AssemblyExtensions
{
    /// <summary>
    /// Gets all types defined in the assemblies referenced by the specified <see cref="Assembly"/>.
    /// </summary>
    /// <param name="source">
    /// The assembly whose referenced assemblies will be inspected for types.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// A sequence of <see cref="Type"/> instances representing all types from the referenced
    /// assemblies.
    /// </returns>
    public static IEnumerable<Type> GetReferencedTypes(this Assembly source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source
            .GetReferencedAssemblies()
            .SelectMany(assemblyName => Assembly.Load(assemblyName).GetTypes());
    }
}