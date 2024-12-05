using maintenance_calibration_system.Domain.Datos_Historicos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.MaintenanceActivities
{
    public class MaintenanceActivityEntityTypeConfiguration
        :IEntityTypeConfiguration<MaintenanceActivity>
    {
        public void Configure(EntityTypeBuilder<MaintenanceActivity> builder)
        {
            builder.ToTable("MaintenanceActivities");
            builder.HasMany(x=> x.Actuador).HasForeignKey(x=> x.ActuadorId)
        }    
    }
}
