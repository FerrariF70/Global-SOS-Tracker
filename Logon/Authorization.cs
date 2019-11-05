using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppGST
{
    /// <summary>
    /// Class Authentication and connection to application
    /// </summary>
    public struct Authorization
    {
        private string url;
        AutorizationDeserialize[] obj;
        public bool ConnectToServer(string email, string password, out int? user_id)
        {
            user_id = null;
            if ((email.Equals(string.Empty) || password.Equals(string.Empty)))
            {
                MessageBox.Show("You don't completed all field", "Authorization", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            else if (email != string.Empty && password != string.Empty)
            {
                Uri uri;
                uri = new Uri(string.Format("https://dbrainz-flora-server-app.herokuapp.com/getAppUserAccount?u={0}&p={1}", email, password));
                obj = (AutorizationDeserialize[])RequestsToDataBase.RequestToServer(new AutorizationDeserialize(), uri);
                if (obj == null) return false;
                if (obj != null)
                {
                    user_id = obj[0].User_ID;
                    Application.Current.Properties["user"] = obj[0].Priority;
                    if (obj[0].Status == "error")
                    {
                        MessageBox.Show("Email or Password dosen't correct please check is valid", "Incorecct data", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    };
                }
            }
            return true;
        }
    }
}
