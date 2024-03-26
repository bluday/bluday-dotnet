namespace BluDay.Net.CommandLine;

public readonly struct ArgumentFlag
{
    public ArgumentFlagType Type { get; }

    public string Name { get; }

    public ArgumentFlag(string name) : this(name, default) { }

    public ArgumentFlag(string name, ArgumentFlagType type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (name.Length < 2 && type is ArgumentFlagType.Long)
        {
            throw new ArgumentException();
        }

        if (name.IsAlphanumeric() && type is ArgumentFlagType.Symbol)
        {
            throw new ArgumentException();
        }

        Type = type;

        Name = name;
    }
}