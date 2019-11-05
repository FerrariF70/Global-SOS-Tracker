using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AppGST
{
    /// <summary>
    /// Model for Diagnosis Page
    /// </summary>
    public class DiagnosisModel : ObserverableObject
    {
        private string _conditionFromDate;
        private string _conditionToDate;
        private string _doctorName;
        private string _doctorLastName;
        private string _conditionDescription;
        private string _highPulseRelated;
        private string _expanderHeader;
        public ObservableCollection<DiagnosisModel> ListCollections { get; private set; }
        public DiagnosisModel() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="conditionFromDate"></param>
        /// <param name="conditionToDate"></param>
        /// <param name="doctorName"></param>
        /// <param name="doctorLastName"></param>
        /// <param name="conditionDescription"></param>
        /// <param name="highPulseRelated"></param>
        /// <param name="expanderHeader"></param>
        public DiagnosisModel(string conditionFromDate, string conditionToDate, string doctorName, string doctorLastName, string conditionDescription, 
            string highPulseRelated, string expanderHeader)
        {
            ConditionFromeDate = conditionFromDate;
            ConditionToDate = conditionToDate;
            DoctorName = doctorName;
            DoctorLastName = doctorLastName;
            ConditionDescription = conditionDescription;
            HighPulseRelated = highPulseRelated;
            ExpanderHeader = expanderHeader;
        }

        /// <summary>
        /// Initialize list
        /// </summary>
        /// <param name="list"></param>
        public void SetCollection(ObservableCollection<DiagnosisModel> list)
        {
            ListCollections = list;
        }

        /// <summary>
        /// List diagnoses
        /// </summary>
        public ObservableCollection<DiagnosisModel> ListOfNotes
        {
            get { return ListCollections; }
            set
            {
                if (value != ListCollections)
                {
                    ListCollections = value;
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

        public string ConditionFromeDate
        {
            get { return _conditionFromDate; }
            set
            {
                if (value != _conditionFromDate)
                {
                    _conditionFromDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ConditionToDate
        {
            get { return _conditionToDate; }
            set
            {
                if (value != _conditionToDate)
                {
                    _conditionToDate = value;
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

        public string ConditionDescription
        {
            get { return _conditionDescription; }
            set
            {
                if (value != _conditionDescription)
                {
                    _conditionDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        public string HighPulseRelated
        {
            get { return _highPulseRelated; }
            set
            {
                if (value != _highPulseRelated)
                {
                    _highPulseRelated = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
