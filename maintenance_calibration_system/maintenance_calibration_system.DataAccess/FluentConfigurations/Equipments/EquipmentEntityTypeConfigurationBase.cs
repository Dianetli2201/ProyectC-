using maintenance_calibration_system.DataAccess.FluentConfigurations.Common;
using maintenance_calibration_system.Domain.ValueObjects;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Datos_de_Configuración;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.Equipments
{
    public class EquipmentEntityTypeConfigurationBase
       : EntityTypeConfigurationBase<Equipment>    
    {
        public override void Configure(EntityTypeBuilder<Equipment> builder) //Configurando tabla para los equipamientos
        {
            builder.ToTable("Equipments");
            base.Configure(builder);


            //Configurando propiedades
            builder.OwnsOne(e => e.Magnitude, m =>
            {
                m.Property(p => p.Name).IsRequired();
                m.Property(p => p.UnitofMagnitude).IsRequired();
            });

            builder.Property(e=> e.Manufacturer).IsRequired();

            builder.Property(e => e.AlphanumericCode).IsRequired();

            // Configuración de la discriminación de herencia
            builder.HasDiscriminator<string>("EquipmentType")
                .HasValue<Sensor>("Sensor") 
                .HasValue<Actuador>("Actuator");
        }
    }
}
