using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppGST
{
    public class ModelClient : ObserverableObject
    {
        private static string _id;
        private static int _appUserID;
        private static int _snGST;
        private static string _name;
        private static string _lastName;
        private static string _phone1;
        private static string _phone2;
        private static string _address;
        private static double _weight;
        private static double _growth;
        private static string _healthInsurance;
        private static byte _gender;
        private static string _birthDate;
        
        public ModelClient()
        {

        }
        public string ID
        {
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string BirthDate
        {
            get => _birthDate;
            set
            {
                if (value != _birthDate)
                {
                    _birthDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Gender
        {
            get => _gender;
            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }
        public int AppUserID
        {
            get => _appUserID;
            set
            {
                if (value != _appUserID)
                {
                    _appUserID = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SerialNumberOfModule
        {
            get => _snGST;
            set
            {
                if (value != _snGST)
                {
                    _snGST = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => _name;
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
            get => _lastName;
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MobileNumber
        {
            get => _phone1;
            set
            {
                if (value != _phone1)
                {
                    _phone1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string OtherPhoneNumber
        {
            get => _phone2;
            set
            {
                if (value != _phone2)
                {
                    _phone2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AddressOfResidence
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
        public double Weight
        {
            get => _weight;
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    OnPropertyChanged();
                }
            }
        }
        public double Growth
        {
            get => _growth;
            set
            {
                if (value != _growth)
                {
                    _growth = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HealthInsurance
        {
            get => _healthInsurance;
            set
            {
                if (value != _healthInsurance)
                {
                    _healthInsurance = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
