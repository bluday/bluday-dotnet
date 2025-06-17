using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BluDay.Net.WinUI3.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPages<TPage>(this IServiceCollection source) where TPage : Page
    {
        return source.AddPages<TPage>(Assembly.GetCallingAssembly());
    }

    public static IServiceCollection AddPages<TPage>(this IServiceCollection source, Assembly assembly)
        where TPage : Page
    {
        ArgumentNullException.ThrowIfNull(source);

        assembly ??= Assembly.GetCallingAssembly();

        IEnumerable<Type> pageTypes = typeof(Page).GetImplementationTypes(assembly);

        Index pageNameIndexFromEnd = new(nameof(Page).Length, fromEnd: true);

        foreach (var pageType in pageTypes)
        {
            if (pageType.Name[pageNameIndexFromEnd..] is nameof(Page))
            {
                source.AddTransient(pageType);
            }
        }

        return source;
    }

    public static IServiceCollection AddWindows(this IServiceCollection source)
    {
        ArgumentNullException.ThrowIfNull(source);

        IEnumerable<Type> windowTypes = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .Where(type => !type.IsAbstract && type.Name.Contains(nameof(Window)));

        foreach (var windowType in windowTypes)
        {
            source.AddTransient(windowType);
        }

        return source;
    }
}