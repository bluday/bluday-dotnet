namespace BluDay.Net.CommandLine;

public readonly struct ArgumentFlag
{
    public ArgumentFlagType Type { get; }

    public string Name { get; }

    public ArgumentFlag(string name, ArgumentFlagType type)
    {
        ValidateName(name);

        Type = type;

        Name = name;
    }

    private static void ValidateName(string name)
    {
        throw new NotImplementedException();

        // throw new InvalidArgumentFlagNameException(name);
    }

    public static bool HasValidName(string name)
    {
        try
        {
            ValidateName(name);
        }
        catch
        {
            return false;
        }

        return true;
    }
}