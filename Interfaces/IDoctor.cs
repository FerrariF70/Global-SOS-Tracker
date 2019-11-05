using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Interface Doctor
    /// </summary>
    public interface IDoctor
    {
        string DoctorContactNumber1 { get; set; }
        string DoctorContactNumber2 { get; set; }
        string DoctorName { get; set; }
        string DoctorLastName { get; set; }
    }
}
