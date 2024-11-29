 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Domain.Datos_de_Configuración
{
 public class PhysicalMagnitude
    {
        public string name{get;set;}
        public string Magnitude{get;set;}

        public PhysicalMagnitude(string name, string magnitude)
        {
            this.name = name;
            this.Magnitude = magnitude;
        }
    }
}