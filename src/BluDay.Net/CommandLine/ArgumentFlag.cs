namespace BluDay.Net.CommandLine;

public readonly struct ArgumentFlag
{
    public ArgumentFlagKind Kind { get; }

    public string Name { get; }

    public ArgumentFlag(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        // TODO: Validate name.

        if (name.Length > 2)
        {
            Kind = ArgumentFlagKind.Long;
        }

        Name = name;
    }
}