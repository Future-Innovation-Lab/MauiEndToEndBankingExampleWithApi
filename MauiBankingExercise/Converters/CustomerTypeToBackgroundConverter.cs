using Microsoft.Maui.Graphics;
using System.Globalization;

namespace MauiBankingExercise.Converters
{
    public class CustomerTypeToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string customerTypeName)
            {
                return customerTypeName.ToLower() switch
                {
                    "business" => Color.FromArgb("#FFF8DC"), // Light gold/cream color
                    "individual" => Color.FromArgb("#F5F5F5"), // Light silver/off-white color
                    _ => Colors.White
                };
            }
            return Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}