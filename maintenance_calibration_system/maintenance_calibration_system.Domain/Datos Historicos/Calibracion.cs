 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Types;


namespace maintenance_calibration_system.Domain.Datos_Historicos
{
 public class Calibraciones
    {
        public string dateCalibration {get;set;}
        public string nameTechnician {get; set;}
        public string nameCertificateAuthority {get; set;}
        public List<Sensor> calibratedSensors{get;set;}

         public Calibraciones(PhysicalMagnitude physicalMagnitude, string alphaNumericCode,string manufacturerName,CommunicationProtocol protocol,string principelOperation, string dateCalibration, string nameTechnician, string nameCertificateAuthority)
        {
            this.physicalMagnitude = physicalMagnitude;
            this.alphaNumericCode = alphaNumericCode;
            this.manufacturerName = manufacturerName;
            this.protocol = protocol;
            this.principelOperation = principelOperation;
            this.dateCalibration = dateCalibration;
            this.nameTechnician = nameTechnician;
            this.nameCertificateAuthority = nameCertificateAuthority;
            calibrated = false;
        }
        /*Revisar el llenado de la lista*/
        public Calibraciones() 
        {
            calibratedSensors = Main.sensors.Where((x) => x.calibrated).ToList();
        }

        
    }
}