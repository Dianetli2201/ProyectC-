using maintenance_calibration_system.Domain.Datos_Historicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Datos_de_Configuración;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.MaintenanceActivities
{
    public class MaintenanceEntityTypeConfiguration
       : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.ToTable("Mantenimientos");
            builder.HasBaseType(typeof(MaintenanceActivity));
            builder.Property(x => x.TypeMaintenance).IsRequired();

            // Configurar relación muchos a muchos entre Maintenance y Actuator
            builder.HasMany(x => x.MaintenanceActuador)
                 .WithMany()
                 .UsingEntity<Dictionary<string, object>>(
                "MaintenanceActuators",
                j => j.HasOne<Actuador>().WithMany().HasForeignKey("ActuadorId"),
                j => j.HasOne<Maintenance>().WithMany().HasForeignKey("MaintenanceId"),
                j => { j.HasKey("MaintenanceId", "ActuatorId"); });
        }
    }
}
