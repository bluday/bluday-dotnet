namespace BluDay.Net.CommandLine;

public readonly struct ArgumentFlag
{
    public ArgumentFlagType Type { get; }

    public string Name { get; }

    public ArgumentFlag(string name)
    {
        ValidateName(name);

        if (name.Length > 2)
        {
            Type = ArgumentFlagType.Long;
        }

        Name = name;
    }

    private static void ValidateName(string name)
    {
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