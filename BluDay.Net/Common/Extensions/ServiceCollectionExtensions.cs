namespace BluDay.Net.Common.Extensions;

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
    /// Registers all available services for a desktop client.
    /// </summary>
    /// <param name="source">
    /// The targeted instance.
    /// </param>
    /// <returns>
    /// The service collection instance.
    /// </returns>
    public static IServiceCollection AddDesktopClientServices(this IServiceCollection source)
    {
        source
            .AddSingleton<IAppActivationService, AppActivationService>()
            .AddSingleton<IAppDialogService, AppDialogService>()
            .AddSingleton<IAppNavigationService, AppNavigationService>()
            .AddSingleton<IAppThemeService, AppThemeService>()
            .AddSingleton<IAppWindowService, AppWindowService>();

        source
            .AddSingleton<ImplementationProvider<IBluWindow>>();

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

    /// <inheritdoc cref="AddViews{TView}(IServiceCollection, Assembly)"/>
    public static IServiceCollection AddViews<TView>(this IServiceCollection source) where TView : class
    {
        return source.AddViews<TView>(Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// Registers all views of type <see cref="UserControl"/>.
    /// </summary>
    /// <param name="source">
    /// The service collection.
    /// </param>
    /// <param name="assembly">
    /// The targeted assembly to search within.
    /// </param>
    /// <returns>
    /// The service collection to chained calls.
    /// </returns>
    /// <typeparam name="TView">
    /// The underlying view type.
    /// </typeparam>
    public static IServiceCollection AddViews<TView>(this IServiceCollection source, Assembly assembly)
        where TView : class
    {
        assembly ??= Assembly.GetCallingAssembly();

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