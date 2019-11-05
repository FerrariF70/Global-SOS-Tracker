using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AppGST
{
    /// <summary>
    /// Deserialize data to ConnectToApiMedicalCardDeserialize
    /// </summary>
    [DataContract]
    public class ConnectToApiMedicalCardDeserialize
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "access")]
        public string Access { get; set; }
        [DataMember(Name = "access_key_timeout")]
        public string Message { get; set; }
    }
}
