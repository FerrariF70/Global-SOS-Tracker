using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AppGST
{
    /// <summary>
    /// Model for Medical Card
    /// </summary>
    public class MedicalCardsModel : ObserverableObject
    {
        private string _id;
        private string _name;
        private string _lastName;
        private string _resedentialAddress;
        private string _birthDate;
        private string _gender;
        private string _weight;
        private string _growth;

        public ObservableCollection<MedicalCardsModel> _listCollections { get; private set; }
        public MedicalCardsModel() { }
      
        /// <summary>
        /// Initialize list
        /// </summary>
        /// <param name="list"></param>
        public void SetList(ObservableCollection<MedicalCardsModel> list)
        {
            ListMedicalCards = list;
        }

        /// <summary>
        /// List of Medcial data
        /// </summary>
        public ObservableCollection<MedicalCardsModel> ListMedicalCards
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
        public string NameClient
        {
            get
            { return _name; }
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
        public string AddressOfResidence
        {
            get
            {
                return _resedentialAddress;
            }
            set
            {
                if (value != _resedentialAddress)
                {
                    _resedentialAddress = value;
                    OnPropertyChanged();
                }
            }
        }
        public string BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value != _birthDate)
                {
                    _birthDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Growth
        {
            get { return _growth; }
            set
            {
                if (value != _growth)
                {
                    _growth = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
