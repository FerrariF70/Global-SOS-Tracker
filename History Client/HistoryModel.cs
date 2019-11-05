using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// History Model
    /// </summary>
    public class HistoryModel : ObserverableObject
    {
        private short _maxPulsePerDay;
        private string _incidentLocation;
        private string _timeIncident;
        private int _serialNumberOfModule;
        private static double _value;
        private DateTime? dateFrom = DateTime.Now;
        private DateTime? dateTo = DateTime.Now;
        public HistoryModel(){ }
        public HistoryModel(short pulse,string location,string time,int sn_module)
        {
            MaximalPulsePerDay = pulse;
            CurrentLocation = location;
            TimeIncedent = time;
            SerialNumberOfModule = sn_module;
        }

        public DateTime? ToDate
        {
            get => dateTo;
            set
            {
                if (value != dateTo)
                {
                    dateTo = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime? FromDate
        {
            get => dateFrom;
            set
            {
                if (value != dateFrom)
                {
                    dateFrom = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SerialNumberOfModule
        {
            get { return _serialNumberOfModule; }
            set
            {
                if (value != _serialNumberOfModule)
                {
                    _serialNumberOfModule = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CurrentLocation
        {
            get
            {
                return _incidentLocation;
            }
            set
            {
                if (value != _incidentLocation)
                {
                    _incidentLocation = value;
                    OnPropertyChanged();
                }
            }
        }
        public short MaximalPulsePerDay
        {
            get { return _maxPulsePerDay; }
            set
            {
                if (value != _maxPulsePerDay)
                {
                    _maxPulsePerDay = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TimeIncedent
        {
            get { return _timeIncident; }
            set
            {
                if (value != _timeIncident)
                {
                    _timeIncident = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
