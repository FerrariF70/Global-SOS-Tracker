using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGST
{
    /// <summary>
    /// Interface for microcontroller
    /// </summary>
    public interface IMicroControllers
    {
        string GSMModule_Status { get; set; }
        string Bluetooth_Status { get; set; }
        string PulseSensor_Status { get; set; }
        string PrecentageBattery_Status { get; set; }
        string GPS_Status { get; set; }
        string Satellites { get; set; }
        string SerialNumberOfModule { get; set; }
    }
}
