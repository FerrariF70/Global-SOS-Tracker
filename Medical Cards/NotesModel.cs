using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Model Medical Cards
    /// </summary>
    public class NotesModel : ObserverableObject
    {
        private string _noteDate;
        private string _noteDescription;
        private string _doctorName;
        private string _doctorLastNmae;
        private string _expanderHeader;
        public ObservableCollection<NotesModel> ListCollections { get; private set; }
        public NotesModel() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="noteDate"></param>
        /// <param name="noteDescription"></param>
        /// <param name="doctorName"></param>
        /// <param name="doctorLastName"></param>
        /// <param name="expanderHeader"></param>
        public NotesModel(string noteDate, string noteDescription, string doctorName, string doctorLastName, string expanderHeader)
        {
            NoteDate = noteDate;
            NoteDescription = noteDescription;
            DoctorName = doctorName;
            DoctorLastName = doctorLastName;
            ExpanderHeader = expanderHeader;
        }
        
        /// <summary>
        /// Initialize list
        /// </summary>
        /// <param name="list"></param>
        public void SetCollection(ObservableCollection<NotesModel> list)
        {
            ListCollections = list;
        }

        /// <summary>
        /// List of Notes
        /// </summary>
        public ObservableCollection<NotesModel> ListOfNotes
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
        public string NoteDate
        {
            get { return _noteDate; }
            set
            {
                if (value != _noteDate)
                {
                    _noteDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string NoteDescription
        {
            get { return _noteDescription; }
            set
            {
                if (value != _noteDescription)
                {
                    _noteDescription = value;
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
            get { return _doctorLastNmae; }
            set
            {
                if (value != _doctorLastNmae)
                {
                    _doctorLastNmae = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
