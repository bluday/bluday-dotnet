namespace BluDay.Net.WinUI3.Converters;

/// <summary>
/// Represents a <see cref="bool"> to <see cref="Visibility"/> value converter.
/// </summary>
public sealed class BooleanToVisibilityConverter : IValueConverter
{
    /// <inheritdoc cref="IValueConverter.Convert(object, Type, object, string)"/>
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (parameter is string shouldNegateValueLiteral && shouldNegateValueLiteral == bool.TrueString)
        {
            return value is true ? Visibility.Collapsed : Visibility.Visible;
        }

        return value is true ? Visibility.Visible : Visibility.Collapsed;
    }

    /// <inheritdoc cref="IValueConverter.ConvertBack(object, Type, object, string)"/>
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}