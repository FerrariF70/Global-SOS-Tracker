using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Deserialize json format from server
    /// </summary>
    [DataContract]
    public class AlarmsDeserialize
    {
        [DataMember(Name = "first_name")]
        public string Name { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "incident_id")]
        public int IncidentID { get; set; }

        [DataMember(Name = "worker_id")]
        public string EmployeerName { get; set; }

        [DataMember(Name = "latitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "longitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "pulse")]
        public short Pulse { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "time_log")]
        public string TimeIncident { get; set; }

        [DataMember(Name = "device_phone_number")]
        public string Phone { get; set; }
    }
}
