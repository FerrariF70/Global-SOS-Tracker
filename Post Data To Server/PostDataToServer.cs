using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppGST
{
    public class PostDataToServer
    {
        /// <summary>
        /// Post data to server with add new client
        /// </summary>
        /// <param name="nameObject"></param>
        /// <param name="url"></param>
        /// <param name="client"></param>
        public async static void PostToServer(object nameObject, Uri url, AddClientSerilization client)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            StringContent content;
            if (nameObject is AddClient)
            {
                DataContractJsonSerializer jsonFomratter = new DataContractJsonSerializer(typeof(AddClientSerilization));
                using (MemoryStream ms = new MemoryStream())
                {
                    jsonFomratter.WriteObject(ms, client);
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        content = new StringContent(sr.ReadToEnd(), Encoding.UTF8, "application/json");
                        response = await httpClient.PostAsync(url, content);
                    }
                }
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Your request willed recieved", "Response From Server", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("HTTP Status:" + response.StatusCode.ToString() + " - Reason:" + response.ReasonPhrase, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
