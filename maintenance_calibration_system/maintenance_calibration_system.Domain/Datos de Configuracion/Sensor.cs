using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;

namespace maintenance_calibration_system.Domain.Datos_de_Configuracion
{
    /// <summary>
    /// Representa un sensor en el sistema de mantenimiento y calibración.
    /// </summary>
    public class Sensor : Equipment
    {
        #region Properties
            public string? PrincipleOperation { get; set; }            // Principio de operación del sensor
            public bool Calibrated { get; set; } = false;            // Indica si el sensor está calibrado (predeterminado: false)
            public CommunicationProtocol Protocol { get; set; }       // Protocolo de comunicación utilizado por el sensor

        #endregion

        protected Sensor() { }

        /// <summary>
        /// Constructor para crear una instancia de Sensor.
        /// </summary>
        public Sensor(Guid id, string? alphanumericCode, PhysicalMagnitude magnitude, string? manufacturer, CommunicationProtocol protocol, string? principleOperation)
             : base(id, alphanumericCode, magnitude, manufacturer) // Llama al constructor base.    
        {
            Protocol = protocol;
            PrincipleOperation = principleOperation;
            
        }
    }
}