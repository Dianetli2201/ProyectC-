using maintenance_calibration_system.DataAccess.FluentConfigurations.Common;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.MaintenanceActivities
{
    /// <summary>
    /// Configuración base para la entidad MaintenanceActivity.
    /// </summary>
    public class MaintenanceActivityEntityTypeConfigurationBase : EntityTypeConfigurationBase<MaintenanceActivity>
    {
        /// <summary>
        /// Configura la entidad MaintenanceActivity.
        /// </summary>
        /// <param name="builder">Constructor de la entidad.</param>
        public override void Configure(EntityTypeBuilder<MaintenanceActivity> builder)
        {
            builder.ToTable("MaintenanceActivities"); // Mapea a la tabla "MaintenanceActivities"
            base.Configure(builder);

            // Configurando propiedades
            builder.Property(x => x.NameTechnician).IsRequired();
            builder.Property(x => x.DateActivity).IsRequired();

            // Configuración de la discriminación de herencia
            builder.HasDiscriminator<string>("ActivityType")
                .HasValue<Calibration>("Calibration")
                .HasValue<Maintenance>("Maintenance");
        }
    }

}
