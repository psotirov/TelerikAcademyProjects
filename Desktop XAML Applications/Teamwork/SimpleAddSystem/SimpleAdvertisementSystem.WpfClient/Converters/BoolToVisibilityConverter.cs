using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SimpleAdvertisementSystem.WpfClient.Converters
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
                return Visibility.Hidden;
            }
            else
            {
                var isVisible = bool.Parse(value.ToString());

                return (isVisible) ? 
                    Visibility.Visible : 
                    Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
