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
using System.Windows.Shapes;
using BO;
using BLApi;
namespace PLGuiWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ShowLineDetails : Window
    {
        BusLineBO showedLine;
        IBL b1 = BLFactory.GetBL("1");
        public ShowLineDetails(BusLineBO currentLine)
        {
            InitializeComponent();
            showedLine = currentLine;
            this.DataContext = showedLine;
        }

        private void stationDelButton_Click(object sender, RoutedEventArgs e)
        {
            cbDelStat.Visibility = Visibility.Visible;
            cbDelStat.IsDropDownOpen = true;


        }

        private void cbDelStat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }


        private void cbDelStat_DropDownClosed(object sender, EventArgs e)
        {
            (sender as ComboBox).Visibility = Visibility.Hidden;
        }

        private void cbAddStat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbAddStat_DropDownClosed(object sender, EventArgs e)
        {
            (sender as ComboBox).Visibility = Visibility.Hidden;
        }

        private void stationAddButton_Click(object sender, RoutedEventArgs e)
        {
            cbAddStat.Visibility = Visibility.Visible;
            cbAddStat.IsDropDownOpen = true;
        }

        private void renameButton_Click(object sender, RoutedEventArgs e)
        {
            tbxRename.Visibility = Visibility.Visible;

        }

        private void tbxRename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)//if he  Press enter
                (sender as TextBox).Visibility = Visibility.Hidden;
        }

        private void schedAddButton_Click(object sender, RoutedEventArgs e)
        {
            NewScheduleWindow w1 = new NewScheduleWindow();
            w1.Show();
           
        }

        private void updateSchelButton_Click(object sender, RoutedEventArgs e)
        {
            FrequencyWindow wnd = new FrequencyWindow((sender as Button).DataContext as BusLineScheduleBO);
            wnd.ShowDialog();
            this.DataContext = b1.GetLine(showedLine.Id);

        }


        private void tbxRename_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            (sender as TextBox).Visibility = Visibility.Hidden;
        }

        private void deleteSchelButton_Click(object sender, RoutedEventArgs e)
        {
            b1.DeleteSchedule((sender as Button).DataContext as BusLineScheduleBO);
            this.DataContext = b1.GetLine(showedLine.Id);
        }
    }
}
