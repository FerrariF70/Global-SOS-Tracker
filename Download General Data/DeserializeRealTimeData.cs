using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AppGST
{
    [DataContract]
    public class DeserializeRealTimeData
    {
        [DataMember(Name = "first_name")]
        public string Name { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "phone_number_1")]
        public string Phone1 { get; set; }

        [DataMember(Name = "phone_number_2")]
        public string Phone2 { get; set; }

        [DataMember(Name = "user_id")]
        public string ID { get; set; }

        [DataMember(Name = "device_sn")]
        public int DeviceSN { get; set; }

        [DataMember(Name = "log_time")]
        public string Time { get; set; }

        [DataMember(Name = "device_status")]
        public int DeviceStatus { get; set; }

        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [DataMember(Name ="longitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "sats")]
        public byte Satellites { get; set; }

        [DataMember(Name = "pulse")]
        public short Pulse { get; set; }

        [DataMember(Name = "battery")]
        public byte Battery { get; set; }

        [DataMember(Name = "gps_status")]
        public byte GPS_Status { get; set; }

        [DataMember(Name = "bt_status")]
        public byte BluetoothStatus { get; set; }

        [DataMember(Name = "gsm_status")]
        public byte GSM_Status { get; set; }

        [DataMember(Name = "sos_status")]
        public byte SOS_Status { get; set; }

        [DataMember(Name = "distance")]
        public double Distance { get; set; }

        [DataMember(Name = "avg_speed")]
        public string AverageSpeed { get; set; }
    }
}
