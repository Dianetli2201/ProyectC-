using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Respositories.Equipments;
using maintenance_calibration_system.DataAccess.Respositories.Plannings;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Datos_de_Planificación;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace maintenance_calibration_system.ConsoleApp
{
    /// <summary>Clase principal del programa que ejecuta las operaciones CRUD en la base de datos SQLite.</summary>
    internal class Program
    {
        /// <summary>Método principal del programa.</summary>
        static void Main(string[] args)
        {
            // Configurando opciones para el contexto de la base de datos.
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlite("Data Source=maintenance_calibration_systemDb.sqlite");

            // Creando una instancia del contexto de la base de datos.
            using var appContext = new ApplicationContext(optionsBuilder.Options);

            // Verificando si hay migraciones pendientes y aplicándolas si es necesario.
            if (appContext.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine("Aplicando migraciones...");
                appContext.Database.Migrate();
            }
            else
            {
                Console.WriteLine("La base de datos ya está actualizada.");
            }

            // Inicializando el UnitOfWork y los repositorios
            var unitOfWork = new UnitOfWork(appContext);
            var sensorRepository = new EquipmentRepository<Sensor>(appContext);
            var actuatorRepository = new EquipmentRepository<Actuador>(appContext);
            var planningRepository = new PlanningRepository(appContext);

            // Ejemplo de uso del repositorio de sensores
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR001", new PhysicalMagnitude("Temperature", "Celsius"), "ManufacturerA", CommunicationProtocol.UA, "PrincipleA");
            sensorRepository.Add(sensor);
            unitOfWork.SaveChanges();
            Console.WriteLine("Sensor añadido: " + sensor.AlphanumericCode);

            // Ejemplo de uso del repositorio de actuadores
            var actuador = new Actuador(Guid.NewGuid(), "ACTUADOR001", new PhysicalMagnitude("Temperature", "Celsius"), "ManufacturerA", "ControlCode", SignalControl.Analog);
            actuatorRepository.Add(actuador);
            unitOfWork.SaveChanges();
            Console.WriteLine("Actuador añadido: " + actuador.AlphanumericCode);

            // Ejemplo de uso del repositorio de planificaciones
            var planning = new Planning { Id = Guid.NewGuid(), EquipmentElement = "Sensor1", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now };
            planningRepository.Add(planning);
            unitOfWork.SaveChanges();
            Console.WriteLine("Planificación añadida: " + planning.EquipmentElement);

            // Obtener y mostrar todos los sensores
            var allSensors = sensorRepository.GetAll();
            Console.WriteLine("Todos los sensores:");
            foreach (var s in allSensors)
            {
                Console.WriteLine($"- {s.AlphanumericCode} ({s.Manufacturer})");
            }

            // Obtener y mostrar todas las planificaciones
            var allPlannings = planningRepository.GetAll();
            Console.WriteLine("Todas las planificaciones:");
            foreach (var p in allPlannings)
            {
                Console.WriteLine($"- {p.EquipmentElement} ({p.Type})");
            }

            // Actualizar un sensor
            sensor.Manufacturer = "UpdatedManufacturer";
            sensorRepository.Update(sensor);
            unitOfWork.SaveChanges();
            Console.WriteLine("Sensor actualizado: " + sensor.AlphanumericCode);

            // Eliminar una planificación
            planningRepository.Delete(planning.Id);
            unitOfWork.SaveChanges();
            Console.WriteLine("Planificación eliminada: " + planning.EquipmentElement);
        }
    }
}




