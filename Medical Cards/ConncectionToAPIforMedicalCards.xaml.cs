using System;
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

namespace AppGST
{
    public partial class ConncectionToAPIforMedicalCards : Window
    {
        /// <summary>
        /// Constructor ConncectionToAPIforMedicalCards
        /// </summary>
        public ConncectionToAPIforMedicalCards()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connect to Database medical cards and recieving Key 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri uri = new Uri(string.Format("https://medical-data-app.herokuapp.com/getAccessKey?e={0}&p={1}", user.Text, password.Password));
                ConnectToApiMedicalCardDeserialize[] data = RequestsToDataBase.RequestToServer(new ConnectToApiMedicalCardDeserialize(), uri) as ConnectToApiMedicalCardDeserialize[];
                if (data[0].Status.Equals("OK"))
                {
                    page1.IsEnabled = false;
                    MessageBox.Show(data[0].Access + "\n" + data[0].Message, "Response From Server");
                    Close();
                    new AuthorizationAPIMedicalCards(user.Text).ShowDialog();
                }
                else
                {
                    MessageBox.Show(data[0].Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection to Server", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        /// <summary>
        /// Pass on page 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page2_Button(object sender, RoutedEventArgs e)
        {
            Close();
            AuthorizationAPIMedicalCards authorization = new AuthorizationAPIMedicalCards(null);
            authorization.user.IsEnabled = false;
            authorization.user_id.IsEnabled = false;
            authorization.Key.IsEnabled = false;
            authorization.subbmitButton.IsEnabled = false;
            authorization.ShowDialog();
        }

        #region Events for button selection pages
        private void MouseEnter_Page2(object sender, MouseEventArgs e)
        {
            page2.Background = Brushes.Red;
            page1.Background = Brushes.Black;
        }

        private void MouseLeave_Page2(object sender, MouseEventArgs e)
        {
            page1.Background = Brushes.Red;
            page2.Background = Brushes.Black;
        }
        #endregion
    }
}
