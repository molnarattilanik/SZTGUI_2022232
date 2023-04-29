using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MintaZH.Converter
{
    public class CanRaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isValid = (bool)value;
            return isValid ? Brushes.Green : Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
