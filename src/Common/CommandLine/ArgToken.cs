namespace BluDay.Net.Common.CommandLine;

public readonly struct ArgToken
{
    public bool IsFlag { get; }

    public string Value { get; }

    public ArgToken(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        IsFlag = value.IsValidArgFlag();

        Value = value;
    }
}