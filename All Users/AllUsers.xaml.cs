using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace AppGST
{
    /// <summary>
    /// Class all users
    /// </summary>
    public partial class AllUsers : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AllUsers()
        {
            InitializeComponent();
            Application.Current.Properties["AllUsers"] = this;
        }
        /// <summary>
        /// Event efect for button exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Button(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Foreground = new SolidColorBrush(Colors.Black);
            DropShadowEffect effectShadow = new DropShadowEffect();
            effectShadow.Color = Colors.Blue;
            effectShadow.BlurRadius = 100;
            b.Effect = effectShadow;
        }

        /// <summary>
        /// Event efect for button exit
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
        /// Event for moving window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
