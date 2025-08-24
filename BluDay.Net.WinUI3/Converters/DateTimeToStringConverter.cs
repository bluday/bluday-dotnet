using Microsoft.UI.Xaml.Data;
using System;

namespace BluDay.Net.WinUI3.Converters;

/// <summary>
/// Represents a <see cref="DateTime"/> to <see cref="string"/> value converter.
/// </summary>
public sealed class DateTimeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is DateTime dateTime)
        {
            if (parameter is string format && !string.IsNullOrWhiteSpace(format))
            {
                return dateTime.ToString(format);
            }

            return dateTime.ToString();
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
