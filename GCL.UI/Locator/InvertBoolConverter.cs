namespace GCL.UI.Locator
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    /// <summary>
    /// Конвертер для инвертирования bool значений.
    /// </summary>
    public class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolValue))
                throw new ArgumentException(value?.GetType().Name);

            return !boolValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}