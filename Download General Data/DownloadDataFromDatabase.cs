using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Microsoft.Maps.MapControl.WPF;
using System.Globalization;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace AppGST
{
    public class DownloadDataFromDatabase
    {
        #region Fields
        private Uri url;
        private readonly string Key = "WJZEJwHrZpkfmhSMv2hn~lXoa_QBX-gwjc19FS2YT3g~ArdlrzM_boCRul2DXI1HcyhBnHWqV2Ch0ajL3H1yaWaQstxxOTh5PD4kZ_Cb9bXJ";
        private List<AllUsersModel> listAllUsers = new List<AllUsersModel>();
        private List<AlarmsModel> listAlarms = new List<AlarmsModel>();
        private List<MapModel> listLocations = new List<MapModel>();
        private List<MapModel> incidents = new List<MapModel>();
        private DeserializeRealTimeData[] data;
        private AlarmsDeserialize[] dataAlarms;
        private double latitude;
        private double longitude;
        private Uri uri;
        private BingMapsRESTToolkit.Location location = null;
        private Timer[] timer;
        private static TimerCallback[] delegateTimer = new TimerCallback[2];
        private string address;
        #endregion
        private int? ID { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        public DownloadDataFromDatabase(int? id)
        {
            ID = id;
            if (timer == null)
            {
                timer = new Timer[2];
                delegateTimer[0] = new TimerCallback(ChangeColorOnBlue);
                delegateTimer[1] = new TimerCallback(ChangeColorOnRed);
            }
        }

        /// <summary>
        /// Download last locations in real time for call center 
        /// </summary>
        /// <param name="incidentEvent"></param>
        /// <param name="mapEvent"></param>
        /// <param name="allUsersEvent"></param>
        public void DownloadForCallCenterData(IncidentEvent incidentEvent, BingMapsMapEvent mapEvent, AllUsersEvent allUsersEvent)
        {
            url = new Uri(string.Format("http://dbrainz-flora-server-app.herokuapp.com/getRealTimeSosIncidents?app_user_id={0}",ID));
            try
            {
                dataAlarms = RequestsToDataBase.RequestToServer(new AlarmsDeserialize(), url) as AlarmsDeserialize[];
                if (dataAlarms.Length > 0)
                {
                    foreach (var item in dataAlarms)
                    {
                        latitude = double.Parse(item.Latitude, CultureInfo.InvariantCulture);
                        longitude = double.Parse(item.Longitude, CultureInfo.InvariantCulture);

                        GetNameLocation(item.Latitude, item.Longitude);
                        listAlarms.Add(new AlarmsModel(item.IncidentID, item.Name, item.LastName, address, item.Pulse, item.Phone, item.EmployeerName, item.Status,
                            item.TimeIncident, Colors.Red));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            url = new Uri(string.Format("http://dbrainz-flora-server-app.herokuapp.com/getDeviceUpdates?flag=online&app_user_id={0}", ID));
            try
            {
                data = RequestsToDataBase.RequestToServer(new DeserializeRealTimeData(), url) as DeserializeRealTimeData[];
                if (data.Length > 0)
                {
                    foreach (DeserializeRealTimeData item in data)
                    {
                        latitude = double.Parse(item.Latitude, CultureInfo.InvariantCulture);
                        longitude = double.Parse(item.Longitude, CultureInfo.InvariantCulture);
                        GetNameLocation(item.Latitude, item.Longitude);
                        if (item.SOS_Status == 1)
                        {
                            mapEvent.OnFocusMapEvent(new Location(latitude, longitude));
                            InitializListLocations(item, true, Brushes.Red);
                            CloseAllWindows(mapEvent);
                        }
                        else
                        {
                            InitializListLocations(item, false, Brushes.Blue);
                        }
                        listAllUsers.Add(new AllUsersModel(item.ID, item.Name, item.LastName, address, item.Pulse, item.DeviceSN));
                    }
                    incidentEvent.OnDownloadallIncidentsEvent(listAlarms);
                    mapEvent.OnDownloadRecentLocations(listLocations);
                    allUsersEvent.OnDownLoadData(listAllUsers);
                    StartTimer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
           
        }

        /// <summary>
        /// Download last location in real time for private user
        /// </summary>
        /// <param name="mapEvent"></param>
        public void DownloadForUserdata(BingMapsMapEvent mapEvent)
        {
            url = new Uri(string.Format("http://dbrainz-flora-server-app.herokuapp.com/getDeviceUpdates?flag=online&app_user_id={0}", ID));
            try
            {
                data = RequestsToDataBase.RequestToServer(new DeserializeRealTimeData(), url) as DeserializeRealTimeData[];
                if (data.Length > 0)
                {
                    foreach (DeserializeRealTimeData item in data)
                    {
                        latitude = double.Parse(item.Latitude, CultureInfo.InvariantCulture);
                        longitude = double.Parse(item.Longitude, CultureInfo.InvariantCulture);
                        uri = new Uri(string.Format("https://dev.virtualearth.net/REST/v1/Locations/{0},{1}?&key={2}", item.Latitude, item.Longitude, Key));
                        BingMapsRESTToolkit.Response response = RequestsToDataBase.RequestToServer(new BingMapsRESTToolkit.Response(), uri) as BingMapsRESTToolkit.Response;
                        GetNameLocation(item.Latitude, item.Longitude);
                        if (item.SOS_Status == 1)
                        {
                            BingMapsViewModel bingMap = Application.Current.Properties["BingMapsViewModel"] as BingMapsViewModel;
                            (Application.Current.Properties["MainWindowViewModel"] as MainWindowViewModel).CurrentPageViewModel = bingMap;
                            mapEvent.OnFocusMapEvent(new Location(latitude, longitude));
                            InitializListLocations(item, true, Brushes.Red);
                        }
                        else
                        {
                            InitializListLocations(item, false, Brushes.Blue);
                        }
                    }
                    StartTimer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            mapEvent.OnDownloadRecentLocations(listLocations);
            
        }

        /// <summary>
        /// Initalize list locations
        /// </summary>
        /// <param name="item"></param>
        /// <param name="incident"></param>
        /// <param name="color"></param>
        public void InitializListLocations(DeserializeRealTimeData item, bool incident, Brush color)
        {
            listLocations.Add(new MapModel
                       (
                       item.Pulse,
                       item.Satellites,
                       item.Battery,
                       new Location(latitude, longitude),
                       item.Satellites > 0 ? Brushes.LimeGreen : Brushes.Red,
                       item.Battery > 10 ? Brushes.LimeGreen : Brushes.Red,
                       item.GPS_Status == 1 ? Brushes.LimeGreen : Brushes.Red,
                       item.BluetoothStatus == 1 ? Brushes.LimeGreen : Brushes.Red,
                       item.GSM_Status == 1 ? Brushes.LimeGreen : Brushes.Red,
                       item.SOS_Status == 1 ? Brushes.Red : Brushes.Snow,
                       color,
                       incident,
                       address
                       ));
        }

        /// <summary>
        /// Method start timer for change ligth pushpins
        /// </summary>
        public void StartTimer()
        {
            timer[0] = new Timer(delegateTimer[0], null, 500, 500);
            timer[1] = new Timer(delegateTimer[1], null, 0, 500);
        }

        /// <summary>
        /// Method change blue ligth for pushpin
        /// </summary>
        /// <param name="obj"></param>
        public void ChangeColorOnBlue(object obj)
        {
            listLocations.Where(x => x.StatusSOS == true).Select(x => x.PushpinColor = Brushes.Blue).ToList();
        }

        /// <summary>
        /// Method change red ligth for pushpin
        /// </summary>
        /// <param name="obj"></param>
        public void ChangeColorOnRed(object obj)
        {
            listLocations.Where(x => x.StatusSOS == true).Select(x => x.PushpinColor = Brushes.Red).ToList();
        }

        /// <summary>
        /// Close other windows without Alarms window
        /// </summary>
        /// <param name="mapEvent"></param>
        public void CloseAllWindows(BingMapsMapEvent mapEvent)
        {
            BingMapsViewModel bingMap = Application.Current.Properties["BingMapsViewModel"] as BingMapsViewModel;
            (Application.Current.Properties["MainWindowViewModel"] as MainWindowViewModel).CurrentPageViewModel = bingMap;
            (Application.Current.Properties["AllUsers"] as AllUsers).Dispatcher.Invoke(new Action(() => { (Application.Current.Properties["AllUsers"] as AllUsers).Close();}));
        }

        public void GetNameLocation(string latitude,string longitude)
        {
            uri = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations/{0},{1}?&key={2}", latitude, longitude, Key));
            BingMapsRESTToolkit.Response response = RequestsToDataBase.RequestToServer(new BingMapsRESTToolkit.Response(), uri) as BingMapsRESTToolkit.Response;

            if (response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                location = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                address = location.Address.AddressLine;
                if(address == null)
                {
                    address = location.Address.FormattedAddress;
                }
            }
        }
    }
}