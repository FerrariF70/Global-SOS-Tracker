using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Media;
using System.Windows;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Input;

namespace AppGST
{
    /// <summary>
    /// Alarmas View Model
    /// </summary>
    public class AlarmsViewModel : ObserverableObject
    {
        private static Dispatcher Dispatcher { get; } = Dispatcher.CurrentDispatcher;
        public AlarmsModel Alarms { get; } = new AlarmsModel();
        public static ObservableCollection<AlarmsModel> AlarmsList { get; } = new ObservableCollection<AlarmsModel>();

        /// <summary>
        /// Property AlarmList
        /// </summary>
        public ObservableCollection<AlarmsModel> ItemsAlarms
        {
            get { return AlarmsList; }
        }

        /// <summary>
        /// Constructor if AlarmsList don't have objects move initialization
        /// </summary>
        public AlarmsViewModel()
        {
        }

        /// <summary>
        /// Download all incidents from Database
        /// </summary>
        public void SetAlarmsList(List<AlarmsModel> list)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                AlarmsList.Clear();
                list.ForEach(incidents => AlarmsList.Add(incidents));
            }));
        }
    }

    /// <summary>
    /// Class for event
    /// </summary>
    public class IncidentEvent
    {
        public delegate void DownloadAllIncidentsHandler(List<AlarmsModel> list);
        public event DownloadAllIncidentsHandler DownloadAllIncidents;

        /// <summary>
        /// Handler method for download all incidents from database
        /// </summary>
        public void OnDownloadallIncidentsEvent(List<AlarmsModel> list)
        {
            DownloadAllIncidents(list);
        }
    }
}
