using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.Types;

namespace maintenance_calibration_system.Domain.Datos_de_Planificación
{
    /// <summary>
    /// Representa un evento de planificación para futuras calibraciones o mantenimiento.
    /// </summary>
    public class Planning : Entity
    {
        #region Properties
            public string? EquipmentElement { get; set; } // Equipo que planificó el evento
            public  PlanningTypes Type { get; set; }       // Tipo de planificación
            public DateTime ExecutionDate { get; set; }  // Fecha de ejecución
        #endregion

        protected Planning() { }

        public Planning(Guid id, string? equipmentElement, PlanningTypes type, DateTime executionDate)
            :base(id)
        {
            EquipmentElement = equipmentElement;
            Type = type;
            ExecutionDate = executionDate;
        }
    }
}
