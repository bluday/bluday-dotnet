using System.Reflection;

namespace BluDay.Net.Extensions;

public static class TypeExtensions
{
    public static bool IsConcreteType(this Type source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.IsClass && !source.IsAbstract && !source.IsInterface;
    }

    public static IEnumerable<Type> GetConcreteTypes(this Type source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.GetConcreteTypes(Assembly.GetEntryAssembly()!);
    }

    public static IEnumerable<Type> GetConcreteTypes(this Type source, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(assembly);

        return assembly.GetTypes().Where(
            type => type.IsAssignableTo(source) && type.IsConcreteType()
        );
    }
}