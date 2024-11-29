using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Datos_de_Configuración;
using maintenance_calibration_system.Domain.Types;

namespace maintenance_calibration_system.Domain.Datos_Historicos
{
    public abstract class Calibration : MaintenanceActivity
    {

        public string NameCertificateAuthority { get; set; }      // Nombre de la autoridad certificadora
        public List<Sensor> CalibratedSensors { get; set; }       // Lista de sensores calibrados

        public Calibration(string nameCertificateAuthority, DateTime dateActivity, Sensor calibratedSensor, string nameTechnician, string certifyingEntity)
            : base( dateActivity, nameTechnician) // Llama al constructor base.
        {
            NameCertificateAuthority = nameCertificateAuthority;   // Asignar nombre de la autoridad certificadora
            CalibratedSensors = new List<Sensor>();                // Inicializar lista de sensores calibrados
        }

        /* Revisar el llenado de la lista 
        public Calibraciones()
        {
            CalibratedSensors = Main.Sensors.Where(x => x.Calibrated).ToList(); // Obtener sensores calibrados
        }
        */
    }
}