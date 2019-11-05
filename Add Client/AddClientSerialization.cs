using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    ///Serialize data json format to server
    /// </summary>
    [DataContract]
    public class AddClientSerilization      
    {
        
        [DataMember(Name = "first_name")]
        public string Name { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        
        [DataMember(Name = "birthday")]
        public string BirthDate { get; set; }
        [DataMember(Name = "address")]
        public string AddressOfResidence { get; set; }
        [DataMember(Name = "gender")]
        public byte Gender { get; set; }
        [DataMember(Name = "height")]
        public double Growth { get; set; }
        [DataMember(Name = "weight")]
        public double Weight { get; set; }
        [DataMember(Name = "phone_num_1")]
        public string MobileNumber { get; set; }
        [DataMember(Name = "phone_num_2")]
        public string OtherPhoneNumber { get; set; }
        [DataMember(Name = "device_sn")]
        public int SerialNumberOfModule { get; set; }
        [DataMember(Name = "user_id")]
        public string ID { get; set; }
        [DataMember(Name = "health_insurance")]
        public string HealthInsurance { get; set; }
        [DataMember(Name = "app_user_id")]
        public int AppUserID { get;set; }

        public AddClientSerilization(string id,int appUserID,int deviceSN,string name,string lastName,string phone1,string phone2,string address,double weight,double growth,string healthInsurance,
            string birthDate,byte gender)
        {
            ID = id;
            AppUserID = appUserID;
            SerialNumberOfModule = deviceSN;
            Name = name;
            LastName = lastName;
            MobileNumber = phone1;
            OtherPhoneNumber = phone2;
            AddressOfResidence = address;
            Weight = weight;
            Growth = growth;
            HealthInsurance = healthInsurance;
            BirthDate = birthDate;
            Gender = gender;
              
        }
    }
}
