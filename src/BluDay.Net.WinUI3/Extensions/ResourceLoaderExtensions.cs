using BluDay.Net.WinUI3.Common;
using Microsoft.Windows.ApplicationModel.Resources;
using System;

namespace BluDay.Net.WinUI3.Extensions;

/// <summary>
/// A utility with method extensions for the <see cref="ResourceLoader"/> type.
/// </summary>
public static class ResourceLoaderExtensions
{
    /// <inheritdoc cref="ResourceLoader.GetString(string)"/>
    /// <param name="source">
    /// The object providing access to the application resource loader.
    /// </param>
    public static string GetLocalizedString(this IApplicationResourceAware source, string resourceId)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(resourceId);

        return source.ResourceLoader.GetString(resourceId);
    }

    /// <summary>
    /// Gets a URI instance from a resource string.
    /// </summary>
    /// <param name="source">
    /// The object providing access to the application resource loader.
    /// </param>
    /// <param name="resourceId">
    /// The resource identifier.
    /// </param>
    /// <param name="kind">
    /// The URI kind.
    /// </param>
    /// <returns>
    /// A <see cref="Uri"/> instance configured by the localized string.
    /// </returns>
    public static Uri GetUriFromLocalizedString(
        this IApplicationResourceAware source,
             string                    resourceId,
             UriKind                   kind)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(resourceId);

        return new Uri(source.ResourceLoader.GetString(resourceId));
    }
}