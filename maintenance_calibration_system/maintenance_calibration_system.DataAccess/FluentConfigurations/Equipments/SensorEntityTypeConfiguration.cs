using maintenance_calibration_system.Domain.Datos_Historicos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Datos_de_Configuración;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.Equipments
{
    public class SensorEntityTypeConfiguration
        : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {

            builder.ToTable("Sensors");
            builder.HasBaseType(typeof(Equipment));

            //Configurando propiedades
            builder.Property(s => s.Protocol).IsRequired(); 
            builder.Property(s => s.PrincipleOperation).IsRequired();
            builder.Property(s => s.Calibrated).IsRequired();

       }
    }
}
