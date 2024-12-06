using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.Domain.Datos_de_Configuración;
using maintenance_calibration_system.Domain.Datos_de_Planificación;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;

namespace maintenance_calibration_system.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Configurando opciones para el contexto
            ApplicationContext appContext = new ApplicationContext("Data Source=maintenance_calibration_systemDb.sqlite");

            //Verificando si la BD no existe
            if (!appContext.Database.CanConnect())
            {
                //Migrando base de datos. Este paso general la BD con las tablas configuradas en su migración
                appContext.Database.Migrate();
            }

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
                SignalControl.Digital ); 

            var calibration = new Calibration(
                    Guid.NewGuid(),
                    "CertAuthority1",
                    DateTime.Now, 
                    "Tech1" ); 

            var maintenance = new Maintenance(
                Guid.NewGuid(),
                DateTime.Now,
                TypeMaintenance.Preventivo,
                "Tech2"); 

            calibration.CalibratedSensors.Add(sensor); 
            maintenance.MaintenanceActuador.Add(actuador); 

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

            appContext.Equipments.Add(sensor);
            appContext.Equipments.Add(actuador);
           
            appContext.MaintenanceActivities.Add(calibration);
            appContext.MaintenanceActivities.Add(maintenance);
           
            appContext.Plannings.Add(calibrationPlanning);
            appContext.Plannings.Add(maintenancePlanning);

            appContext.SaveChanges();

            //Operacion de lectura de la base de datos
            Sensor? sensor1 = appContext
                .Set<Sensor>()
                .FirstOrDefault(v => v.Id == calibrationPlanning.EquipmentId);

            //Operacion de actualizacion de la base de datos
            actuador.Magnitude = ("Presion", "Pascal");

            appContext.Equipments.Update(actuador);
            appContext.SaveChanges();

            //Operacion Eliminar 
            appContext.Equipments.Remove(sensor1);
            appContext.SaveChanges();
        }
    }
}
