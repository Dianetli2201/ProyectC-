using System;
using System.Collections.Generic;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Datos_de_Configuración;
using maintenance_calibration_system.Data.Repositories;

namespace MantenimientoCalibracionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear instancias de los repositorios
            var sensorRepository = new SensorRepository();
            var actuatorRepository = new ActuatorRepository();
            var calibrationRepository = new CalibrationRepository();
            var maintenanceRepository = new MaintenanceRepository();
            var planningRepository = new PlanningRepository();

            // Ejemplo de cómo agregar un sensor
            var sensor = new Sensor(Guid.NewGuid(), "Sensor1", "Temperatura", "°C", "Modbus", "Sensor de temperatura");
            sensorRepository.Add(sensor);
            Console.WriteLine("Sensor agregado.");

            // Leer todos los sensores
            var sensors = sensorRepository.GetAll();
            Console.WriteLine("Sensores:");
            foreach (var s in sensors)
            {
                Console.WriteLine($"- {s.Name} ({s.Type})");
            }

            // Ejemplo de actualización
            sensor.Description = "Sensor de temperatura actualizado";
            sensorRepository.Update(sensor);
            Console.WriteLine("Sensor actualizado.");

            // Ejemplo de eliminación
            sensorRepository.Delete(sensor.Id);
            Console.WriteLine("Sensor eliminado.");

            // Aquí puedes agregar más lógica para calibraciones, mantenimientos y planificaciones...
        }
    }
}