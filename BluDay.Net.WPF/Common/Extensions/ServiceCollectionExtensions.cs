namespace BluDay.Net.WPF.Common.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="ServiceCollection"/> type.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <inheritdoc cref="Net.Common.Extensions.ServiceCollectionExtensions.AddViews{TView}(IServiceCollection)"/>
    public static IServiceCollection AddViews(this IServiceCollection source)
    {
        return source.AddViews<UserControl>(Assembly.GetCallingAssembly());
    }
}