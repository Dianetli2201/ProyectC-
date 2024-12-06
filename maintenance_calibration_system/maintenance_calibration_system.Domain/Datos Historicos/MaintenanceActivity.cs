using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;

namespace maintenance_calibration_system.Domain.Datos_Historicos
{
    public abstract class MaintenanceActivity : Entity
    {
        #region Properties
                public DateTime DateActivity { get; set; } // Fecha en que se realizó la actividad.
                public string? NameTechnician { get; set; } // Nombre del técnico que realizó la actividad.
        
        #endregion
        protected MaintenanceActivity(Guid id, DateTime dateActivity, string? nameTechnician)
                :base(id) // Constructor.
            {
                DateActivity = dateActivity;
                NameTechnician = nameTechnician;
            }
        
    }
}
