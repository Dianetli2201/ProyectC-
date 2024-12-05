using maintenance_calibration_system.Domain.Datos_de_Configuración;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.Equipments
{
    public class ActuadorEntityTypeConfiguration
       : IEntityTypeConfiguration<Actuador>
    {
        public void Configure(EntityTypeBuilder<Actuador> builder)
        {
            builder.ToTable("Actuadores");
            builder.HasBaseType(typeof(Actuador));
        }
    }
}
