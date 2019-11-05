using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AppGST
{
    /// <summary>
    /// ViewModel for Personnel Info
    /// </summary>
    public class PersonnelInfoViewModel : ObserverableObject, IPageViewModel
    {
        public PersonnelInfoModel PersonalInfo { get; } = new PersonnelInfoModel();
        public static ObservableCollection<PersonnelInfoModel> ListOfPersonnelInfo { get; } = new ObservableCollection<PersonnelInfoModel>();
        public string Name { get { return "Personal Info"; } }
        public PersonnelInfoViewModel() { }
         
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonnelInfoViewModel(int? id)
        {
            if(ListOfPersonnelInfo == null)
            DownloadAllPersonnelInfo(id);
        }

        /// <summary>
        /// List of personnel info
        /// </summary>
        public ObservableCollection<PersonnelInfoModel> ItemsPersonnelInfo
        {
            get { return ListOfPersonnelInfo; }
        }

        /// <summary>
        /// Download data from database 
        /// </summary>
        public async void DownloadAllPersonnelInfo(int? id)
        {
            List<PersonnelInfoModel> list = await Task.Run(()=> ServicePersonnelInfo.DownloadAllPersonnelInfo(id));
            ListOfPersonnelInfo.Clear();
            list.ForEach(client => ListOfPersonnelInfo.Add(client));
        }
    }
    public class PersonnelInfoEvent
    {
        public delegate void DownloadPersonnelInfoDataHandler(int? id);
        public event DownloadPersonnelInfoDataHandler DownloadPersonnelInfoData;
        public void OnDownloadPersonnelInfo(int? id)
        {
            DownloadPersonnelInfoData(id);
        }
    }
}
