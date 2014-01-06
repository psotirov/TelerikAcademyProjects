using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CinemaReserve.Client.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
            {
                return null;
            }
            else if( value == null)
            {
                return Visibility.Collapsed;
            }
            else
            {
                var isVisible = bool.Parse(value.ToString());

                return (isVisible) ? 
                    Visibility.Visible :
                    Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
