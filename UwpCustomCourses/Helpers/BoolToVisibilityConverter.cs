using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UwpCustomCourses.Helpers
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool b && b) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility visibility && visibility == Visibility.Visible;
        }
    }
}
