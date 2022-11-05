namespace GCL.UI.GitHub
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    /// <summary>
    /// Конвертер Null в Bool значение. Если null будет FALSE, иначе TRUE.
    /// </summary>
    public class NullBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}