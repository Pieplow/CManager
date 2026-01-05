
using System.Globalization;
using System.Windows.Data;

namespace CManager.Presentation.GuiApp.Converters
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isCompleted)

                {
                return isCompleted ? "Completed" : "ongoing";
                }

            return "unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
