using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Sulmar.WPFMVVM.ShopPracz.WPFClient.Converters
{
    public class SegmentStateToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Models.SegmentState state = (Models.SegmentState) value;

            switch(state)
            {
                case Models.SegmentState.FailureA: return new SolidColorBrush(Colors.Orange);
                case Models.SegmentState.FailureB: return new SolidColorBrush(Colors.Red);

                default: return new SolidColorBrush(Colors.Green);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
