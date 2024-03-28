namespace BluDay.Net.CommandLine;

public readonly struct ArgumentToken
{
    public bool IsFlag { get; }

    public int Index { get; }

    public string Value { get; }

    public ArgumentToken(string value, int index)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        IsFlag = value.StartsWith(
            Constants.ARG_SHORT_FLAG_PREFIX,
            Constants.ARG_LONG_FLAG_PREFIX
        );

        Index = index;

        Value = value;
    }
}