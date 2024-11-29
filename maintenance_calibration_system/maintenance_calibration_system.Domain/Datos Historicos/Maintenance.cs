using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.Datos_de_Configuraci�n;


namespace maintenance_calibration_system.Domain.Datos_Historicos
{
    public abstract class Maintenance : MaintenanceActivity
    {

        public TypeMaintenance TypeMaintenance { get; set; }   // Tipo de mantenimiento
        public List<Actuador> MaintenanceActuador { get; set; } // Lista de actuadores en mantenimiento
        public Maintenance(DateTime dateActivity, Actuador maintainedActuator, TypeMaintenance typeMaintenance, string nameTechnician) 
            : base( dateActivity, nameTechnician) // Llama al constructor base.ntenance typeMaintenance, string dateMaintenance, string nameTechnician)
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