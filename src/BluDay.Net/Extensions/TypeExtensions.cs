using System.Reflection;

namespace BluDay.Net.Extensions;

public static class TypeExtensions
{
    public static bool IsConcreteType(this Type source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.IsClass && !source.IsAbstract && !source.IsInterface;
    }

    public static bool IsImplementationType(this Type source, Type serviceType)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(serviceType);

        return source.IsAssignableTo(serviceType) && source.IsConcreteType();
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