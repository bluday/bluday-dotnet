namespace BluDay.Net.CommandLine;

public readonly struct ArgumentFlag
{
    public ArgumentFlagType Type { get; }

    public string Name { get; }

    public ArgumentFlag(string name, ArgumentFlagType type)
    {
        if (!HasValidName(name))
        {
            throw new InvalidArgumentFlagNameException(name);
        }

        Type = type;

        Name = name;
    }

    public static bool IsValidNameCharacter(char value)
    {
        return value.IsNotEmptyOrWhitespace()
            || value is Constants.DASH_CHAR
            || value is Constants.UNDERSCORE_CHAR
            || value.IsAlphanumeric();
    }

    public static bool HasValidName(string name)
    {
        return name.All(IsValidNameCharacter);
    }
}