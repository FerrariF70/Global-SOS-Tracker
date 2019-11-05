using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace AppGST
{
    /// <summary>
    /// ViewModel for BingMaps
    /// </summary>
    public class BingMapsViewModel : ObserverableObject, IPageViewModel
    {
        private ICommand _searchCommand;
        private ICommand _modeCommand;
        private readonly string Key = "key=WJZEJwHrZpkfmhSMv2hn~lXoa_QBX-gwjc19FS2YT3g~ArdlrzM_boCRul2DXI1HcyhBnHWqV2Ch0ajL3H1yaWaQstxxOTh5PD4kZ_Cb9bXJ";
        private Dispatcher Dispatcher { get; } = Dispatcher.CurrentDispatcher;
        public static ObservableCollection<MapModel> GSTLocations { get; } = new ObservableCollection<MapModel>();
        private ObservableCollection<MapModel> SearchLocation { get;  set; }
        public MapModel MapModel { get; } = Application.Current.Properties["MapModel"] as MapModel;


        /// <summary>
        /// List for location pushpins
        /// </summary>
        public ObservableCollection<MapModel> ItemsLocation
        {
            get { return GSTLocations; }
        }

        /// <summary>
        /// List for only one pushpin. Search
        /// </summary>
        public ObservableCollection<MapModel> ItemSearchLocation
        {
            get { return SearchLocation; }
            set
            {
                if (value != SearchLocation)
                {
                    SearchLocation = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Command change mode bing maps 
        /// </summary>
        public ICommand ChangeModeCommand
        {
            get
            {
                if (_modeCommand == null)
                {
                    _modeCommand = new RelayCommand(param => ChangeModeBingMaps(), param => true);
                }
                return _modeCommand;
            }
        }

        /// <summary>
        /// Command for search palce and other
        /// </summary>
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(param => SearchOnBingMaps(param?.ToString()), param => true);
                }
                return _searchCommand;
            }
        }

        /// <summary>
        /// Method for search command 
        /// </summary>
        /// <param name="searchText"></param>
        public void SearchOnBingMaps(string searchText)
        {
            List<MapModel> list = GSTService.GetSearchLocation(searchText, Key);
            ItemSearchLocation = new ObservableCollection<MapModel>(list);
        }

        /// <summary>
        /// Method for changed mode
        /// </summary>
        private void ChangeModeBingMaps()
        {
            if (MapModel.ChangeMapMode is RoadMode)
                MapModel.ChangeMapMode = new AerialMode();
            else
            {
                MapModel.ChangeMapMode = new RoadMode();
            }
        }

        /// <summary>
        /// Download all recent locations clients
        /// </summary>
        public void DownloadAllLocationClients(List<MapModel> list)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                GSTLocations.Clear();
                list.ForEach(location => GSTLocations.Add(location));
            }));
        }

        /// <summary>
        /// Method for event focus on the map
        /// </summary>
        /// <param name="location"></param>
        public void SetFocucOnLocation(Location location)
        {
            MapModel.Zoom = 14;
            MapModel.Location = location;
        }
       
        public string Name
        {
            get { return "Maps"; }
        }
    }

    /// <summary>
    /// Class events for BingMaps
    /// </summary>
    public class BingMapsMapEvent
    {
        public delegate void DownloadRecentLocationsHandler(List<MapModel> list);
        public delegate void FocusMapHandler(Location location);

        public event FocusMapHandler FocusMap;
        public event DownloadRecentLocationsHandler DownloadRecentLocations;

        /// <summary>
        /// Handler method for download all locations
        /// </summary>
        /// <param name="list"></param>
        public void OnDownloadRecentLocations(List<MapModel> list)
        {
            DownloadRecentLocations(list);
        }

        /// <summary>
        /// Hanler method for focus map
        /// </summary>
        /// <param name="location"></param>
        public void OnFocusMapEvent(Location location)
        {
            FocusMap(location);
        }
    }
}
