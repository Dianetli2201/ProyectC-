using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Domain.Types
{
public enum TypeMaintenance
    {
        Preventivo,// Mantenimiento realizado de manera programada para prevenir fallos.
        Correctivo,// Mantenimiento realizado para corregir fallos detectados.
    }
}