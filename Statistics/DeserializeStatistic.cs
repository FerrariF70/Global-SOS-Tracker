using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AppGST
{
    [DataContract]
    public class DeserializeStatistic
    {
        [DataMember(Name = "device_sn")]
        public int DeviceSerialNumber { get; set; }

        [DataMember(Name = "user_id")]
        public string ID { get; set; }

        [DataMember(Name = "user_weight")]
        public float Weight { get; set; } 

        [DataMember(Name = "user_age")]
        public byte Age { get; set; }

        [DataMember(Name = "avg_pulse")]
        public double AvaragePulse { get; set; }

        [DataMember(Name = "total_distance")]
        public double TotalDistance { get; set; }

        [DataMember(Name = "avg_speed")]
        public double AverageSpeed { get; set; }

        [DataMember(Name = "steps_count")]
        public int StepsCount { get; set; }

        [DataMember(Name = "calories_burn")]
        public float CaloriesBurn { get; set; }

        [DataMember(Name = "stats_start_time")]
        public string StatsStartTime { get; set; }

        [DataMember(Name = "minutes_since_stats_start")]
        public int MinutesSinseStatsstart { get; set; }
    }
}
