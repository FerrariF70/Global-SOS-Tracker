using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using WpfAnimatedGif;

namespace AppGST
{

    public partial class MainWindow : Window
    {
        private AlarmsViewModel incident;
        private IncidentEvent incidentEvent;
        private BingMapsMapEvent mapEvent;
        private BingMapsViewModel map;
        private AllUsersEvent userEvent;
        private AllUsersViewModel allUsersViewModel;
        private PersonnelInfoEvent personnelEvent;
        private DispatcherTimer timerEvents = new DispatcherTimer();
        private DownloadDataFromDatabase data;
        public int? ID { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialization controls when Application is start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWeather();
            InitializeEvents();
        }
        public void InitializeEvents()
        {
            StatisticEvent statisticEvent = new StatisticEvent();
            StatisticViewModel statistics = Application.Current.Properties["StatisticViewModel"] as StatisticViewModel;
            statisticEvent.WorkStatistEvent += statistics.StartTimer;
            statistics.StartTimer(ID);

            mapEvent = new BingMapsMapEvent();
            map = Application.Current.Properties["BingMapsViewModel"] as BingMapsViewModel;
            mapEvent.DownloadRecentLocations += map.DownloadAllLocationClients;
            mapEvent.FocusMap += map.SetFocucOnLocation;
            if ((int)Application.Current.Properties["user"] == 1)
            {
                timerEvents.Interval = new TimeSpan(0, 0, 10);
                timerEvents.Tick += GetDataForClient;
                Top_Menu.Visibility = Visibility.Collapsed;
                timerEvents.Start();
            }
            else if ((int)Application.Current.Properties["user"] == 5)
            {
                timerEvents.Interval = new TimeSpan(0, 0, 10);
                timerEvents.Tick += GetDataForEmployeer;
                AddClient_Button.Visibility = Visibility.Collapsed;
                incidentEvent = new IncidentEvent();
                incident = Application.Current.Properties["AlarmsViewModel"] as AlarmsViewModel;
                incidentEvent.DownloadAllIncidents += incident.SetAlarmsList;

                userEvent = new AllUsersEvent();
                allUsersViewModel = Application.Current.Properties["AllUsersViewModel"] as AllUsersViewModel;
                userEvent.DownloadDataFromDatabase += allUsersViewModel.SetDataAllUsersRealTime;

                personnelEvent = new PersonnelInfoEvent();
                PersonnelInfoViewModel personnel = Application.Current.Properties["PersonnelInfoViewModel"] as PersonnelInfoViewModel;
                //Subscribe to download all personnel data for each user
                personnelEvent.DownloadPersonnelInfoData += personnel.DownloadAllPersonnelInfo;
                personnelEvent.OnDownloadPersonnelInfo(ID);
                timerEvents.Start();
            }
        }

        public async void GetDataForEmployeer(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                data = new DownloadDataFromDatabase(ID);
                data.DownloadForCallCenterData(incidentEvent, mapEvent, userEvent);
            });
        }
        public async void GetDataForClient(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                data = new DownloadDataFromDatabase(ID);
                data.DownloadForUserdata(mapEvent);
            });
        }


        /// <summary>
        /// Load weather
        /// </summary>
        private void LoadWeather()
        {
            try
            {
                Root weather = new Root();
                WebRequest request = WebRequest.Create("https://api.weather.yandex.ru/v1/informers?lat=32.0879122&lon=34.7272058");
                request.Headers.Add("X-Yandex-API-Key: a84dfbb7-a210-4e9c-9d76-78e714be6049");
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = reader.ReadToEnd();

                        DataContractJsonSerializer j = new DataContractJsonSerializer(typeof(Root));
                        weather = j.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(line))) as Root;
                        string iconSVG = "http://";
                        iconSVG += string.Format("yastatic.net/weather/i/icons/blueye/color/svg/{0}.svg", weather.Fact.Icon);
                        weatherIcon.Source = new Uri(iconSVG);
                        if (weather.Fact.Temp > 0)
                            temperature.Content += "+";
                        else
                            temperature.Content += "-";
                        temperature.Content += weather.Fact.Temp + "°C";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Don't connect to weather service", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ///// <summary>
        ///// Display Time and Date
        ///// </summary>
        //private void StartTime()
        //{
        //    DispatcherTimer timer = new DispatcherTimer();
        //    timer.Interval = new TimeSpan(0, 0, 1);
        //    timer.IsEnabled = true;
        //    timer.Tick += (o, t) => { Time.Text = DateTime.Now.ToLongTimeString().ToString(); date.Text = DateTime.Now.ToShortDateString().ToString();};
        //}

        private void Button_AllUsers(object sender, RoutedEventArgs e)
        {
            //AllUsers listUsers = new AllUsers();
            AllUsers users = new AllUsers();
            //users.Show();
            (Application.Current.Properties["AllUsers"] as AllUsers).Show();
        }
        private void Button_Alarms(object sender, RoutedEventArgs e)
        {
            Alarms listAlrms = new Alarms();
            listAlrms.Show();
        }
        private void Button_AddClient(object sender, RoutedEventArgs e)
        {
            AddClient addWindow = new AddClient();
            Application.Current.Properties["ModelClient"] = addWindow.Client;
            addWindow.Show();
        }

        /// <summary>
        /// Show Gif Image
        /// </summary>
        private void Viewbox_MouseEnter(object sender, MouseEventArgs e)
        {
            Viewbox imgBox = sender as Viewbox;
            Image img = imgBox.Child as Image;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"./Image/light.gif", UriKind.RelativeOrAbsolute);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(img, image);
        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            ((sender as Border).TemplatedParent as Button).Foreground = Brushes.Black;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            ((sender as Border).TemplatedParent as Button).Foreground = Brushes.Snow;
        }
    }
}
