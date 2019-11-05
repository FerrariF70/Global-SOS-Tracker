using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{

    /// <summary>
    /// Model for Statistics
    /// </summary>
    public class StatisticsModel : ObserverableObject
    {
        private string _id;
        private int _deviceSN;
        private float _weight;
        private byte _age;
        private double _avgPulse;
        private double _totalDistance;
        private double _avgSpeed;
        private int _stepsCount;
        private float _caloriesBurn;
        private string _statsStartTime;
        private int _minutesSinceStatsStart;
        public StatisticsModel() { }
        public StatisticsModel(string id,int device_sn,float weight,byte age,double avgPulse,double totalDistance,double avgSpeed,int stepsCount,float caloriesBurn,
            string statsStartTime,int minutesSinceStatsStart)
        {
            ID = id;
            DeviceSN = device_sn;
            Weight = weight;
            Age = age;
            AveragePulse = avgPulse;
            TotalDistance = totalDistance;
            AverageSpeed = avgSpeed;
            StepsCount = stepsCount;
            CaloriesBurn = caloriesBurn;
            StatsStartTime = statsStartTime;
            MinutesSiceStatsStart = minutesSinceStatsStart;
        }
        public string ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        public int DeviceSN
        {
            get { return _deviceSN; }
            set
            {
                if (value != _deviceSN)
                {
                    _deviceSN = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Weight
        {
            get { return _weight; }
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Age
        {
            get { return _age; }
            set
            {
                if (value != _age)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }
        public double AveragePulse
        {
            get => _avgPulse;
            set
            {
                if (value != _avgPulse)
                {
                    _avgPulse = value;
                    OnPropertyChanged();
                }
            }
        }

        public double TotalDistance
        {
            get => _totalDistance;
            set
            {
                if (value != _totalDistance)
                {
                    _totalDistance = value;
                    OnPropertyChanged();
                }
            }
        }

        public double AverageSpeed
        {
            get => _avgSpeed;
            set
            {
                if (value != _avgSpeed)
                {
                    _avgSpeed = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int StepsCount
        {
            get => _stepsCount;
            set
            {
                if (value != _stepsCount)
                {
                    _stepsCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public float CaloriesBurn
        {
            get => _caloriesBurn;
            set
            {
                if (value != _caloriesBurn)
                {
                    _caloriesBurn = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StatsStartTime
        {
            get => _statsStartTime;
            set
            {
                if (value != _statsStartTime)
                {
                    _statsStartTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MinutesSiceStatsStart
        {
            get => _minutesSinceStatsStart;
            set
            {
                if (value != _minutesSinceStatsStart)
                {
                    _minutesSinceStatsStart = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
