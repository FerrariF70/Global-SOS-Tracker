using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AppGST
{
    /// <summary>
    /// ViewModel for Medical Card
    /// </summary>
    public class MedicalCardsViewModel : ObserverableObject, IPageViewModel
    {
        private ICommand _getDataCommnd;
        private ICommand _getDoctorsCommand;
        private ICommand _getPillsCommand;
        private ICommand _getNotesCommand;
        private ICommand _getDiagnosisCommand;

        private MedicalCardsModel _displaydataAboutClient;
        private DoctorsModel _displayDoctors;
        private PillsModel _displayCollectionPills;
        private NotesModel _displayeNotes;
        private DiagnosisModel _displayDiagnoses;

        public object DisplayObject { get; set; } 
        public MedicalCard[] Data { get; private set; }
        public ObservableCollection<DoctorsModel> ListDoctors { get; } = new ObservableCollection<DoctorsModel>();
        public ObservableCollection<PillsModel> ListPills { get; } = new ObservableCollection<PillsModel>();
        public ObservableCollection<NotesModel> ListNotes { get; } = new ObservableCollection<NotesModel>();
        public ObservableCollection<DiagnosisModel> ListDiagnoses { get; } = new ObservableCollection<DiagnosisModel>();

        public  string Name { get { return "Medical Cards"; } }
        private static string Email { get; set; }
        private static string ID { get; set; }
        private static string Key { get; set; }
        public MedicalCardsViewModel() { }
      
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <param name="key"></param>
        public  void  SetParameters(string email,string id,string key)
        {
            Email = email;
            ID = id;
            Key = key;
            DownloadData();
        }
       
        /// <summary>
        /// Displayed on ContentControl all data
        /// </summary>
        public dynamic DisplayDataAboutPatient
        {
            get
            {
                if (DisplayObject is MedicalCardsModel)
                    return _displaydataAboutClient;
                else if (DisplayObject is DoctorsModel)
                    return _displayDoctors;
                else if (DisplayObject is PillsModel)
                    return _displayCollectionPills;
                else if (DisplayObject is NotesModel)
                    return _displayeNotes;
                else if (DisplayObject is DiagnosisModel)
                    return _displayDiagnoses;
                else
                    return null;
            }
            set
            {
                if (value is MedicalCardsModel)
                {
                    if (value != _displaydataAboutClient)
                    {
                        _displaydataAboutClient = value;
                        OnPropertyChanged();
                    }
                }
                else if(value is DoctorsModel)
                {
                    if (value != _displayDoctors)
                    {
                        _displayDoctors = value;
                        OnPropertyChanged();
                    }
                }
                else if(value is PillsModel)
                {
                    if(value!= _displayCollectionPills)
                    {
                        _displayCollectionPills = value;
                        OnPropertyChanged();
                    }
                }
                else if(value is NotesModel)
                {
                    if (value != _displayeNotes)
                    {
                        _displayeNotes = value;
                        OnPropertyChanged();
                    }
                }
                else if(value is DiagnosisModel)
                {
                    if (value != _displayDiagnoses)
                    {
                        _displayDiagnoses = value;
                        OnPropertyChanged();
                    }
                }
            }
        }
       
        /// <summary>
        /// Execute command for data patient
        /// </summary>
        public ICommand GetDataCommand
        {
            get
            {
                if(_getDataCommnd == null)
                {
                    _getDataCommnd = new RelayCommand(param => GetDataPatient(), param => true);
                }
                return _getDataCommnd;
            }
        }

        /// <summary>
        /// Execute command for doctors
        /// </summary>
        public ICommand GetDoctorsCommand
        {
            get
            {
                if(_getDoctorsCommand == null)
                {
                    _getDoctorsCommand = new RelayCommand(param => GetDoctors(), param => true);
                }
                return _getDoctorsCommand;
            }
        }

        /// <summary>
        /// Execute command for pills data
        /// </summary>
        public ICommand GetPillsCommand
        {
            get
            {
                if(_getPillsCommand == null)
                {
                    _getPillsCommand = new RelayCommand(param => GetPills(), param => true);
                }
                return _getPillsCommand;
            }
        }

        /// <summary>
        /// Execute command for notes data
        /// </summary>
        public ICommand GetNotesCommand 
        {
            get
            {
                if(_getNotesCommand == null)
                {
                    _getNotesCommand = new RelayCommand(param => GetNotes(), param => true);
                }
                return _getNotesCommand;
            }
        }

        /// <summary>
        /// Execute command for diagnosis data
        /// </summary>
        public ICommand GetDiagnosisCommand
        {
            get
            {
                if(_getDiagnosisCommand == null)
                {
                    _getDiagnosisCommand = new RelayCommand(param => GetDiagnoses(), param => true);
                }
                return _getDiagnosisCommand;
            }
        }

        /// <summary>
        /// Method download diagnoses
        /// </summary>
        public void GetDiagnoses()
        {
            if (Data != null && Data.Length > 0)
            {
                ListDiagnoses.Clear();
                DiagnosisModel diagnoses = new DiagnosisModel();
                DisplayObject = diagnoses;
                int dgn = 1;
                foreach (PatientHealthCondition diagnose in Data[0].ListHealthCondition)
                {
                    ListDiagnoses.Add(new DiagnosisModel(diagnose.ConditionFromDate, diagnose.ConditionToDate, diagnose.DoctorFirstName, diagnose.DoctorLastName,
                        diagnose.ConditionDescription, diagnose.HighPulseRelated, "Diagnose: " + dgn++));
                }
                diagnoses.SetCollection(ListDiagnoses);
                DisplayDataAboutPatient = diagnoses;
            }
        }

        /// <summary>
        /// Initilization data for Notes
        /// </summary>
        public void GetNotes()
        {
            if (Data != null && Data.Length > 0)
            {
                ListNotes.Clear();
                NotesModel notes = new NotesModel();
                DisplayObject = notes;
                int noteConter = 1;
                foreach (PatientMedicalNotes note in Data[0].ListMedicalNotes)
                {
                    ListNotes.Add(new NotesModel(note.NoteDate, note.NoteDescription, note.DoctorFirstName, note.DoctorLastName, "Note: " + noteConter++));
                }
                notes.SetCollection(ListNotes);
                DisplayDataAboutPatient = notes;
            }
        }

        /// <summary>
        /// Initialization data for pills
        /// </summary>
        private void GetPills()
        {
            if (Data != null && Data.Length > 0)
            {
                ListPills.Clear();
                PillsModel pills = new PillsModel();
                DisplayObject = pills;
                foreach (PatientMedPrescription pill in Data[0].ListMedPrescription)
                {
                    ListPills.Add(new PillsModel(pill.PrescriptionDate, pill.MedName, pill.MedPorpuse, pill.ActiveChemicals, pill.MedVolume, pill.UseSchedule, 
                        pill.MedName));
                }
                pills.SetCollection(ListPills);
                DisplayDataAboutPatient = pills;
            }
        }
        /// <summary>
        /// Initialization data about doctors 
        /// </summary>
        private void GetDoctors()
        {
            if (Data != null && Data.Length>0)
            {
                ListDoctors.Clear();
                DoctorsModel doctor = new DoctorsModel();
                DisplayObject = doctor;
                foreach (PatientPersonalDoctor data in Data[0].Doctor)
                {

                    ListDoctors.Add(new DoctorsModel(data.DoctorName, data.DoctorLastName, data.DoctorOfficeAddress, data.PersonnelFromdate, data.UsualVisitAddress
                        , data.DoctorContactNumber1, data.DoctorContactNumber2, "Doctor: " + data.DoctorName));
                }
                doctor.SetList(ListDoctors);
                DisplayDataAboutPatient = doctor;
            }
            
        }

        /// <summary>
        /// Initialization data about patient
        /// </summary>
        private void GetDataPatient()
        {
            if (Data != null && Data.Length>0)
            {
                MedicalCardsModel medicalCards = new MedicalCardsModel();
                DisplayObject = medicalCards;
                medicalCards.NameClient = Data[0].Name;
                medicalCards.LastName = Data[0].LastName;
                medicalCards.BirthDate = Data[0].BirthDate;
                medicalCards.Gender = Data[0].Gender;
                medicalCards.Weight = Data[0].Weight;
                medicalCards.Growth = Data[0].Growth;
                medicalCards.AddressOfResidence = Data[0].AddressOfResidence;
                medicalCards.ID = Data[0].ID;
                DisplayDataAboutPatient = medicalCards;
            }
        }

        /// <summary>
        /// Download all data for Medical Card
        /// </summary>
        private async void DownloadData()
        {
            try
            {
                Uri uri = new Uri(string.Format("https://medical-data-app.herokuapp.com/getMedicalData?key={0}&e={1}&user_id={2}", Key, Email, ID));
                Data = await Task.Run(() => RequestsToDataBase.RequestToServer(new MedicalCard(), uri) as MedicalCard[]);

                if (Data[0].ErrorDataBase != null)
                {
                    new ConncectionToAPIforMedicalCards().ShowDialog();
                    MessageBox.Show(Data[0].ErrorDataBase, "Response From Server", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (Data[0].Error != null)
                {
                    new ConncectionToAPIforMedicalCards().ShowDialog();
                    MessageBox.Show(Data[0].Error, "Response From Server", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                GetDataPatient();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
