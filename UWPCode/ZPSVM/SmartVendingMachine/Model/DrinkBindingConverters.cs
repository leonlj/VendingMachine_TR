using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SmartVendingMachine.Model
{
    public sealed class DoubleToVisibilityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (!value.GetType().Equals(typeof(Double)))
            {
                throw new ArgumentException("Only Double is supported");
            }
            Double discount = (Double) value;
            if (targetType.Equals(typeof(Windows.UI.Xaml.Visibility)))
            {
                return (discount<1) ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                throw new ArgumentException("Unsuported type {0}", targetType.FullName);
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public sealed class DoubleToStringConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (!value.GetType().Equals(typeof(Double)))
            {
                throw new ArgumentException("Only Double is supported");
            }
            Double price = (Double)value;
            return "¥"+Convert.ToDouble(price).ToString("0.0");
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
