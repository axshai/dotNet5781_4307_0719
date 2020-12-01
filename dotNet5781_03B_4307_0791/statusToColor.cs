﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Threading;
using System.Globalization;

namespace dotNet5781_03B_4307_0791
{
    public class statusToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            STATUS st = (STATUS)value;
            switch (st)
            {
                case STATUS.READY:
                    return Brushes.Tan;  
                    
                case STATUS.INDRIVE:
                    return Brushes.Green;
                   
                case STATUS.INREFUEL:
                    return Brushes.Yellow;
                    
                case STATUS.INCARE:
                    return Brushes.PaleTurquoise;
                    
                default:
                    return Brushes.PaleTurquoise;
                  
            }
          
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

   
}
