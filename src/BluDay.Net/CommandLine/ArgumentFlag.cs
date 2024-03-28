namespace BluDay.Net.CommandLine;

public readonly struct ArgumentFlag
{
    public ArgumentFlagType Type { get; }

    public string Name { get; }

    public ArgumentFlag(string name, ArgumentFlagType type)
    {
        InvalidArgumentFlagNameException.ThrowIfInvalid(name);

        Type = type;

        Name = name;
    }

    public static bool IsValidNameCharacter(char value)
    {
        return value is not Constants.EMPTY_CHAR
            || value is not Constants.WHITESPACE_CHAR
            || value is Constants.DASH_CHAR
            || value is Constants.UNDERSCORE_CHAR
            || char.IsAsciiLetterOrDigit(value);
    }

    public static bool HasValidName(string name)
    {
        return name.All(IsValidNameCharacter);
    }
}