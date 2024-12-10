using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using maintenance_calibration_system.Domain.Datos_de_Planificación; // Para Planning
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.DataAccess.Respositories.Plannings;
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Tests.Utilities; // Para PlanningRepository

namespace maintenance_calibration_system.DataAccess.Tests
{
    /// <summary>Clase de pruebas unitarias para el repositorio de Planificaciones.<summary>

    [TestClass]
    public class PlanningTests
    {
        private IPlanningRepository? planningRepository; // Instancia del repositorio a probar
        private IUnitOfWork? unitOfWork; // Instancia del UnitOfWork
        private ApplicationContext? _context;


        public PlanningTests()
        {
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectingString()); // Asigna a _context
           
            unitOfWork = new UnitOfWork(_context); // Inicializa el UnitOfWork
            planningRepository = new PlanningRepository(_context); // Inicializa el repositorio

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }



        [TestMethod]
        public void Add_ShouldAddPlanning()
        {
            // Arrange
            var planning = new Planning { Id = Guid.NewGuid(), EquipmentElement = "Sensor1", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now };

            // Act
            planningRepository.Add(planning);
            unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = planningRepository.GetById(planning.Id);
            Assert.IsNotNull(result); // Verifica que la planificación no sea nula
            Assert.AreEqual(planning.EquipmentElement, result.EquipmentElement); // Verifica que los datos sean correctos
            Assert.AreEqual(planning.Type, result.Type);
            Assert.AreEqual(planning.ExecutionDate.Date, result.ExecutionDate.Date); // Compara solo la fecha
        }



        [TestMethod]
        public void GetById_ShouldReturnPlanning_WhenExists()
        {
            // Arrange
            var planningId = Guid.NewGuid();
            var planning = new Planning { Id = planningId, EquipmentElement = "Sensor1", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now };
            
            planningRepository.Add(planning);
            unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = planningRepository.GetById(planningId);

            // Assert
            Assert.IsNotNull(result); // Verifica que no sea nulo
            Assert.AreEqual(planningId, result.Id); // Verifica que el ID sea correcto
        }



        [TestMethod]
        public void GetAll_ShouldReturnAllPlannings()
        {
            // Arrange
            var planning1 = new Planning { Id = Guid.NewGuid(), EquipmentElement = "Sensor1", Type = PlanningTypes.Calibration, ExecutionDate = DateTime.Now };
            var planning2 = new Planning { Id = Guid.NewGuid(), EquipmentElement = "Sensor2", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now.AddDays(1) };
           
            planningRepository.Add(planning1);
            planningRepository.Add(planning2);
            unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = planningRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count()); // Verifica que se devuelvan dos planificaciones
        }



        [TestMethod]
        public void Update_ShouldUpdateExistingPlanning()
        {
            // Arrange
            var planning = new Planning { Id = Guid.NewGuid(), EquipmentElement = "OldSensor", Type = PlanningTypes.Calibration, ExecutionDate = DateTime.Now };
           
            planningRepository.Add(planning);
            unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            var updatedPlanning = new Planning { Id = planning.Id, EquipmentElement = "NewSensor", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now.AddDays(2) };

            // Act
            planningRepository.Update(updatedPlanning);
            unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = planningRepository.GetById(planning.Id);
            Assert.AreEqual("NewSensor", result.EquipmentElement); // Verifica que se haya actualizado correctamente
            Assert.AreEqual(PlanningTypes.Maintenance, result.Type);
            Assert.AreEqual(updatedPlanning.ExecutionDate.Date, result.ExecutionDate.Date); // Compara solo la fecha sin la hora
        }



        [TestMethod]
        public void Delete_ShouldRemovePlanning_WhenExists()
        {
            // Arrange
            var planningId = Guid.NewGuid();
            var planning = new Planning { Id = planningId, EquipmentElement = "Sensor1", Type = PlanningTypes.Calibration, ExecutionDate = DateTime.Now };
            
            planningRepository.Add(planning);
            unitOfWork.SaveChanges(); 

            // Act
            planningRepository.Delete(planningId);
            unitOfWork.SaveChanges();

            // Assert
            var result = planningRepository.GetById(planningId);
            Assert.IsNull(result); // Verifica que la planificación haya sido eliminada
        }
    }
}