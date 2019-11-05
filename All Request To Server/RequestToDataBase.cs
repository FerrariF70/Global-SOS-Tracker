using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.Serialization.Json;
using BingMapsRESTToolkit;

namespace AppGST
{
    /// <summary>
    /// All Requests to Data Base Herocku
    /// </summary>
    public class RequestsToDataBase
    {
        public static object RequestToServer(object nameObject, Uri url)
        {
            try
            {
                DataContractJsonSerializer json = null;
                WebRequest request = WebRequest.Create(url);
                using (WebResponse response = request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = reader.ReadToEnd();
                        if (nameObject is Change_Resetore_Password)
                        {
                            json = new DataContractJsonSerializer(typeof(Change_Resetore_Password[]));
                        }
                        else if (nameObject is DeserializeRealTimeData)
                        {
                            json = new DataContractJsonSerializer(typeof(DeserializeRealTimeData[]));
                        }
                        else if (nameObject is All_UsersDeserialize)
                        {
                            json = new DataContractJsonSerializer(typeof(All_UsersDeserialize[]));
                        }
                        else if (nameObject is AutorizationDeserialize)
                        {
                            json = new DataContractJsonSerializer(typeof(AutorizationDeserialize[]));
                        }
                        else if (nameObject is HistoryDeserialize)
                        {
                            json = new DataContractJsonSerializer(typeof(HistoryDeserialize[]));
                        }
                        else if (nameObject is MedicalCard)
                        {
                            json = new DataContractJsonSerializer(typeof(MedicalCard[]));
                        }
                        else if (nameObject is MicroControllersDeserialize)
                        {
                            json = new DataContractJsonSerializer(typeof(MicroControllersDeserialize[]));
                        }
                        else if (nameObject is PersonellInfoDeserialize)
                        {
                            json = new DataContractJsonSerializer(typeof(PersonellInfoDeserialize[]));
                        }
                        else if (nameObject is Response)
                        {
                            json = new DataContractJsonSerializer(typeof(Response));
                        }
                        else if (nameObject is ConnectToApiMedicalCardDeserialize)
                        {
                            json = new DataContractJsonSerializer(typeof(ConnectToApiMedicalCardDeserialize[]));
                        }
                        else if(nameObject is DeserializeStatistic)
                        {
                            json = new DataContractJsonSerializer(typeof(DeserializeStatistic[]));
                        }
                        else if(nameObject is AlarmsDeserialize)
                        {
                            json = new DataContractJsonSerializer(typeof(AlarmsDeserialize[]));
                        }
                        return json.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(line)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Don't connect to Server", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return null;
        }
    }
}
