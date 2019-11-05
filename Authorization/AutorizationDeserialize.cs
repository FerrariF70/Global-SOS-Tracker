using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace AppGST
{
    /// <summary>
    /// Deserialize data from format json, Authorization class
    /// </summary>
    [DataContract]
    public class AutorizationDeserialize
    {
        [DataMember(Name = "user_id")]
        public int User_ID { get; set; }
        [DataMember(Name = "user_name")]
        public string Name { get; set; }
        [DataMember(Name = "user_email")]
        public string Email { get; set; }
        [DataMember(Name = "user_pass")]
        public string Password { get; set; }
        [DataMember(Name = "user_priv")]
        public int Priority { get; set; }
        [DataMember(Name = "status")]
        public string Status { get; set; }

    }
}
