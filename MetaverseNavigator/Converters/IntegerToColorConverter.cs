using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace MetaverseNavigator
{
    public class IntegerToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine(value);
            long original = (long)value;

            Brush b = (original % 2 == 0) ? (Brushes.Black) : (new SolidColorBrush(Color.FromArgb(250, 20, 20, 20)));
            Console.WriteLine(b.ToString());
            return b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long original = (long)value;
            return (original % 2 == 0) ? (Brushes.Black) : (new SolidColorBrush(Color.FromArgb(250, 0, 0, 0)));
        }
    }
}
