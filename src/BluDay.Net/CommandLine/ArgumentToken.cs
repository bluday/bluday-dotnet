namespace BluDay.Net.CommandLine;

internal readonly struct ArgumentToken
{
    public bool IsFlag { get; }

    public string Value { get; }

    public ArgumentToken(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        IsFlag = value.IsValidArgFlag();

        Value = value;
    }
}