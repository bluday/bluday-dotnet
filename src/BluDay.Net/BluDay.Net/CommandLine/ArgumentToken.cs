namespace BluDay.Net.CommandLine;

public readonly struct ArgumentToken
{
    public bool IsFlag { get; }

    public int Index { get; }

    public string Value { get; }

    public ArgumentToken(string value) : this(value, -1) { }

    public ArgumentToken(string value, int index)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        index = index >= 0 ? index : -1;

        IsFlag = IsValidFlag(value);

        Index = index;

        Value = value;
    }

    public static bool IsValidFlag(string value)
    {
        return
            value.StartsWith(Constants.ARG_SHORT_FLAG_PREFIX) ||
            value.StartsWith(Constants.ARG_LONG_FLAG_PREFIX);
    }
}