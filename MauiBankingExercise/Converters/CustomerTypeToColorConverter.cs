using Microsoft.Maui.Graphics;
using System.Globalization;

namespace MauiBankingExercise.Converters
{
    public class CustomerTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string customerTypeName)
            {
                return customerTypeName.ToLower() switch
                {
                    "business" => Colors.Gold,
                    "individual" => Colors.Silver,
                    _ => Colors.Gray
                };
            }
            return Colors.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}