namespace BluDay.Net.Attributes;

public sealed class ViewModelAttribute : Attribute
{
    public Type ViewModelType { get; set; } = null!;
}