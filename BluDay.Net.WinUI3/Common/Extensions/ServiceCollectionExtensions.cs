namespace BluDay.Net.WinUI3.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="ServiceCollection"/> type.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all views of type <see cref="UserControl"/>.
    /// </summary>
    /// <param name="source">
    /// The service collection.
    /// </param>
    /// <returns>
    /// The service collection to chained calls.
    /// </returns>
    public static IServiceCollection AddViews(this IServiceCollection source)
    {
        Assembly assembly = Assembly.GetCallingAssembly();

        foreach (Type viewType in typeof(UserControl).GetImplementationTypes(assembly))
        {
            if (viewType.Name[new Index(4, fromEnd: true)..] is not Strings.View)
            {
                continue;
            }

            source.AddTransient(viewType);
        }

        return source;
    }
}