using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Class Client
    /// </summary>
    public class Client : OtherDetailForClient ,IMedicalData
    {
        public virtual string ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Age { get; set; }
        public virtual string BirthDate { get; set; }
        public virtual string AddressOfResidence { get; set; }
        public virtual string Gender { get; set; }
        public virtual string NamePills { get; set; }
        public virtual string TakingPils { get; set; }
        public virtual string PrescriptionDate { get; set; }
        public virtual string Weight { get; set; }
        public virtual string Growth { get; set; }
        public virtual string Complaints { get; set; }
        public virtual string NoteDate { get; set; }
        public virtual string HealthInsurance { get; set; }
        public virtual string TakingPills { get; set; }
        public virtual string DoctorConclusion { get; set; }
        public virtual string StateOfPatient { get; set; }
    }
}
