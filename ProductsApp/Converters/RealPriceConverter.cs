using System.Globalization;
using ProductsApp.Models;

namespace ProductsApp.Converters
{
    public class RealPriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var product = value as Product;

            if (product == null)
                return 0.00;

            return product.OriginalPrice * (1 - product.Discount / 100);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
