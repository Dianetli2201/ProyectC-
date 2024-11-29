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
        public required string EquipmentElement { get; init; } // Equipo que planificó el evento
        public required PlanningType Type { get; init; }       // Tipo de planificación
        public required DateTime ExecutionDate { get; init; }  // Fecha de ejecución

        protected Planning(string equipmentElement, PlanningType type, DateTime executionDate)
        {
            EquipmentElement = equipmentElement;
            Type = type;
            ExecutionDate = executionDate;
        }
    }
}
