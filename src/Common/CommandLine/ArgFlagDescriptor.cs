using BluDay.Net.Common.Extensions;

namespace BluDay.Net.Common.CommandLine;

public sealed class ArgFlagDescriptor
{
    public string? LongFlag { get; }

    public string? ShortFlag { get; }

    public string? PrimaryFlag { get; }

    public ArgFlagDescriptor(string descriptor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(descriptor);

        string[] flags = descriptor.Split(Constants.VERTICAL_BAR_CHAR);

        string primaryFlag = flags[0];

        if (!primaryFlag.IsAlphanumeric())
        {
            throw new ArgumentException();
        }

        string? secondaryFlag = flags.Length > 1 ? flags[1] : null;

        if (secondaryFlag is not null)
        {
            if (!secondaryFlag.IsAlphanumeric())
            {
                throw new ArgumentException();
            }

            if (primaryFlag.Length > secondaryFlag.Length)
            {
                throw new ArgumentException();
            }
        }

        LongFlag = secondaryFlag;

        ShortFlag = primaryFlag;

        PrimaryFlag = primaryFlag;
    }
}