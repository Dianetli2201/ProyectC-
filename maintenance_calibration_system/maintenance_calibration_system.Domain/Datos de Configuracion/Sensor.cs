using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.Types;

namespace maintenance_calibration_system.Domain.Datos_de_Configuración
{
public class Sensor : Entity 

    {
         public PhysicalMagnitude? physicalMagnitude;
        public string? alphaNumericCode;
        public string? manufacturerName;
        public string principleOperation{get;set;}
        public bool calibrated{get;set;}
        public CommunicationProtocol protocol{get;set;}
       
        public Sensor(PhysicalMagnitude physicalMagnitude, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string principleOperation)
        {
            this.physicalMagnitude = physicalMagnitude;
            this.alphaNumericCode = alphaNumericCode;
            this.manufacturerName = manufacturerName;
            this.protocol = protocol;
            this.principleOperation = principleOperation;
            calibrated = false;
        }
    } 
}