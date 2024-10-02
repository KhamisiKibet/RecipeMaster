using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace RecipeMaster.Converters
{
    public class BoolToIconColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isFavorite)
            {
                return isFavorite ? Colors.Red : Colors.Gray; // Set your default grey color
            }
            return Colors.Gray; // Default color
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
