using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Maps.MapControl.WPF;
using System.Globalization;

namespace AppGST
{
    /// <summary>
    /// Servise download data from database
    /// </summary>
    public class ServiceHistory
    {
        private readonly static string Key = "WJZEJwHrZpkfmhSMv2hn~lXoa_QBX-gwjc19FS2YT3g~ArdlrzM_boCRul2DXI1HcyhBnHWqV2Ch0ajL3H1yaWaQstxxOTh5PD4kZ_Cb9bXJ";
        public static List<HistoryModel> DownloadHistoryClient(string snModuleGST)
        {
            List<HistoryModel> data = new List<HistoryModel>();
            int precentageComplete = 0;
            int n = 0, highestPrecentageReached = 0;
            IProgress<double> progress = new Progress<double>(UpdateProgressBarr);
            try
            {
                StringBuilder locationAddress = new StringBuilder();
                StringBuilder FromDate = Application.Current.Properties["FromDate"] as StringBuilder;
                StringBuilder ToDate = Application.Current.Properties["ToDate"] as StringBuilder;
                if (FromDate == null || ToDate == null)
                {
                    MessageBox.Show("Not all dates selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Uri uri = new Uri(string.Format("https://dbrainz-flora-server-app.herokuapp.com/getLocationHistory?device_sn={0}&from_date={1}&to_date={2}",
                        snModuleGST, FromDate.ToString(), ToDate.ToString()));
                    HistoryDeserialize[] historyEvents = RequestsToDataBase.RequestToServer(new HistoryDeserialize(), uri) as HistoryDeserialize[];
                    if (historyEvents.Length > 0)
                    {
                        foreach (HistoryDeserialize _event in historyEvents)
                        {
                            precentageComplete = (int)((float)n++ / (float)historyEvents.Length * 100);

                            if (precentageComplete > highestPrecentageReached)
                            {
                                progress.Report(precentageComplete);
                                highestPrecentageReached = precentageComplete;
                            }
                            uri = new Uri(string.Format("https://dev.virtualearth.net/rest/v1/locations/{0},{1}?&key={2}", _event.Latitude, _event.Longitude, Key));
                            BingMapsRESTToolkit.Response response = RequestsToDataBase.RequestToServer(new BingMapsRESTToolkit.Response(), uri) as BingMapsRESTToolkit.Response;
                            if (response.ResourceSets != null &&
                                response.ResourceSets.Length > 0 &&
                                response.ResourceSets[0].Resources != null &&
                                response.ResourceSets[0].Resources.Length > 0)
                            {
                                BingMapsRESTToolkit.Location location = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                                if (location.Address.AddressLine == null)
                                {
                                    locationAddress.Append(location.Address.AdminDistrict + ", " + location.Address.CountryRegion);
                                }
                                else locationAddress.Append(location.Address.AddressLine + ", " + location.Address.CountryRegion);

                            }

                            data.Add(new HistoryModel(_event.MaximalPulsePerDay, locationAddress.ToString(), _event.TimeIncedent, _event.SerialNumberOfModule));
                            locationAddress.Clear();
                        }
                        progress.Report(precentageComplete + 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        //Method for update progress bar
        public static void UpdateProgressBarr(double precentage)
        {
            (Application.Current.Properties["HistoryModel"] as HistoryModel).Value = precentage;
        }
    }
}
