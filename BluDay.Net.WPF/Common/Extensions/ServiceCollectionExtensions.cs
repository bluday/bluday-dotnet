namespace BluDay.Net.WPF.Common.Extensions;

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
}