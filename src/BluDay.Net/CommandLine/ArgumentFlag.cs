namespace BluDay.Net.CommandLine;

public readonly struct ArgumentFlag
{
    public string? Long { get; }

    public string? Short { get; }

    public string Primary { get; }

    public ArgumentFlag(string descriptor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(descriptor);

        string[] flags = descriptor.Split(Constants.VERTICAL_BAR_CHAR);

        string primary = flags[0];

        if (!primary.IsAlphanumeric())
        {
            throw new ArgumentException();
        }

        string? secondary = flags.Length > 1 ? flags[1] : null;

        if (secondary is not null)
        {
            if (!secondary.IsAlphanumeric())
            {
                throw new ArgumentException();
            }

            if (primary.Length > secondary.Length)
            {
                throw new ArgumentException();
            }
        }

        Long = secondary;

        Short = primary;

        Primary = primary;
    }
}