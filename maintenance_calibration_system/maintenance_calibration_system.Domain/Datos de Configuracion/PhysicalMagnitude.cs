using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;

namespace maintenance_calibration_system.Domain.Datos_de_Configuración
{
    /// <summary>
    /// Representa una magnitud física en el sistema.
    /// </summary>
    public abstract class PhysicalMagnitude : ValueObject
    {
      
        public string Name { get; set; }      // Nombre de la magnitud física
        public string Magnitude { get; set; }    // Valor de la magnitud física

        public PhysicalMagnitude(string name, string magnitude)
        {
            Name = name;       
            Magnitude = magnitude; 
        }
    }
}