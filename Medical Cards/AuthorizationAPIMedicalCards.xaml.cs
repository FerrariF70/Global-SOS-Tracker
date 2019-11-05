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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppGST
{
    public partial class AuthorizationAPIMedicalCards : Window
    {

        /// <summary>
        /// Constructor AuthorizationAPIMedicalCards
        /// </summary>
        /// <param name="email"></param>
        
        public AuthorizationAPIMedicalCards(string email)
        {
            InitializeComponent();
            user.Text = email;
        }

        #region Events for button background
        private void MouseEnter_Page1(object sender, MouseEventArgs e)
        {
            page1.Background = Brushes.Red;
            page2.Background = Brushes.Black;
        }

        private void MouseLeave_Page1(object sender, MouseEventArgs e)
        {
            page1.Background = Brushes.Black;
            page2.Background = Brushes.Red;
        }
        #endregion

        /// <summary>
        /// Event pass  on page 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            Close();
            new ConncectionToAPIforMedicalCards().ShowDialog();
           
        }

        /// <summary>
        /// Event connection to database and display result about medical card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            (Application.Current.Properties["MedicalCardsViewModel"] as MedicalCardsViewModel).SetParameters(user.Text, user_id.Text, Key.Text);
            
            
        }
    }
}
