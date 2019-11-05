using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppGST
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public ModelClient Client { get; } = new ModelClient();
        public AddClient()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();
        }
        private void Button_AddClient(object sender, RoutedEventArgs e)
        {
            AddClientSerilization c = new AddClientSerilization(Client.ID,Client.AppUserID, Client.SerialNumberOfModule, Client.Name, Client.LastName, 
                Client.MobileNumber, Client.OtherPhoneNumber, Client.AddressOfResidence, Client.Weight, Client.Growth, Client.HealthInsurance,Client.BirthDate, 
                Client.Gender);
            Uri url = new Uri(string.Format("http://dbrainz-flora-server-app.herokuapp.com/postNewDeviceUser"));
            PostDataToServer.PostToServer(this, url, c);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource == lastName)
            {
                ExecutenEffect(sender);
            }
            else if(e.Source == appUserID)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == firstName)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == birthDate)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == address)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == phone1)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == phone2)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == healthInsurance)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == id)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == gender)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == growth)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == weight)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == snGST)
            {
                ExecutenEffect(sender);
            }
            else if (e.OriginalSource == buttonAdd)
            {
                DropShadowEffect effect = new DropShadowEffect();
                effect.Color = Colors.Blue;
                effect.BlurRadius = 20;
                (sender as Button).Effect = effect;
            }
            else if (e.OriginalSource == exitButton)
            {
                DropShadowEffect effect = new DropShadowEffect();
                effect.Color = Colors.Blue;
                effect.BlurRadius = 20;
                (sender as Button).Effect = effect;
            }
        }
        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource == lastName)
            {
                (sender as TextBox).Effect = null;
            }
            else if(e.OriginalSource == appUserID)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == firstName)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == birthDate)
            {
                (sender as DatePicker).Effect = null;
            }
            else if (e.OriginalSource == address)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == phone1)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == phone2)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == healthInsurance)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == id)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == gender)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == growth)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == weight)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == snGST)
            {
                (sender as TextBox).Effect = null;
            }
            else if (e.OriginalSource == buttonAdd)
            {
                (sender as Button).Effect = null;
            }
            else if (e.OriginalSource == exitButton)
            {
                (sender as Button).Effect = null;
            }
        }
        private void ExecutenEffect(object sender)
        {
            DropShadowEffect effect = new DropShadowEffect();
            effect.Color = Colors.Blue;
            effect.BlurRadius = 20;
            if (sender is TextBox)
                (sender as TextBox).Effect = effect;
            else
                (sender as DatePicker).Effect = effect;
        }
        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        internal enum AccentState
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        internal enum WindowCompositionAttribute
        {
            WCA_ACCENT_POLICY = 19
        }
        private void SelectGender_Checked(object sender, RoutedEventArgs e)
        {

            if (e.Source == Male)
            {
                Client.Gender = 1;
            }
            else
            {
                Client.Gender = 0;
            }
        }

        private void BirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            StringBuilder birthDate = new StringBuilder();
            DateTime? date = (sender as DatePicker).SelectedDate;
            birthDate.Append(date.Value.Year + "-" + date.Value.Month + "-" + date.Value.Day);
            Client.BirthDate = birthDate.ToString();
        }
    }
}
