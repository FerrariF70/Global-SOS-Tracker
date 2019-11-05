using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AppGST
{
    /// <summary>
    /// Логика взаимодействия для BingMaps.xaml
    /// </summary>
    public partial class BingMaps : UserControl
    {
        /// <summary>
        /// Constructor BingMaps
        /// </summary>
        public BingMaps()
        {
            InitializeComponent();
        }

        #region All events for buttons
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (WorldMap.Mode is RoadMode)
                WorldMap.Mode = new AerialMode();
            else
            {
                WorldMap.Mode = new RoadMode();
            }
        }

        /// <summary>
        /// Zoom map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ZoomPlus(object sender, RoutedEventArgs e)
        {
            WorldMap.ZoomLevel = ++WorldMap.ZoomLevel;
        }

        /// <summary>
        /// Zoom map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ZoomMinus(object sender, RoutedEventArgs e)
        {
            WorldMap.ZoomLevel = --WorldMap.ZoomLevel;
        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            Button button = border.TemplatedParent as Button;
            DropShadowEffect dbe = new DropShadowEffect();
            dbe.Color = Colors.Red;
            dbe.Direction = 380;
            dbe.BlurRadius = 30;
            button.Effect = dbe;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            Button button = border.TemplatedParent as Button;
            DropShadowEffect dbe = new DropShadowEffect();
            button.Effect = null;
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as StackPanel).Opacity = 10;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as StackPanel).Opacity = 0.6;
        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            ((sender as Border).TemplatedParent as Button).Foreground = Brushes.Black;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            ((sender as Border).TemplatedParent as Button).Foreground = Brushes.Snow;
        }
        #endregion

        /// <summary>
        /// Search TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Focus(object sender, RoutedEventArgs e)
        {
            searchText.Text = string.Empty;
        }

       
    }
}
