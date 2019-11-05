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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppGST
{
    /// <summary>
    /// Логика взаимодействия для HistoryClient.xaml
    /// </summary>
    public partial class HistoryClient : UserControl
    {
        private Uri uri = null;

        private StringBuilder FromDate { get; set; }
        private StringBuilder ToDate { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public HistoryClient()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize and convert Date From
        /// </summary>
        private void SelectedDateFrom(object sender, SelectionChangedEventArgs e)
        {
            FromDate = new StringBuilder();
            DateTime? date = (sender as DatePicker).SelectedDate;
            FromDate.Append(date.Value.Date.Year.ToString() + "-" + date.Value.Date.Month.ToString() + "-" + date.Value.Day.ToString());
            Application.Current.Properties["FromDate"] = FromDate;
        }

        /// <summary>
        /// Initialize and convert Date To
        /// </summary>
        private void SelectedDateTo(object sender, SelectionChangedEventArgs e)
        {
            ToDate = new StringBuilder();
            DateTime? date = (sender as DatePicker).SelectedDate;
            ToDate.Append(date.Value.Date.Year.ToString() + "-" + date.Value.Date.Month.ToString() + "-" + date.Value.Day.ToString());
            Application.Current.Properties["ToDate"] = ToDate;
        }
    }
}
