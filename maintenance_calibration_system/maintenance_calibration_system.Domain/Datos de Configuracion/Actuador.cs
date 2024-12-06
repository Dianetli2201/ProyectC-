using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;

namespace maintenance_calibration_system.Domain.Datos_de_Configuración
{
    /// <summary>
    /// Representa un actuador en el sistema de mantenimiento y calibración.
    /// </summary>
    public abstract class Actuador : Equipment
    {
        #region Properties
            public string CodeControl { get; set; }      // Código de control (obligatorio)
            public SignalControl SignalControl { get; set; }     // Control de señal (obligatorio)
            public bool Maintenance { get; set; } = false; // Mantenimiento (predeterminado: false)
        #endregion
        /// <summary>
        /// Constructor para crear una instancia de Actuador.
        /// </summary>
        public Actuador(Guid id, string alphanumericCode, PhysicalMagnitude magnitude, string manufacturer, string codeControl, SignalControl signalControl)
         : base(id, alphanumericCode, magnitude, manufacturer) // Llama al constructor base.
        {
       
            CodeControl = codeControl;
            SignalControl = signalControl;
        }
    }
}