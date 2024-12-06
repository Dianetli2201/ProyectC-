using maintenance_calibration_system.Domain.Datos_de_Planificación;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.Planning
{
    public class PlanningEntityTypeConfiguration
       : EntityTypeConfiguration<Planning>
    {
        public override void Configure(EntityTypeBuilder<Planning> builder)
        {
            builder.ToTable("Planes");
            builder.HasKey(ma => ma.Id);
            builder.Property(x => x.EquipmentElement).IsRequired();
            builder.Property(x => x.ExecutionDate).IsRequired();
        }
    }
}
