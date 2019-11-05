using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppGST
{
    /// <summary>
    /// Логика взаимодействия для Alarms.xaml
    /// </summary>
    public partial class Alarms : Window
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public Alarms()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Save log every day. about information High Pulse
        /// </summary>
        private void SaveToLog()
        {
            
        }

        /// <summary>
        /// Send log to server every day in 1:00 am
        /// </summary>
        private void SendLogAlarmsPerToDayOnTheServer()
        {

        }

        /// <summary>
        /// Move Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// Event exit buuton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Button(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Foreground = new SolidColorBrush(Colors.Black);
            DropShadowEffect effectShadow = new DropShadowEffect();
            effectShadow.ShadowDepth = 5;
            effectShadow.Color = Colors.Blue;
            effectShadow.BlurRadius = 30;
            b.Effect = effectShadow;
        }

        /// <summary>
        /// Event for button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Button_Leave(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Foreground = new SolidColorBrush(Colors.Snow);
            DropShadowEffect effectShadow = new DropShadowEffect();
            b.Effect = null;
        }

        /// <summary>
        /// Event close table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event for select row from table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedRow(object sender, MouseEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            row.Background = new SolidColorBrush(Colors.Blue);
        }
    }
}
