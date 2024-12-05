using maintenance_calibration_system.DataAccess.FluentConfigurations.Common;
using maintenance_calibration_system.Domain;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.Equipments
{
    public class EquipmentEntityTypeConfigurationBase
       : EntityTypeConfigurationBase<Equipment>    
    {
        public override void Configuration(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipments");
            base.Configure(builder);
            builder.OwnsOne(x => x.PhysicalMagnitude);
        }
    }
}
