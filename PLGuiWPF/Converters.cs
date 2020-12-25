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
    public class ListOfStationsToFirst : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<BusLineStationBO> stations = (value as IEnumerable<BusLineStationBO>).ToList();
            return stations[0].StationName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ListOfStationsToLast : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<BusLineStationBO> stations = (value as IEnumerable<BusLineStationBO>).ToList();
            return stations[stations.Count() - 1].StationName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
