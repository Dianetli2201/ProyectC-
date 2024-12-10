using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using maintenance_calibration_system.Domain.Datos_de_Planificación; // Para Planning
using maintenance_calibration_system.Data.Repositories;
using maintenance_calibration_system.Domain.Types; // Para PlanningRepository

namespace maintenance_calibration_system.DataAccess.Tests
{
    /// <summary>
    /// Clase de pruebas unitarias para el repositorio de Planificaciones.
    /// </summary>
    [TestClass]
    public class PlanningTests
    {
        private IPlanningRepository? planningRepository; // Instancia del repositorio a probar

        /// <summary>
        /// Configura el entorno para cada prueba unitaria.
        /// Se ejecuta antes de cada método de prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            planningRepository = new PlanningRepository(); // Crea una nueva instancia del repositorio
        }

        /// <summary>
        /// Prueba que verifica que una planificación se añade correctamente al repositorio.
        /// </summary>
        [TestMethod]
        public void Add_ShouldAddPlanning()
        {
            // Arrange
            var planning = new Planning { Id = Guid.NewGuid(), EquipmentElement = "Sensor1", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now };

            // Act
            planningRepository.Add(planning);

            // Assert
            var result = planningRepository.GetById(planning.Id);
            Assert.IsNotNull(result); // Verifica que la planificación no sea nula
            Assert.AreEqual(planning.EquipmentElement, result.EquipmentElement); // Verifica que los datos sean correctos
            Assert.AreEqual(planning.Type, result.Type);
            Assert.AreEqual(planning.ExecutionDate, result.ExecutionDate);
        }

        /// <summary>
        /// Prueba que verifica que se devuelve la planificación correcta al buscar por ID.
        /// </summary>
        [TestMethod]
        public void GetById_ShouldReturnPlanning_WhenExists()
        {
            // Arrange
            var planningId = Guid.NewGuid();
            var planning = new Planning { Id = planningId, EquipmentElement = "Sensor1", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now };
            planningRepository.Add(planning);

            // Act
            var result = planningRepository.GetById(planningId);

            // Assert
            Assert.IsNotNull(result); // Verifica que no sea nulo
            Assert.AreEqual(planningId, result.Id); // Verifica que el ID sea correcto
        }

        /// <summary>
        /// Prueba que verifica que se devuelven todas las planificaciones del repositorio.
        /// </summary>
        [TestMethod]
        public void GetAll_ShouldReturnAllPlannings()
        {
            // Arrange
            var planning1 = new Planning { Id = Guid.NewGuid(), EquipmentElement = "Sensor1", Type = PlanningTypes.Calibration, ExecutionDate = DateTime.Now };
            var planning2 = new Planning { Id = Guid.NewGuid(), EquipmentElement = "Sensor2", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now.AddDays(1) };
            planningRepository.Add(planning1);
            planningRepository.Add(planning2);

            // Act
            var result = planningRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count()); // Verifica que se devuelvan dos planificaciones
        }

        /// <summary>
        /// Prueba que verifica que una planificación existente se actualiza correctamente en el repositorio.
        /// </summary>
        [TestMethod]
        public void Update_ShouldUpdateExistingPlanning()
        {
            // Arrange
            var planning = new Planning { Id = Guid.NewGuid(), EquipmentElement = "OldSensor", Type = PlanningTypes.Calibration, ExecutionDate = DateTime.Now };
            planningRepository.Add(planning);

            var updatedPlanning = new Planning { Id = planning.Id, EquipmentElement = "NewSensor", Type = PlanningTypes.Maintenance, ExecutionDate = DateTime.Now.AddDays(2) };

            // Act
            planningRepository.Update(updatedPlanning);

            // Assert
            var result = planningRepository.GetById(planning.Id);
            Assert.AreEqual("NewSensor", result.EquipmentElement); // Verifica que se haya actualizado correctamente
            Assert.AreEqual(PlanningTypes.Maintenance, result.Type);
            Assert.AreEqual(DateTime.Now.AddDays(2).Date, result.ExecutionDate.Date); // Compara solo la fecha sin la hora
        }

        /// <summary>
        /// Prueba qu   e verifica que una planificación se elimina correctamente del repositorio.
        /// </summary>
        [TestMethod]
        public void Delete_ShouldRemovePlanning_WhenExists()
        {
            // Arrange
            var planningId = Guid.NewGuid();
            var planning = new Planning { Id = planningId, EquipmentElement = "Sensor1", Type = PlanningType.Regular, ExecutionDate = DateTime.Now };
            planningRepository.Add(planning);

            // Act
            planningRepository.Delete(planningId);

            // Assert
            var result = planningRepository.GetById(planningId);
            Assert.IsNull(result); // Verifica que la planificación haya sido eliminada
        }
    }
}