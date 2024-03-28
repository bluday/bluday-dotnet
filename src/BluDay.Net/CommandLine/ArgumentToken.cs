namespace BluDay.Net.CommandLine;

public readonly struct ArgumentToken
{
    public bool IsFlag { get; }

    public int Index { get; }

    public string Value { get; }

    public ArgumentToken(string value, int index)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        IsFlag = value.IsValidArgFlag();

        Index = index;

        Value = value;
    }
}