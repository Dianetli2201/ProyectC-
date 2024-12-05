using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Types;

namespace maintenance_calibration_system.Domain.Datos_de_Planificación
{
    /// <summary>
    /// Representa un evento de planificación para futuras calibraciones o mantenimiento.
    /// </summary>
    public abstract class Planning
    {
        #region Properties
            public required string EquipmentElement { get; set; } // Equipo que planificó el evento
            public  PlanningType Type { get; set; }       // Tipo de planificación
            public required DateTime ExecutionDate { get; set; }  // Fecha de ejecución
        #endregion

        protected Planning(string equipmentElement, PlanningType type, DateTime executionDate)
        {
            EquipmentElement = equipmentElement;
            Type = type;
            ExecutionDate = executionDate;
        }
    }
}
