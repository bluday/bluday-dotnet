using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace BluDay.Net.WinUI3.Converters;

public sealed class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (parameter is string shouldNegateValueLiteral && shouldNegateValueLiteral == bool.TrueString)
        {
            return value is true ? Visibility.Collapsed : Visibility.Visible;
        }

        return value is true ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}