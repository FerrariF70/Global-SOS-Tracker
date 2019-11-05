using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Deserialize data about microcontrollers
    /// </summary>
    [DataContract]
    public class MicroControllersDeserialize
    {
        [DataMember(Name = "gsm_status")]
        public string GSMModule_Status { get; set; }
        [DataMember(Name = "bt_status")]
        public string Bluetooth_Status { get; set; }
        [DataMember(Name = "pulse")]
        public string PulseSensor_Status { get; set; }
        [DataMember(Name = "battery")]
        public string PrecentageBattery_Status { get; set; }
        [DataMember(Name = "gps_status")]
        public string GPS_Status { get; set; }
        [DataMember(Name = "sats")]
        public string Satellites { get; set; }
        [DataMember(Name = "device_sn")]
        public string SerialNumberOfModule { get; set; }
    }
}
