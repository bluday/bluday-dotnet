namespace BluDay.Net.CommandLine;

public readonly struct ArgFlag
{
    public string? Alias { get; }

    public string? Full { get; }

    public ArgFlag(string? full, string? alias)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(full);
        ArgumentException.ThrowIfNullOrWhiteSpace(alias);

        Full  = full;
        Alias = alias;
    }
}