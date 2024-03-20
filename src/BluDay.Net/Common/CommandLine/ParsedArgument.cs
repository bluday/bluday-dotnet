namespace BluDay.Net.Common.CommandLine;

public readonly struct ParsedArgument
{
    public bool IsFlag { get; }

    public string Value { get; }

    public ParsedArgument(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        IsFlag = value.IsValidArgFlag();

        Value = value;
    }
}