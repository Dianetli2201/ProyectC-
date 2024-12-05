using maintenance_calibration_system.Domain.Datos_Historicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.MaintenanceActivities
{
    public class MaintenanceEntityTypeConfiguration
       : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.ToTable("Mantenimientos");
            builder.HasBaseType(typeof(MaintenanceActivity));
            builder.HasMany(x => x.Actuador).HasForeignKey(x => x.SensorId)
        }
    }
}
