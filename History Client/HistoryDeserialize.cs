using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AppGST
{
    [DataContract]
    public class HistoryDeserialize
    {
        [DataMember(Name = "pulse")]
        public short MaximalPulsePerDay { get; set; }
        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }
        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }
        [DataMember(Name = "log_time")]
        public string TimeIncedent { get; set; }
        [DataMember(Name = "device_sn")]
        public int SerialNumberOfModule { get; set; }
    }
}
