using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BluDay.Net.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection Add(this IServiceCollection source, Action<IServiceCollection> factory)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(factory);

        factory(source);

        return source;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection source)
    {
        ArgumentNullException.ThrowIfNull(source);

        IEnumerable<Type> viewModelTypes = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .Where(type => !type.IsAbstract && type.Name.Contains("ViewModel"));

        foreach (var viewModelType in viewModelTypes)
        {
            source.AddTransient(viewModelType);
        }

        return source;
    }
}
