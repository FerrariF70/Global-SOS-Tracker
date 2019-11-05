using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Model for Personnel Info
    /// </summary>
    public class PersonnelInfoModel : ObserverableObject
    {
        private string _healtInsurance;
        private double _weight;
        private double _growth;
        private string _birthDay;
        private string _id;
        private string _name;
        private string _lastName;
        private int _serialNumberOfModule;
        private string _resedentialAddress;
        private string _mobilePhone;
        private string _otherPhone;
        public PersonnelInfoModel() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="SNGST"></param>
        /// <param name="address"></param>
        /// <param name="phone1"></param>
        /// <param name="phone2"></param>
        public PersonnelInfoModel(string name, string lastName, int SNGST, string address, string phone1, string phone2,string healthInsurance,string id,double weight,
            double growth,string birthDay)
        {
            NameClient = name;
            LastName = lastName;
            SerialNumberOfModule = SNGST;
            AddressOfResidence = address;
            _mobilePhone = phone1;
            OtherPhoneNumber = phone2;
            HealthInsurance = healthInsurance;
            ID = id;
            Weight = weight;
            Growth = growth;
            BirthDay = birthDay;
        } 

        public string HealthInsurance
        {
            get => _healtInsurance;
            set
            {
                if (value != _healtInsurance)
                {
                    _healtInsurance = value;
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

        public string BirthDay
        {
            get => _birthDay;
            set
            {
                if (value != _birthDay)
                {
                    _birthDay = value;
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
        public string NameClient
        {
            get { return _name; }

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
            get { return _lastName; }
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
            get { return _mobilePhone; }

            set
            {
                if (value != _mobilePhone)
                {
                    _mobilePhone = value;
                    OnPropertyChanged();
                }
            }
        }

        public string OtherPhoneNumber
        {
            get { return _otherPhone; }
            set
            {
                if (value != _otherPhone)
                {
                    _otherPhone = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AddressOfResidence
        {
            get { return _resedentialAddress; }
            set
            {
                if (value != _resedentialAddress)
                {
                    _resedentialAddress = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
