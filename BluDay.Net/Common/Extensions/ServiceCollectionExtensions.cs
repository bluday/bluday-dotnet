namespace BluDay.Net.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="IServiceCollection"/> type.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all view model types from the provided <paramref name="assembly"/>.
    /// </summary>
    /// <param name="source">
    /// The targeted service collection instance.
    /// </param>
    /// <returns>
    /// The service collection instance.
    /// </returns>
    public static IServiceCollection AddViewModels(this IServiceCollection source)
    {
        Assembly assembly = Assembly.GetCallingAssembly();

        foreach (Type viewModelType in typeof(ViewModel).GetImplementationTypes(assembly))
        {
            source.AddTransient(viewModelType);
        }

        return source;
    }
}