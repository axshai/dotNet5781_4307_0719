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

    public class ListOfStationsToRange : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<BusLineStationBO> stations = (value as IEnumerable<BusLineStationBO>).ToList();
            return Enumerable.Range(1, stations.Count() + 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ListOfStationsToBoolean : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<BusLineStationBO> stations = (value as IEnumerable<BusLineStationBO>).ToList();
            return stations.Count() > 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ShortTime : IValueConverter//convert DateTime to DateTime.shortstring For a proper presentation of the bus dates(binding bus textblocks to dates of the bus)
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan t = (TimeSpan)value;
            return t.ToString().Substring(0, 8);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
