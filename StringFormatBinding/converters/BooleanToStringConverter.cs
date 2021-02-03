using System;
using System.Globalization;
using Xamarin.Forms;

namespace StringFormatBinding.converters
{
    public class BooleanToStringConverter :  IValueConverter
    {
        public BooleanToStringConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                //var con = (MopDTO)value;
                bool val = (bool)value;
                if (val)
                {
                    return "Carta en uso";
                }
                else
                {
                    return " ";
                }
            }
            else
            {
                return " ";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
}
