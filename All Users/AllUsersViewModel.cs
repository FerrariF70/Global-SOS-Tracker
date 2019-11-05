using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AppGST
{
    /// <summary>
    /// AllUsers class ViewModel
    /// </summary>
    public class AllUsersViewModel : ObserverableObject
    {
        private ICommand _exitCommand;
        public AllUsersModel AllUsersModel { get; } = new AllUsersModel();
        public static ObservableCollection<AllUsersModel> ListAllUsers { get; } = new ObservableCollection<AllUsersModel>();
        private Dispatcher Dispatcher { get; } = Dispatcher.CurrentDispatcher;
        /// <summary>
        /// List of users
        /// </summary>
        public ObservableCollection<AllUsersModel> ItemsUsers
        {
            get { return ListAllUsers; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public AllUsersViewModel()
        {
            
        }

        /// <summary>
        /// Commnad for exit window
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new RelayCommand(param => ExitWindow(), param => true);
                }
                return _exitCommand;
            }
        }

        /// <summary>
        /// Method for exit window
        /// </summary>
        private void ExitWindow()
        {
            (Application.Current.Properties["AllUsers"] as AllUsers).Close();
        }

        /// <summary>
        /// Download data from database about all users real time
        /// </summary>
        public void SetDataAllUsersRealTime(List<AllUsersModel> list)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                ListAllUsers.Clear();
                list.ForEach(user => ListAllUsers.Add(user));
            }));
        }
    }

    /// <summary>
    /// Class event for AllUsers
    /// </summary>
    public class AllUsersEvent
    {
        public delegate void DownloadDataFromDatabaseHandler(List<AllUsersModel> list);
        public event DownloadDataFromDatabaseHandler DownloadDataFromDatabase;

        /// <summary>
        /// Download all list of users
        /// </summary>
        public void OnDownLoadData(List<AllUsersModel> list)
        {
            DownloadDataFromDatabase(list);
        }
    }
}
