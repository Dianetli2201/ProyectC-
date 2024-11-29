using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Types;

namespace maintenance_calibration_system.Domain.Datos_de_Configuración
{
    /// <summary>
    /// Representa un sensor en el sistema de mantenimiento y calibración.
    /// </summary>
    public abstract class Sensor : Equipment
    {
        public string PrincipleOperation { get; set; }            // Principio de operación del sensor
        public bool Calibrated { get; set; } = false;            // Indica si el sensor está calibrado (predeterminado: false)
        public CommunicationProtocol Protocol { get; set; }       // Protocolo de comunicación utilizado por el sensor

        /// <summary>
        /// Constructor para crear una instancia de Sensor.
        /// </summary>
        public Sensor(string alphanumericCode, PhysicalMagnitude magnitude, string manufacturer, CommunicationProtocol protocol, string principleOperation)
             : base(alphanumericCode, magnitude, manufacturer) // Llama al constructor base.    
        {
            Protocol = protocol;
            PrincipleOperation = principleOperation;
            Calibrated = false;
        }
    }
}