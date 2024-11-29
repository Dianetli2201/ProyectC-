using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Domain.Datos_Historicos
{
    public abstract class MaintenanceActivity
    {
            public DateTime DateActivity { get; set; } // Fecha en que se realizó la actividad.
            public string NameTechnician { get; set; } // Nombre del técnico que realizó la actividad.

            protected MaintenanceActivity(DateTime dateActivity, string nameTechnician) // Constructor.
            {
                DateActivity = dateActivity;
                NameTechnician = nameTechnician;
            }
        
    }
}
