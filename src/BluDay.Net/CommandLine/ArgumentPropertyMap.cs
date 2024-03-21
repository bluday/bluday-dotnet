namespace BluDay.Net.CommandLine;

public sealed class ArgumentPropertyMap
{
    public IArgument Argument { get; }

    public PropertyInfo TargetProperty { get; }

    public ArgumentPropertyMap(IArgument argument, PropertyInfo targetProperty)
    {
        ArgumentNullException.ThrowIfNull(argument);
        ArgumentNullException.ThrowIfNull(targetProperty);

        Argument = argument;

        TargetProperty = targetProperty;
    }
}