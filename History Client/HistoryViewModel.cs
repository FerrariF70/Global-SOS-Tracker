using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AppGST
{
    /// <summary>
    /// History ViewModel
    /// </summary>
    public class HistoryViewModel : ObserverableObject, IPageViewModel
    {
        private ICommand _displayHistoryCommand;
        public HistoryModel HistoryModel { get; } = new HistoryModel();
        public static ObservableCollection<HistoryModel> ListHistory { get; } = new ObservableCollection<HistoryModel>();

        /// <summary>
        /// Constructor
        /// </summary>
        public HistoryViewModel()
        {
            Application.Current.Properties["HistoryModel"] = HistoryModel;
        }

        /// <summary>
        /// List of History
        /// </summary>
        public ObservableCollection<HistoryModel> ItemsHistory
        {
            get { return ListHistory; }
        }
        public string Name
        {
            get { return "History"; }
        }

        /// <summary>
        /// Button command for download data from server
        /// </summary>
        public ICommand DisplayHistoryCommand
        {
            get
            {
                if (_displayHistoryCommand == null)
                {
                    _displayHistoryCommand = new RelayCommand(param => DownloadDataFromDatabase(param?.ToString()), param => true);
                }
                return _displayHistoryCommand;
            }
        }
        /// <summary>
        /// Method Download data from DB 
        /// </summary>
        public async void DownloadDataFromDatabase(string snModuleNumnber)
        {
            (Application.Current.Properties["HistoryModel"] as HistoryModel).Value = 0;
            List<HistoryModel> list = await Task.Run(() => ServiceHistory.DownloadHistoryClient(snModuleNumnber));
            ListHistory.Clear();
            list.ForEach(history => ListHistory.Add(history));
        }
       
    }
}
