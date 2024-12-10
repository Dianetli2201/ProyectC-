﻿
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Datos_de_Planificación;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using maintenance_calibration_system.DataAccess.FluentConfigurations.Equipments;
using maintenance_calibration_system.DataAccess.FluentConfigurations.MaintenanceActivities;

namespace maintenance_calibration_system.DataAccess.Contexts
{
    public class ApplicationContext : DbContext
    {
        #region Tables

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<MaintenanceActivity> MaintenanceActivities { get; set; }

        public DbSet<Planning> Plannings { get; set; }
        #endregion

        public ApplicationContext() 
        {
        }

        public ApplicationContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        #region Helpers
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion
        public ApplicationContext(DbContextOptions<ApplicationContext> options )
            : base(options) 
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=maintenance_calibration_systemDb.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

    }
}
