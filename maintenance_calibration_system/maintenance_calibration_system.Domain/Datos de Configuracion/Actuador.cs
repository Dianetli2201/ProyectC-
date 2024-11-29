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
    /// Representa un actuador en el sistema de mantenimiento y calibración.
    /// </summary>
    public abstract class Actuador : Equipment
    {
        public string CodeControl { get; set; }      // Código de control (obligatorio)
        public CommunicationProtocol Protocol { get; set; } // Protocolo de comunicación (obligatorio)
        public SignalControl SignalControl { get; set; }     // Control de señal (obligatorio)
        public bool Maintenance { get; set; } = false; // Mantenimiento (predeterminado: false)

        /// <summary>
        /// Constructor para crear una instancia de Actuador.
        /// </summary>
        public Actuador(string alphanumericCode, PhysicalMagnitude magnitude, string manufacturer, CommunicationProtocol protocol, string codeControl, SignalControl signalControl)
         : base(alphanumericCode, magnitude, manufacturer) // Llama al constructor base.
        {
            Protocol = protocol;
            CodeControl = codeControl;
            SignalControl = signalControl;
        }
    }
}