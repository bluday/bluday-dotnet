namespace BluDay.Net.CommandLine;

public readonly struct ArgumentFlag
{
    public ArgumentFlagType Type { get; }

    public string Name { get; }

    public ArgumentFlag(string name, ArgumentFlagType type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Type = type;

        Name = name;
    }

    public static bool HasValidName(string value)
    {
        return false;
    }
}