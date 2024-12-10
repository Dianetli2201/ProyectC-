using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;

namespace maintenance_calibration_system.Domain.Datos_de_Configuracion
{
    /// <summary>
    /// Representa un actuador en el sistema de mantenimiento y calibración.
    /// </summary>
    public class Actuador : Equipment
    {
        #region Properties
            public string? CodeControl { get; set; }      // Código de control (obligatorio)
            public SignalControl SignalControl { get; set; }     // Control de señal (obligatorio)
            public bool Maintenance { get; set; } = false; // Mantenimiento (predeterminado: false)
        #endregion'

        protected Actuador () { } 

        /// <summary>
        /// Constructor para crear una instancia de Actuador.
        /// </summary>
        public Actuador(Guid id, string? alphanumericCode, PhysicalMagnitude magnitude, string? manufacturer, string? codeControl, SignalControl signalControl)
         : base(id, alphanumericCode, magnitude, manufacturer) // Llama al constructor base.
        {
       
            CodeControl = codeControl;
            SignalControl = signalControl;
        }
    }
}