namespace BluDay.Net.WinUI3.Common.Extensions;

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
            if (!viewType.Name[-4..].Equals("View"))
            {
                continue;
            }

            source.AddTransient(viewType);
        }

        return source;
    }
}