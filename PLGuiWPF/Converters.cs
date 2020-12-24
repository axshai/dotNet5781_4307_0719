using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BO;
namespace PLGuiWPF
{
    public class ListOfStationsToFirstAndLast : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<BusLineStationBO> stations = (value as IEnumerable<BusLineStationBO>).ToList();
            return "from: " + stations[0].StationName + " to: " + stations[stations.Count() - 1].StationName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
