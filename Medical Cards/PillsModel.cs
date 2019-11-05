using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AppGST
{
    /// <summary>
    /// Model Pills
    /// </summary>
    public class PillsModel : ObserverableObject
    {
        private string _prescriptionDate;
        private string _medName;
        private string _medPorpuse;
        private string _activeChemicals;
        private string _medVolume;
        private string _useSchedule;
        private string _expanderHeader;

        public ObservableCollection<PillsModel> ListCollections { get; private set; }
        public PillsModel() { } 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prescriptionDate"></param>
        /// <param name="pillsName"></param>
        /// <param name="medPorpuse"></param>
        /// <param name="activeChemicals"></param>
        /// <param name="medVolume"></param>
        /// <param name="useSchedule"></param>
        /// <param name="expanderHeader"></param>
        public PillsModel(string prescriptionDate,string pillsName,string medPorpuse,string activeChemicals,string medVolume,string useSchedule,string expanderHeader)
        {
            PrescriptionDate = prescriptionDate;
            MedName = pillsName;
            MedPorpuse = medPorpuse;
            ActiveChemicals = activeChemicals;
            MedVolume = medVolume;
            UseSchedule = useSchedule;
            ExpanderHeader = expanderHeader;
        }

        /// <summary>
        /// Initialize list
        /// </summary>
        /// <param name="list"></param>
        public void SetCollection(ObservableCollection<PillsModel> list)
        {
            ListOfPills = list;
        }

        /// <summary>
        /// List of pills
        /// </summary>
        public ObservableCollection<PillsModel> ListOfPills
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
        public string PrescriptionDate
        {
            get { return _prescriptionDate; }
            set
            {
                if (value != _prescriptionDate)
                {
                    _prescriptionDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MedName
        {
            get { return _medName; }
            set
            {
                if (value != _medName)
                {
                    _medName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MedPorpuse
        {
            get { return _medPorpuse; }
            set
            {
                if (value != _medPorpuse)
                {
                    _medPorpuse = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ActiveChemicals
        {
            get { return _activeChemicals; }
            set
            {
                if (value != _activeChemicals)
                {
                    _activeChemicals = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MedVolume
        {
            get { return _medVolume; }
            set
            {
                if (value != _medVolume)
                {
                    _medVolume = value;
                    OnPropertyChanged();
                }
            }
        }
        public string UseSchedule
        {
            get { return _useSchedule; }
            set
            {
                if (value != _useSchedule)
                {
                    _useSchedule = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
