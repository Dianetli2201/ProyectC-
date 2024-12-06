using maintenance_calibration_system.Domain.Datos_de_Planificación;
using maintenance_calibration_system.Domain.Datos_Historicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.DataAccess.FluentConfigurations.Plannings
{
    public class PlanningEntityTypeConfiguration
       : IEntityTypeConfiguration<Planning>
    {
        public  void Configure(EntityTypeBuilder<Planning> builder)
        {
            builder.ToTable("Planes");
            builder.Property(x => x.EquipmentElement).IsRequired();
            builder.Property(x => x.ExecutionDate).IsRequired();

            // Relación uno a muchos con Calibration
            builder.HasMany<Calibration>() 
                .WithOne() 
                .HasForeignKey("PlanningId")
                .OnDelete(DeleteBehavior.Cascade); //En caso de eliminar una planificación, se eliminan los mantenimientos asociados a esta

            // Relación uno a muchos con Maintenance                                                                                                                             
            builder.HasMany<Maintenance>()
                .WithOne()
                .HasForeignKey("PlanningId")
                .OnDelete(DeleteBehavior.Cascade); //En caso de eliminar una planificación, se eliminan los mantenimientos asociados a esta
        }
    }
}
