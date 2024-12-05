using maintenance_calibration_system.Domain.Datos_Historicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using maintenance_calibration_system.Domain.Datos_de_Configuracion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.MaintenanceActivities
{
    public class CalibrationEntityTypeConfiguration
       : IEntityTypeConfiguration<Calibration>
    {
        public void Configure(EntityTypeBuilder<Calibration> builder)
        {
            builder.ToTable("Calibraciones");
            builder.HasBaseType(typeof(MaintenanceActivity));
            builder.HasMany(x => x.Sensor).HasForeignKey(x => x.SensorId)
        }
    }
}
