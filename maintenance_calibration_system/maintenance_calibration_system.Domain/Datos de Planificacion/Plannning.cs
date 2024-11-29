using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Domain.Datos_de_Planificación
{
    /// <summary>
    /// Represents a planning event for future calibrations or maintenance.
    /// </summary>
    public abstract class Planning
    {
        public required string EquipmentElement { get; init; } // Equipment that planned the event
        public required PlanningType Type { get; init; }
        public required DateTime ExecutionDate { get; init; }

        protected Planning(string equipmentElement, PlanningType type, DateTime executionDate)
        {
            this.EquipmentElement = equipmentElement;
            this.Type = type;
            this.ExecutionDate = executionDate;
        }
    }

}
