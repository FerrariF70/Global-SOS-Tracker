using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AppGST
{

    /// <summary>
    /// Alarms class model 
    /// </summary>
    public class AlarmsModel : ObserverableObject
    {
        private int _id;
        private string _name;
        private string _lastName;
        private string _address_sos;
        private short _pulse;
        private string _emergencyByHandle;
        private string _status; 
        private string _timeOfIncedent;
        private string _phoneNumber;
        private Color _colorBackgroundRow;
        public AlarmsModel() { }
        public AlarmsModel(int id,string name,string lastName,string addressIncident,short pulse,string phone,string employeer,string status,string time,
            Color color)
        {
            ID = id;
            Name = name;
            LastName = lastName;
            CurrentLocation = addressIncident;
            Phone = phone;
            Pulse = pulse;
            EmployeerName = employeer;
            Status = status;
            TimeIncedent = time;   
            BackgroundColorRow = color;
        }
        public int ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TimeIncedent
        {
            get { return _timeOfIncedent; }
            set
            {
                if (value != _timeOfIncedent)
                {
                    _timeOfIncedent = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Phone
        {
            get { return _phoneNumber; }
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CurrentLocation
        {
            get
            {
                return _address_sos;
            }
            set
            {
                if (value != _address_sos)
                {
                    _address_sos = value;
                    OnPropertyChanged();
                }
            }
        }
        public short Pulse
        {
            get
            {
                return _pulse;
            }
            set
            {
                if (value != _pulse)
                {
                    _pulse = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EmployeerName
        {
            get
            {
                return _emergencyByHandle;
            }
            set
            {
                if (value != _emergencyByHandle)
                {
                    _emergencyByHandle = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public Color BackgroundColorRow
        {
            get
            {
                return _colorBackgroundRow;
            }
            set
            {
                if (value != _colorBackgroundRow)
                {
                    _colorBackgroundRow = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
