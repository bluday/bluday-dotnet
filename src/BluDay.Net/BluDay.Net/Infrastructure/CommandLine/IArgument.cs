namespace BluDay.Net.CommandLine;

/// <summary>
/// Provides information about a particular command-line argument.
/// </summary>
public interface IArgument
{
    /// <summary>
    /// Gets the type of action to perform on a corresponding parsed argument.
    /// </summary>
    ArgumentActionKind ActionKind { get; }

    /// <summary>
    /// Gets the store kind for corresponding argument values.
    /// </summary>
    ArgumentStoreKind StoreKind { get; }

    /// <summary>
    /// Gets a value indicating whether the argument is required.
    /// </summary>
    bool IsRequired { get; }

    /// <summary>
    /// The constant value to set for every parsed store value.
    /// <para>
    /// Used only if <see cref="ActionKind"/> is set to one of the following values:
    /// <list type="bullet">
    ///     <item>
    ///         <see cref="ArgumentActionKind.StoreConstant"/>
    ///     </item>
    ///     <item>
    ///         <see cref="ArgumentActionKind.AppendConstant"/>
    ///     </item>
    /// </list>
    /// </para>
    /// </summary>
    object? Constant { get; }

    /// <summary>
    /// Gets the default value for the argument.
    /// </summary>
    object? DefaultValue { get; }

    /// <summary>
    /// Gets a description of the argument.
    /// </summary>
    string? Description { get; }

    /// <summary>
    /// Gets the name of the argument.
    /// </summary>
    string? Name { get; }

    /// <summary>
    /// Gets the maximum number of values allowed for the argument.
    /// </summary>
    int MaxValueCount { get; }

    /// <summary>
    /// Gets the type of the store value.
    /// </summary>
    Type StoreType { get; }
}