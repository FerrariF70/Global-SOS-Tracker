using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Deserialize data from format json for table All Users
    /// </summary>
    [DataContract]
    public class All_UsersDeserialize
    {
        [DataMember(Name = "")]
        public string Name { get; set; }
        [DataMember(Name = "")]
        public string LastName { get; set; }
        [DataMember(Name = "")]
        public string Longitude { get; set; }
        [DataMember(Name = "")]
        public string Latitude { get; set; }
        [DataMember(Name = "")]
        public string SerialNumberOfModule { get; set; }
        [DataMember(Name = "")]
        public string Pulse { get; set; }
    }
}
