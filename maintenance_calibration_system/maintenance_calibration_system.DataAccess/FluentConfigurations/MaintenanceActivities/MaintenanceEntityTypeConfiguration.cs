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

            //Configurando propiedades
            builder.Property(m => m.TypeMaintenance).IsRequired();

            // Configuración de la relación muchos a muchos con Actuator
            builder.HasMany(m => m.MaintenanceActuador) 
                .WithMany() 
                .UsingEntity<Dictionary<string, object>>( 
                    "MaintenanceActuator", 
                j => j.HasOne<Actuador>().WithMany().HasForeignKey("ActuatorId"), 
                j => j.HasOne<Maintenance>().WithMany().HasForeignKey("MaintenanceId"),
                j => { j.HasKey("MaintenanceId", "ActuatorId"); 
                });
       
        }
    }
}