using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AppGST
{
    public class StatisticViewModel : ObserverableObject, IPageViewModel
    {
        private Timer timer;
        private TimerCallback tc;
        public StatisticsModel statistics { get; } = new StatisticsModel();
        public static ObservableCollection<StatisticsModel> ListStatistic { get; } = new ObservableCollection<StatisticsModel>();
        private Dispatcher Dispatcher { get; } = Dispatcher.CurrentDispatcher;

        public ObservableCollection<StatisticsModel> ItemsStatistic
        {
            get => ListStatistic;
        }
        public string Name { get { return "Statistics"; } }
        private int? ID { get; set; }
        public StatisticViewModel() { }
        public void StartTimer(int? id)
        {
            ID = id;
            tc = new TimerCallback(GetNewStatisticsData);
            timer = new Timer(tc, null, 0, 30000);
        }

        public async void GetNewStatisticsData(object obj)
        {
            List<StatisticsModel> newList = await Task.Run(() => StatisticService.DownloadStatisticData(ID));

            await Task.Run(() =>
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    ListStatistic.Clear();
                    for (int i = 0; i < newList.Count; i++)
                    {
                        ListStatistic.Add(newList[i]);
                    }
                }));
            });
        }
    }

    public class StatisticEvent
    {
        public delegate void StartWorkStatisticHandler(int? id);
        public event StartWorkStatisticHandler WorkStatistEvent;
        public void OnWorkStatistic(int? id)
        {
            WorkStatistEvent(id);
        }
    }
}
