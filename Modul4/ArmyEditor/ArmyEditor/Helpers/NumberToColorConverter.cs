using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ArmyEditor.Helpers
{
    internal class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = double.Parse(value.ToString());
            if (number <= 3)
            {
                return Brushes.Red;
            }
            else if (number <= 7)
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
