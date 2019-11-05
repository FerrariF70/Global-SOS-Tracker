using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// AllUsers class model 
    /// </summary>
    public class AllUsersModel : ObserverableObject
    {
        private string _name;
        private string _lastName;
        private string _locationAddress;
        private short _pulse;
        private int _serialNumberOfModule;
        private string _id;

        public AllUsersModel() { }
        public AllUsersModel(string id, string name,string lastName,string location,short pulse,int SNGST)
        {
            ID = id;
            Name = name;
            LastName = lastName;
            CurrentLocation = location;
            Pulse = pulse;
            SerialNumberOfModule = SNGST;
        }
        public string ID
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
        public string CurrentLocation
        {
            get
            {
                return _locationAddress;
            }
            set
            {
                if (value != _locationAddress)
                {
                    _locationAddress = value;
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
    }
}
