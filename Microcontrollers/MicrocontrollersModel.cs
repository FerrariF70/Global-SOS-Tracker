using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Model for microcontrollers
    /// </summary>
    public class MicrocontrollersModel : ObserverableObject
    {
        private string _serialNumberOfModule;
        private string _gsmModuleStatus;
        private string _bluetoothStatus;
        private string _pulseSensorStatus;
        private string _precentageBattery;
        private string _sattelites;
        private string _gpsStatus;

        public string SerialNumberOfModule
        {
            get
            {
                return _serialNumberOfModule;
            }
            set
            {
                if (value != _serialNumberOfModule)
                {
                    _serialNumberOfModule = value;
                    OnPropertyChanged();
                }
            }

        }
        public string GSMModule_Status
        {
            get
            {
                return _gsmModuleStatus;
            }
            set
            {
                if (value != _gsmModuleStatus)
                {
                    _gsmModuleStatus = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Bluetooth_Status
        {
            get
            {
                return _bluetoothStatus;
            }
            set
            {
                if (value != _bluetoothStatus)
                {
                    _bluetoothStatus = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PulseSensor_Status
        {
            get { return _pulseSensorStatus; }
            set
            {
                if (value != _bluetoothStatus)
                {
                    _bluetoothStatus = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PrecentageBattery_Status
        {
            get { return _precentageBattery; }
            set
            {
                if (value != _precentageBattery)
                {
                    _precentageBattery = value;
                    OnPropertyChanged();
                }
            }
        }
        public string GPS_Status
        {
            get { return _gpsStatus; }
            set
            {
                if (_gpsStatus != value)
                {
                    _gpsStatus = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Satellites
        {
            get { return _sattelites; }
            set
            {
                if (value != _sattelites)
                {
                    _sattelites = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
