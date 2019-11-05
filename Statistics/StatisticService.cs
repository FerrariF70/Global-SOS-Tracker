using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    public class StatisticService
    {
        public static List<StatisticsModel> DownloadStatisticData(int? id)
        {
            List<StatisticsModel> list = new List<StatisticsModel>();
            Uri url = new Uri(string.Format("http://dbrainz-flora-server-app.herokuapp.com/getDeviceStatistic?app_user_id={0}",id));

            DeserializeStatistic[] data = RequestsToDataBase.RequestToServer(new DeserializeStatistic(), url) as DeserializeStatistic[];

            foreach (DeserializeStatistic staticAboutPatient in data)
            {
                list.Add(new StatisticsModel(staticAboutPatient.ID, staticAboutPatient.DeviceSerialNumber, staticAboutPatient.Weight, staticAboutPatient.Age,
                    staticAboutPatient.AvaragePulse, staticAboutPatient.TotalDistance, staticAboutPatient.AverageSpeed, staticAboutPatient.StepsCount,
                    staticAboutPatient.CaloriesBurn, staticAboutPatient.StatsStartTime, staticAboutPatient.MinutesSinseStatsstart));
            }
            return list;
        }
    }
}
