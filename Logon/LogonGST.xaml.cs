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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppGST
{
    public partial class LogonGST : Window
    {
        #region Fields
        private char UsersMode { get; set; }
        private bool forgotPassword = false;
        private string EmailOrUser { get; set; }
        private Change_Resetore_Password[] obj;
        private static byte steps = 1;
        private bool wrongKey = false;
        private Uri uri;
        public static MainWindow Window { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public LogonGST()
        {
            
            InitializeComponent();
            UsersMode = ' ';
        }

        /// <summary>
        /// Event for move window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #region Events Shadow Username text and Password text
        private void MouseEnter_PasswordBox(object sender, MouseEventArgs e)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.Color = Colors.Blue;
            effect.BlurRadius = 100;
            (sender as PasswordBox).Effect = effect;
        }

        private void PasswordBox_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as PasswordBox).Effect = null;
        }

       
        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.Color = Colors.Blue;
            effect.BlurRadius = 100;
            (sender as TextBox).Effect = effect;
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as TextBox).Effect = null;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.BlurRadius = 100;
            effect.Color = Colors.Red;
            (sender as Button).Effect = effect;
        }

        #endregion

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Effect = null;
        }

        private void Exit_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Effect = null;
        }

        //Start shadow effect
        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.BlurRadius = 300;
            effect.Color = Colors.Red;
            (sender as Button).Effect = effect;
        }

        //Close window
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region Events for got focus Password text and Username text
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox2.Password = string.Empty;
        }
        #endregion


        /*Login button and Restore Password*/
        private void LoginButton(object sender, RoutedEventArgs e)
        {
            int? user_id;
            bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (networkUp == true)
            {
                if (forgotPassword == false)
                {
                    Authorization authorization = new Authorization();
                    if (authorization.ConnectToServer(textBox.Text, passwordBox2.Password,out user_id))
                    {
                        MainWindow app = new MainWindow();
                        Application.Current.Properties["MainWindow"] = app;
                        app.DataContext = Application.Current.Properties["MainWindowViewModel"] as MainWindowViewModel;
                        app.ID = user_id;
                        app.Show();
                        Close();
                    }
                }
                else
                {
                    if (steps == 1)
                    {
                        RestorePasswordStep1();
                    }
                    else if (steps == 2)
                    {
                        RestorePasswordStep2();
                    }
                    else if (steps == 3)
                    {
                        RestorePasswordStep3();
                    }
                }
            }
            else
            {
                Internet.Text = "Error Connection!";
                Internet.Visibility = Visibility.Visible;
            }
        }

        /*Restore password step 1*/
        private void RestorePasswordStep1()
        {
            string phone = "+";
            EmailOrUser = textBox.Text;
            uri = new Uri(string.Format("https://dbrainz-flora-server-app.herokuapp.com/sendRestoreCode?u={0}", EmailOrUser));
            obj = RequestsToDataBase.RequestToServer(new Change_Resetore_Password(), uri) as Change_Resetore_Password[];
            if (obj[0].Status.Equals("OK"))
            {
                phone += obj[0].PhoneNumber;
                phone = phone.Remove(5, 5);
                phone = phone.Insert(5, "....");
                if (obj[0].Status.Equals("OK"))
                {
                    labalePassword1.Content = "Enter SMS Code";
                    textBox.Visibility = Visibility.Collapsed;
                    passwordBox1.Visibility = Visibility.Visible;

                    ++steps;
                }
            }
            MessageBox.Show($"{obj[0].Message} {phone}", "Response From Server", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /*Restore password step 2*/
        private void RestorePasswordStep2()
        {
            uri = new Uri(string.Format("https://dbrainz-flora-server-app.herokuapp.com/checkRestoreCode?e={0}&restoreCode={1}", EmailOrUser, passwordBox1.Password));
            obj = RequestsToDataBase.RequestToServer(new Change_Resetore_Password(), uri) as Change_Resetore_Password[];
            MessageBox.Show($"{obj[0].Message}", "Response From Server", MessageBoxButton.OK, MessageBoxImage.Information);
            if (obj[0].Status.Equals("OK"))
            {
                wrongPassword.Visibility = Visibility.Hidden;
                labalePassword1.Content = "Enter New Password";
                labalePassword2.Content = "Confirm Password";
                labalePassword2.Visibility = Visibility.Visible;
                passwordBox2.Visibility = Visibility.Visible;
                ++steps;
                passwordBox1.PreviewTextInput -= CheckPassword_Text;
                passwordBox1.Password = string.Empty;
            }
        }

        /*Restore password step 3*/
        private void RestorePasswordStep3()
        {
            if (passwordBox2.Password.Equals(passwordBox1.Password))
            {
                uri = new Uri(string.Format("https://dbrainz-flora-server-app.herokuapp.com/passChange?e={0}&newPass={1}",EmailOrUser,passwordBox1.Password));
                obj = RequestsToDataBase.RequestToServer(new Change_Resetore_Password(), uri) as Change_Resetore_Password[];
                MessageBox.Show($"{obj[0].Message}", "Response From Server", MessageBoxButton.OK, MessageBoxImage.Information);
                if (obj[0].Status.Equals("OK"))
                {
                    textBox.Text = string.Empty;
                    passwordBox2.Password = string.Empty;
                    steps = 1;
                    forgotPassword = false;
                    passwordBox1.Visibility = Visibility.Collapsed;
                    textBox.Visibility = Visibility.Visible;
                    labalePassword1.Content = "Email or Username";
                    labalePassword2.Content = "Password";
                    hyperLinkForgotPassword.Visibility = Visibility.Visible;
                }
            }
            else
                MessageBox.Show("Passwords don't same", "Wrond Password", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /*Hyper Link to forgot password*/
        private void ForgotPassword(object sender, RoutedEventArgs e)
        {
            labalePassword2.Visibility = Visibility.Collapsed;
            passwordBox2.Visibility = Visibility.Collapsed;
            Login.Content = "Send";
            forgotPassword = true;
            hyperLinkForgotPassword.Visibility = Visibility.Collapsed;
        }

        //Visible shadow effect
        private void MouseEnter_PasswordBox1(object sender, MouseEventArgs e)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.Color = Colors.Blue;
            effect.BlurRadius = 100;
            (sender as PasswordBox).Effect = effect;
        }

        //Canceled effect shadow
        private void MouseLeave_PasswodBox1(object sender, MouseEventArgs e)
        {
            (sender as PasswordBox).Effect = null;
        }

        //Check if user enter wrong key
        private void CheckPassword_Text(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(Convert.ToChar(e.Text)) == false)
            {
                wrongKey = true;
                wrongPassword.Visibility = Visibility.Visible;
            }
            else
            {
                wrongKey = false;
            }
        }

        //Delete text if wrong key
        private void previewKeyUpPasswordBox1(object sender, KeyEventArgs e)
        {
            if (wrongKey == true)
                (sender as PasswordBox).Password = string.Empty;
        }
    }
}
