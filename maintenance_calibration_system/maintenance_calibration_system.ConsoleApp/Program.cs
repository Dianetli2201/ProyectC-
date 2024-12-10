using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.FluentConfigurations.Equipments;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Datos_de_Planificación;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;

namespace maintenance_calibration_system.ConsoleApp
{
    /// <summary>
    /// Clase principal del programa que ejecuta las operaciones CRUD en la base de datos SQLite.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Método principal del programa.
        /// </summary>
        static void Main(string[] args)
        {
            /// <summary>
            /// Configurando opciones para el contexto de la base de datos.
            /// </summary>
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlite("Data Source=maintenance_calibration_systemDb.sqlite");

            /// <summary>
            /// Creando una instancia del contexto de la base de datos.
            /// </summary>
            using var appContext = new ApplicationContext(optionsBuilder.Options);

            /// <summary>
            ///Verificando si hay migraciones pendientes y aplicándolas si es necesario.
            /// </summary>
            if (appContext.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine("Aplicando migraciones...");
                appContext.Database.Migrate();
            }
            else
            {
                Console.WriteLine("La base de datos ya está actualizada.");
            }

            /// <summary>
            /// Creando instancias de PhysicalMagnitude, Sensor, Actuator, Calibration y Maintenance.
            /// </summary>
            var temperatureMagnitude = new PhysicalMagnitude("Temperature", "°C");
            var pressureMagnitude = new PhysicalMagnitude("Pressure", "bar");

            var sensor = new Sensor(
                Guid.NewGuid(),
                "SEN123",
                temperatureMagnitude,
                "SensorTech",
                CommunicationProtocol.ModBus,
                "Measures temperature");

            var actuador = new Actuador(
                Guid.NewGuid(),
                "ACT456",
                pressureMagnitude,
                "ActuatorCorp",
                "CTRL001",
                SignalControl.Digital);

            var calibration = new Calibration(
                Guid.NewGuid(),
                "CertAuthority1",
                DateTime.Now,
                "Tech1");

            var maintenance = new Maintenance(
                Guid.NewGuid(),
                DateTime.Now,
                TypeMaintenance.Preventivo,
                "Tech2");

            var calibrationPlanning = new Planning(
                Guid.NewGuid(),
                "sensor",
                PlanningTypes.Calibration,
                DateTime.Now.AddDays(30));

            var maintenancePlanning = new Planning(
                Guid.NewGuid(),
                "actuador",
                PlanningTypes.Maintenance,
                DateTime.Now.AddDays(60));

        
        }
    }

}
