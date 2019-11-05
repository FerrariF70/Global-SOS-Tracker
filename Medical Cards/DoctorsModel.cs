using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Model for Doctor Page
    /// </summary>
    public class DoctorsModel : ObserverableObject
    {
        private string _doctorName;
        private string _doctorLastName;
        private string _doctorContactNumber1;
        private string _doctorContactNumber2;
        private string _doctorOfficeAddress;
        private string _personalFromDate;
        private string _usualVisitAddress;
        private string _expanderHeader;
        public ObservableCollection<DoctorsModel> _listCollections { get; private set; }
        public DoctorsModel() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="doctorName"></param>
        /// <param name="doctroLastName"></param>
        /// <param name="address"></param>
        /// <param name="personalFromDate"></param>
        /// <param name="usualVisitAddress"></param>
        /// <param name="phone1"></param>
        /// <param name="phone2"></param>
        /// <param name="expanderHeader"></param>
        public DoctorsModel(string doctorName, string doctroLastName, string address, string personalFromDate, string usualVisitAddress, string phone1, string phone2,
           string expanderHeader)
        {
            DoctorName = doctorName;
            DoctorLastName = doctroLastName;
            DoctorOfficeAddress = address;
            PersonalFromDate = personalFromDate;
            UsualVisitAddress = usualVisitAddress;
            DoctorContactNumber1 = phone1;
            DoctorContactNumber2 = phone2;
            ExpanderHeader = expanderHeader;
        }

        /// <summary>
        /// Initialize List
        /// </summary>
        /// <param name="list"></param>
        public void SetList(ObservableCollection<DoctorsModel> list)
        {
            ListDoctors = list;
        }

        /// <summary>
        /// List of doctors
        /// </summary>
        public ObservableCollection<DoctorsModel> ListDoctors 
        {
            get { return _listCollections; }
            set
            {
                if (value != _listCollections)
                {
                    _listCollections = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ExpanderHeader
        {
            get { return _expanderHeader; }
            set
            {
                if (value != _expanderHeader)
                {
                    _expanderHeader = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DoctorName
        {
            get { return _doctorName; }
            set
            {
                if (value != _doctorName)
                {
                    _doctorName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DoctorLastName
        {
            get { return _doctorLastName; }
            set
            {
                if (value != _doctorLastName)
                {
                    _doctorLastName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DoctorOfficeAddress
        {
            get { return _doctorOfficeAddress; }
            set
            {
                if (value != _doctorOfficeAddress)
                {
                    _doctorOfficeAddress = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PersonalFromDate
        {
            get { return _personalFromDate; }
            set
            {
                if (value != _personalFromDate)
                {
                    _personalFromDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string UsualVisitAddress
        {
            get { return _usualVisitAddress; }
            set
            {
                if (value != _usualVisitAddress)
                {
                    _usualVisitAddress = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DoctorContactNumber1
        {
            get { return _doctorContactNumber1; }
            set
            {
                if (value != _doctorContactNumber1)
                {
                    _doctorContactNumber1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DoctorContactNumber2
        {
            get { return _doctorContactNumber2; }
            set
            {
                if (value != _doctorContactNumber2)
                {
                    _doctorContactNumber2 = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
