using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LotteryAdminApp.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool?) value == true ? Brushes.OrangeRed : Brushes.AliceBlue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
