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
    /// <typeparam name="TView">
    /// The underlying view type.
    /// </typeparam>
    public static IServiceCollection AddViews<TView>(this IServiceCollection source) where TView : class
    {
        Assembly assembly = Assembly.GetCallingAssembly();

        foreach (Type viewType in typeof(TView).GetImplementationTypes(assembly))
        {
            if (viewType.Name[new Index(4, fromEnd: true)..] is Strings.View)
            {
                source.AddTransient(viewType);
            }
        }

        return source;
    }
}