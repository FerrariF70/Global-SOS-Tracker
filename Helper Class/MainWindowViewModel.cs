using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Maps.MapControl.WPF;

namespace AppGST
{
    /// <summary>
    /// ViewModel for all pages
    /// </summary>
    class MainWindowViewModel : ObserverableObject
    {
        private ICommand _changePageCommand;
        private ICommand _alarmsCommnd;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;
        public MapModel MapModel { get; } = new MapModel();

        /// <summary>
        /// Constructor MainWindowViewModel in itialization all user controls(Pages)
        /// </summary>
        public MainWindowViewModel()
        {
            AllUsers allUsers = new AllUsers();
            Application.Current.Properties["AllUsers"] = allUsers;
            StatisticViewModel statistics = new StatisticViewModel();
            Application.Current.Properties["StatisticViewModel"] = statistics;
            Application.Current.Properties["MapModel"] = MapModel;
            BingMapsViewModel bingMaps = new BingMapsViewModel();
            int user = (int)Application.Current.Properties["user"];
            Application.Current.Properties["BingMapsViewModel"] = bingMaps;
            Application.Current.Properties["MainWindowViewModel"] = this;
            if (user == 1)
            {
                PageViewModels.Add(bingMaps);
                PageViewModels.Add(new HistoryViewModel());
                PageViewModels.Add(statistics);
            }
            else if (user == 5)
            {
                MedicalCardsViewModel medicalCardsViewModel = new MedicalCardsViewModel();
                PersonnelInfoViewModel personnelInfo = new PersonnelInfoViewModel();
                Application.Current.Properties["AllUsersViewModel"] = new AllUsersViewModel();
                Application.Current.Properties["AlarmsViewModel"] = new AlarmsViewModel();
                Application.Current.Properties["MedicalCardsViewModel"] = medicalCardsViewModel;
                Application.Current.Properties["BingMapsViewModel"] = bingMaps;
                Application.Current.Properties["PersonnelInfoViewModel"] = personnelInfo;
                PageViewModels.Add(bingMaps);
                PageViewModels.Add(new HistoryViewModel());
                PageViewModels.Add(medicalCardsViewModel);
                PageViewModels.Add(personnelInfo);
                PageViewModels.Add(statistics);
            }
            CurrentPageViewModel = PageViewModels[0];
        }

        /// <summary>
        /// Command change page
        /// </summary>
        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        /// <summary>
        /// List for all pages
        /// </summary>
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }


        /// <summary>
        /// Initialization current page
        /// </summary>
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        /// <summary>
        /// Change ViewModel Page
        /// </summary>
        /// <param name="viewModel"></param>
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);

            if (viewModel is MedicalCardsViewModel)
            {
                new ConncectionToAPIforMedicalCards().ShowDialog();
            }
        }

        /// <summary>
        /// Commannd show window about alarms
        /// </summary>
        public ICommand AllarmsCommand
        {
            get
            {
                if (_alarmsCommnd == null)
                {
                    _alarmsCommnd = new RelayCommand(param => new Alarms().Show(), param => true);
                }
                return _alarmsCommnd;
            }
        }
    }
}

