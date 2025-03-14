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
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> or <paramref name="factory"/> is null.
    /// </exception>
    public static IServiceCollection Add(this IServiceCollection source, Action<IServiceCollection> factory)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(factory);

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
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static IServiceCollection AddDesktopClientServices(this IServiceCollection source)
    {
        ArgumentNullException.ThrowIfNull(source);

        source
            .TryAddAppActivationService(Assembly.GetCallingAssembly());

        source
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
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static IServiceCollection AddViewModels(this IServiceCollection source)
    {
        ArgumentNullException.ThrowIfNull(source);

        Assembly assembly = Assembly.GetCallingAssembly();

        IEnumerable<Type> viewModelTypes = typeof(ViewModel).GetImplementationTypes(assembly);

        foreach (var viewModelType in viewModelTypes)
        {
            source.AddTransient(viewModelType);
        }

        return source;
    }

    /// <summary>
    /// Registers all views of type <typeparamref name="TView"/> found in the calling assembly.
    /// </summary>
    /// <param name="source">
    /// The service collection to which the views will be added.
    /// </param>
    /// <returns>
    /// The updated service collection to allow for chained calls.
    /// </returns>
    /// <typeparam name="TView">
    /// The base type for the views to be registered.
    /// </typeparam>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static IServiceCollection AddViews<TView>(this IServiceCollection source)
        where TView : class
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.AddViews<TView>(Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// Registers all views of type <typeparamref name="TView"/> found in the specified assembly.
    /// </summary>
    /// <param name="source">
    /// The service collection to which the views will be added.
    /// </param>
    /// <param name="assembly">
    /// The assembly to search for implementations of <typeparamref name="TView"/>. 
    /// If null, the calling assembly is used by default.
    /// </param>
    /// <returns>
    /// The updated service collection to allow for chained calls.
    /// </returns>
    /// <typeparam name="TView">
    /// The base type for the views to be registered.
    /// </typeparam>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static IServiceCollection AddViews<TView>(this IServiceCollection source, Assembly assembly)
        where TView : class
    {
        ArgumentNullException.ThrowIfNull(source);

        assembly ??= Assembly.GetCallingAssembly();

        IEnumerable<Type> viewTypes = typeof(TView).GetImplementationTypes(assembly);

        Index viewNameIndexFromEnd = new(Strings.View.Length, fromEnd: true);

        foreach (var viewType in viewTypes)
        {
            if (viewType.Name[viewNameIndexFromEnd..] is Strings.View)
            {
                source.AddTransient(viewType);
            }
        }

        return source;
    }

    /// <summary>
    /// Attempts to register both app activation handlers and the app activation service
    /// if the handlers are found.
    /// </summary>
    /// <param name="source">
    /// The service collection to which the handlers will be added.
    /// </param>
    /// <param name="assembly">
    /// The assembly to search for handler implementations.
    /// </param>
    /// <returns>
    /// The updated service collection, allowing for chained calls.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is null.
    /// </exception>
    public static IServiceCollection TryAddAppActivationService(
        this IServiceCollection source,
             Assembly           assembly)
    {
        ArgumentNullException.ThrowIfNull(source);

        Type? activationHandlerType = typeof(IAppActivationHandler)
            .GetImplementationTypes(assembly)
            .FirstOrDefault();

        Type? deactivationHandlerType = typeof(IAppDeactivationHandler)
            .GetImplementationTypes(assembly)
            .FirstOrDefault();

        if (activationHandlerType is null || deactivationHandlerType is null)
        {
            return source;
        }

        source
            .AddSingleton(typeof(IAppActivationHandler), activationHandlerType)
            .AddSingleton(typeof(IAppDeactivationHandler), deactivationHandlerType);

        source
            .AddSingleton<IAppActivationService, AppActivationService>();

        return source;
    }
}
