using maintenance_calibration_system.Domain.Datos_de_Configuración;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.ValueObjects;

namespace maintenance_calibration_system.Domain.Datos_de_Configuracion
{
    public abstract class Equipment : Entity
    {
        #region Properties
            public string? AlphanumericCode { get; set; } // Código alfanumérico del equipo.
            public required PhysicalMagnitude Magnitude { get; set; } // Magnitud física asociada.
            public string? Manufacturer { get; set; } // Nombre del fabricante.
        #endregion
        // Constructor sin parámetros
            public Equipment() { }
        
            protected Equipment(Guid id, string? alphanumericCode, PhysicalMagnitude magnitude, string? manufacturer)
            :base(id)// Constructor.
            {
                AlphanumericCode = alphanumericCode;
                Magnitude = magnitude;
                Manufacturer = manufacturer;
            }
        
    }
}
