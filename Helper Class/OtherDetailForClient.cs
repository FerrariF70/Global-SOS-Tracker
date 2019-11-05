using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Class Other elements for client
    /// </summary>
    public class OtherDetailForClient
    {
        public virtual string CurrentLocation { get; set; }
        public virtual string SerialNumberOfModule { get; set; }
        public virtual string Pulse { get; set; }
        public virtual string MaximalPulsePerDay { get; set; }
        public virtual string TimeIncedent { get; set; }
        public virtual string Longitude { get; set; }
        public virtual string Latitude { get; set; }
        public virtual string AmbulanceCall { get; set; }
        public virtual string OtherPhoneNumber { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string EmployeerName { get; set; }
    }
}
