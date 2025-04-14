namespace BluDay.Net.WinUI3.Common.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="ServiceCollection"/> type.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <inheritdoc cref="Net.Common.Extensions.ServiceCollectionExtensions.AddViews{TView}(IServiceCollection)"/>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="source"/> is <c>null</c>.
    /// </exception>
    public static IServiceCollection AddViews(this IServiceCollection source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.AddViews<UserControl>(Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// Registers all derived window control types from the calling assembly.
    /// </summary>
    /// <param name="source">
    /// The targeted instance.
    /// </param>
    /// <returns>
    /// The service collection instance.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static IServiceCollection AddWindows(this IServiceCollection source)
    {
        ArgumentNullException.ThrowIfNull(source);

        IEnumerable<Type> windowTypes = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .Where(type => type.Name.Contains(nameof(Window)));

        foreach (var windowType in windowTypes)
        {
            source.AddTransient(windowType);
        }

        return source;
    }
}