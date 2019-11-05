using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Interface Medical data
    /// </summary>
    public interface IMedicalData
    {
        string NamePills { get; set; }
        string Pulse { get; set; }
        string TakingPills { get; set; }
        string PrescriptionDate { get; set; }
        string Weight { get; set; }
        string Growth { get; set; }
        string Complaints { get; set; }
        string NoteDate { get; set; }
        string HealthInsurance { get; set; }
        string DoctorConclusion { get; set; }
        string StateOfPatient { get; set; }
    }
}
