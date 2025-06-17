using System.Reflection;

namespace BluDay.Net.Extensions;

public static class TypeExtensions
{
    public static bool IsImplementationType(this Type source, Type serviceType)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(serviceType);

        return source != serviceType
            && source.IsClass
            && !source.IsAbstract
            && !source.IsInterface
            && source.IsAssignableTo(serviceType);
    }

    public static IEnumerable<Type> GetImplementationTypes(this Type source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.GetImplementationTypes(Assembly.GetEntryAssembly()!);
    }

    public static IEnumerable<Type> GetImplementationTypes(this Type source, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(assembly);

        return assembly.GetTypes().Where(type => type.IsImplementationType(source));
    }
}