using maintenance_calibration_system.Domain.Datos_de_Configuración;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;

namespace maintenance_calibration_system.Domain.Datos_de_Configuracion
{
    public abstract class Equipment : Entity
    {
            public string AlphanumericCode { get; set; } // Código alfanumérico del equipo.
            public PhysicalMagnitude Magnitude { get; set; } // Magnitud física asociada.
            public string Manufacturer { get; set; } // Nombre del fabricante.

            protected Equipment(string alphanumericCode, PhysicalMagnitude magnitude, string manufacturer) // Constructor.
            {
                AlphanumericCode = alphanumericCode;
                Magnitude = magnitude;
                Manufacturer = manufacturer;
            }
        
    }
}
