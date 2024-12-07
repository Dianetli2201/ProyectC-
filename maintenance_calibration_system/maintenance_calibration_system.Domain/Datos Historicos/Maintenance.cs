using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.Datos_de_Configuración;
using maintenance_calibration_system.Domain.Common;

namespace maintenance_calibration_system.Domain.Datos_Historicos
{
    public class Maintenance : MaintenanceActivity
    {
        #region Properties
            public TypeMaintenance TypeMaintenance { get; set; }   // Tipo de mantenimiento
            public List<Actuador> MaintenanceActuador { get; set; } // Lista de actuadores en mantenimiento

        #endregion

        protected Maintenance() { }

        public Maintenance(Guid id, DateTime dateActivity, TypeMaintenance typeMaintenance, string? nameTechnician) 
            : base(id, dateActivity, nameTechnician)      // Llama al constructor base
        {
            TypeMaintenance = typeMaintenance;
            MaintenanceActuador = new List<Actuador>();
        }

        /* Ver el llenado de la lista 
        public Maintenance()
        {
            MaintenanceActuador = Main.Actuadores.Where(x => x.Maintenance).ToList(); // Obtener actuadores en mantenimiento
        }
        */
    }
}