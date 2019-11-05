using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    public class ServicePersonnelInfo
    {
        /// <summary>
        ///Service download data personnel info from database
        /// </summary>
        /// <returns></returns>
        public static List<PersonnelInfoModel> DownloadAllPersonnelInfo(int? id) 
        {
            Uri url = new Uri(string.Format("http://dbrainz-flora-server-app.herokuapp.com/getDeviceUser?user_id=0"));
            List<PersonnelInfoModel> data = new List<PersonnelInfoModel>();
            PersonellInfoDeserialize[] personalInfo = RequestsToDataBase.RequestToServer(new PersonellInfoDeserialize(), url) as PersonellInfoDeserialize[];

            foreach (PersonellInfoDeserialize personal in personalInfo)
            {
                data.Add(new PersonnelInfoModel(personal.Name,personal.LastName,personal.SerialNumberOfModule,personal.AddressOfResidence,personal.MobileNumber,
                    personal.OtherPhoneNumber,personal.HelthInsurance,personal.ID,personal.Weight,personal.Growth,personal.BirthDate));
            }

            return data;
        }
    }
}
