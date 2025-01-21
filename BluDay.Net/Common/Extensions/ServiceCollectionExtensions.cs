namespace BluDay.Net.Extensions;

/// <summary>
/// A utility class with method extensions for the <see cref="IServiceCollection"/> type.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers multiple service descriptors to a service collection using the provided callback.
    /// </summary>
    /// <param name="source">
    /// The targeted instance.
    /// </param>
    /// <param name="factory">
    /// The service descriptor configuring function.
    /// </param>
    /// <returns>
    /// The service collection instance.
    /// </returns>
    public static IServiceCollection Add(this IServiceCollection source, Action<IServiceCollection> factory)
    {
        factory(source);

        return source;
    }

    /// <summary>
    /// Registers all view model types from the calling assembly.
    /// </summary>
    /// <param name="source">
    /// The targeted instance.
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