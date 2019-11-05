using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace AppGST
{
    /// <summary>
    /// Model For BingMaps
    /// </summary>
    public class MapModel : ObserverableObject
    {
        private Location _location = new Location(0,0);
        private double _zoomLevel = 1.5;
        private string _searchText = "Search Place and Address";
        private short _pulse;
        private byte _totalSatellites;
        private string _precetageBattery;
        private static MapMode _mode;
        private static Dispatcher dispatcher;
        private Brush _satellites = Brushes.Red;
        private Brush _battery = Brushes.Red;
        private Brush _gps = Brushes.Red;
        private Brush _bluetooth = Brushes.Red;
        private Brush _gsm = Brushes.Red;
        private Brush _sos = Brushes.Snow;
        private Brush _pushpinColor = Brushes.Blue;
        private bool _statuSOS;
        private string _address;

        public MapModel(short pulse,byte totalSatellites,byte precentageBattery, Location pushpin, Brush satellites, Brush battery, Brush gps, Brush bluetooth, Brush gsm, 
            Brush sos, Brush pushpinColor,bool statusSOS,string address)
        {
            Location = pushpin;
            Satellites = satellites;
            Battery = battery;
            GPS = gps;
            Bluetooth = bluetooth;
            GSM = gsm;
            SOS = sos;
            Pulse = pulse;
            TotalSatellites = totalSatellites;
            PrecentageBattery = precentageBattery.ToString() + "%";
            PushpinColor = pushpinColor;
            StatusSOS = statusSOS;
            Address = address;
        }

        public string Address
        {
            get => _address;
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool StatusSOS
        {
            get => _statuSOS;
            set
            {
                if (value != _statuSOS)
                {
                    _statuSOS = value;
                    OnPropertyChanged();
                }
            }
        }
        public short Pulse
        {
            get => _pulse;
            set
            {
                if (value != _pulse)
                {
                    _pulse = value;
                    OnPropertyChanged();
                }
            }
        }

        public byte TotalSatellites
        {
            get => _totalSatellites;
            set
            {
                if (value != _totalSatellites)
                {
                    _totalSatellites = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PrecentageBattery
        {
            get => _precetageBattery;
            set
            {
                if (value != _precetageBattery)
                {
                    _precetageBattery = value;
                    OnPropertyChanged();
                }
            }
        }
        public Brush Satellites
        {
            get => _satellites;
            set
            {
                if (value != _satellites)
                {
                    _satellites = value;
                    OnPropertyChanged();
                }
            }
        }

        public Brush Battery
        {
            get => _battery;
            set
            {
                if (value != _battery)
                {
                    _battery = value;
                    OnPropertyChanged();
                }
            }
        }
        public Brush GPS
        {
            get => _gps;
            set
            {
                if (value != _gps)
                {
                    _gps = value;
                    OnPropertyChanged();
                }
            }
        }

        public Brush GSM
        {
            get => _gsm;
            set
            {
                if (value != _gsm)
                {
                    _gsm = value;
                    OnPropertyChanged();
                }
            }
        }

        public Brush Bluetooth
        {
            get => _bluetooth;
            set
            {
                if (value != _bluetooth)
                {
                    _bluetooth = value;
                    OnPropertyChanged();
                }
            }
        }
        public Brush SOS
        {
            get => _sos;
            set
            {
                if (value != _sos)
                {
                    _sos = value;
                    OnPropertyChanged();
                }
            }
        }
        public Brush PushpinColor
        {
            get => _pushpinColor;
            set
            {
                if (value != _pushpinColor)
                {
                    _pushpinColor = value;
                    OnPropertyChanged();
                }
            }
        }
        public Dispatcher Dispatcher
        {
            get { return dispatcher; }
        }

        public MapModel()
        {
            if(dispatcher == null)
            {
                dispatcher = Dispatcher.CurrentDispatcher;
            }
            Dispatcher.Invoke(new Action(()=> { 
            if (_mode == null)
                _mode = new RoadMode();
            }));
        }
        public MapMode ChangeMapMode
        {
            get { return _mode; }
            set
            {
                if (value != _mode)
                {
                    _mode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SearchOnBingMaps
        {
            get { return _searchText; }
            set
            {
                if (value != _searchText)
                {
                    _searchText = value;
                    OnPropertyChanged();
                }
            }
        }
       
        public double Zoom
        {
            get { return _zoomLevel; }
            set
            {
                if (value != _zoomLevel)
                {
                    _zoomLevel = value;
                    OnPropertyChanged();
                }
            }
        }
        public Location Location
        {
            get { return _location; }
            set
            {
                if (value != _location)
                {
                    _location = value;
                    OnPropertyChanged();
                }
            }
        }
       
     
    }
}
