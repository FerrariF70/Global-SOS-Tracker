using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AppGST
{
    /// <summary>
    /// Deserialize data about personnel info
    /// </summary>
    
    [DataContract]
    public class PersonellInfoDeserialize
    {
        [DataMember(Name = "user_id")]
        public string ID { get; set; }

        [DataMember(Name = "first_name")]
        public string Name { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "birthday")]
        public string BirthDate { get; set; }

        [DataMember(Name = "address")]
        public string AddressOfResidence { get; set; }

        [DataMember(Name = "phone_number_2")]
        public string OtherPhoneNumber { get; set; }

        [DataMember(Name = "phone_number_1")]
        public string MobileNumber { get; set; }

        [DataMember(Name = "weight")]
        public double Weight { get; set; }

        [DataMember(Name ="height")]
        public double Growth { get; set; }

        [DataMember(Name = "health_insurance")]
        public string HelthInsurance { get; set; }

        [DataMember(Name = "device_sn")]
        public int SerialNumberOfModule { get; set; }
    }
}
