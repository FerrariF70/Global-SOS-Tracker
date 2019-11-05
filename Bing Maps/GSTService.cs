using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppGST
{
    public class GSTService
    {
        /// <summary>
        /// Query for search text
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="searchText"></param>
        /// <param name="Key"></param>
        public static void SearchLocation(string searchText,string Key,List<MapModel> location)
        {
            BingMapsMapEvent mapEvent = new BingMapsMapEvent();
            mapEvent.FocusMap += (Application.Current.Properties["BingMapsViewModel"] as BingMapsViewModel).SetFocucOnLocation;

            Uri url = new Uri(string.Format("http://dev.virtualearth.net/REST/v1/Locations?locality={0}&key={1}", searchText, Key));
            BingMapsRESTToolkit.Response response = RequestsToDataBase.RequestToServer(new BingMapsRESTToolkit.Response(), url) as BingMapsRESTToolkit.Response;
            if (response.ResourceSets != null &&
            response.ResourceSets.Length > 0 &&
            response.ResourceSets[0].Resources != null &&
            response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as BingMapsRESTToolkit.Location;
                double[] coordinates = result.Point.Coordinates;
                Location locationOnMap = new Location(coordinates[0], coordinates[1]);
                location.Add(new MapModel { Location = locationOnMap });
                mapEvent.OnFocusMapEvent(locationOnMap);
                mapEvent.FocusMap -= (Application.Current.Properties["BingMapsViewModel"] as BingMapsViewModel).SetFocucOnLocation;
            }
        }
        public static List<MapModel> GetSearchLocation(string searchText, string Key)
        {
            List<MapModel> location = new List<MapModel>();
            SearchLocation(searchText, Key, location);
            return location;
        }
    }
}
