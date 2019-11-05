using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace AppGST
{
    /// <summary>
    /// Deserialize from format json to Restore Password
    /// </summary>
    [DataContract]
    public class Change_Resetore_Password
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "phone_number")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}
