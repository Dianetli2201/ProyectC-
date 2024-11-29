 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.Types;

namespace maintenance_calibration_system.Domain.Datos_de_Configuración
{
 public class Actuador 
    {
         public PhysicalMagnitude? physicalMagnitude;
        public string? alphaNumericCode;
        public string? manufacturerName;
        public string codeControl {get;set;} 
        public CommunicationProtocol protocol{get;set;}
        public SignalControl signalControl{get;set;}
        public bool maintenance {get; set;}
     

        public Actuador (PhysicalMagnitude physicalMagnitude, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string codeControl, SignalControl signalControl)
        {
            this.physicalMagnitude = physicalMagnitude;
            this.alphaNumericCode = alphaNumericCode;
            this.manufacturerName = manufacturerName;
            this.protocol = protocol;
            this.codeControl = codeControl;
            this.signalControl = signalControl;
            maintenance = false;
        }
    } 
}