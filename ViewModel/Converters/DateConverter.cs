using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AutoService.ViewModel.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            return date.ToString("MMMM dd");
        }
        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
