using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using maintenance_calibration_system.Domain.Datos_Historicos; // Para Maintenance
using maintenance_calibration_system.Data.Repositories;
using maintenance_calibration_system.Domain.Types; // Para MaintenanceRepository

namespace maintenance_calibration_system.DataAccess.Tests
{
    /// <summary>
    /// Clase de pruebas unitarias para el repositorio de Mantenimientos.
    /// </summary>
    [TestClass]
    public class MaintenanceRepositoryTests
    {
        private MaintenanceRepository? maintenanceRepository; // Instancia del repositorio a probar

        /// <summary>
        /// Configura el entorno para cada prueba unitaria.
        /// Se ejecuta antes de cada método de prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            maintenanceRepository = new MaintenanceRepository(); // Crea una nueva instancia del repositorio
        }

        /// <summary>
        /// Prueba que verifica que un mantenimiento se añade correctamente al repositorio.
        /// </summary>
        [TestMethod]
        public void Add_ShouldAddMaintenance()
        {
            // Arrange
            var maintenance = new Maintenance { Id = Guid.NewGuid(), TypeMaintenance = "Regular" };

            // Act
            maintenanceRepository.Add(maintenance);

            // Assert
            var result = maintenanceRepository.GetById(maintenance.Id);
            Assert.IsNotNull(result); // Verifica que el mantenimiento no sea nulo
            Assert.AreEqual(maintenance.TypeMaintenance, result.TypeMaintenance); // Verifica que los datos sean correctos
        }

        /// <summary>
        /// Prueba que verifica que se devuelve el mantenimiento correcto al buscar por ID.
        /// </summary>
        [TestMethod]
        public void GetById_ShouldReturnMaintenance_WhenExists()
        {
            // Arrange
            var maintenanceId = Guid.NewGuid();
            var maintenance = new Maintenance { Id = maintenanceId, TypeMaintenance = "Regular" };
            maintenanceRepository.Add(maintenance);

            // Act
            var result = maintenanceRepository.GetById(maintenanceId);

            // Assert
            Assert.IsNotNull(result); // Verifica que no sea nulo
            Assert.AreEqual(maintenanceId, result.Id); // Verifica que el ID sea correcto
        }

        /// <summary>
        /// Prueba que verifica que se devuelven todos los mantenimientos del repositorio.
        /// </summary>
        [TestMethod]
        public void GetAll_ShouldReturnAllMaintenances()
        {
            // Arrange
            var maintenance1 = new Maintenance { Id = Guid.NewGuid(), TypeMaintenance = "Regular" };
            var maintenance2 = new Maintenance { Id = Guid.NewGuid(), TypeMaintenance = "Emergency" };
            maintenanceRepository.Add(maintenance1);
            maintenanceRepository.Add(maintenance2);

            // Act
            var result = maintenanceRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count()); // Verifica que se devuelvan dos mantenimientos
        }

        /// <summary>
        /// Prueba que verifica que un mantenimiento existente se actualiza correctamente en el repositorio.
        /// </summary>
        [TestMethod]
        public void Update_ShouldUpdateExistingMaintenance()
        {
            // Arrange
            var maintenance = new Maintenance { Id = Guid.NewGuid(), TypeMaintenance.Preventivo };
            maintenanceRepository.Add(maintenance);

            var updatedMaintenance = new Maintenance { Id = maintenance.Id, TypeMaintenance = "NewType" };

            // Act
            maintenanceRepository.Update(updatedMaintenance);

            // Assert
            var result = maintenanceRepository.GetById(maintenance.Id);
            Assert.AreEqual("NewType", result.TypeMaintenance); // Verifica que se haya actualizado correctamente
        }

        /// <summary>
        /// Prueba que verifica que un mantenimiento se elimina correctamente del repositorio.
        /// </summary>
        [TestMethod]
        public void Delete_ShouldRemoveMaintenance_WhenExists()
        {
            // Arrange
            var maintenanceId = Guid.NewGuid();
            var maintenance = new Maintenance { Id = maintenanceId,TypeMaintenance.Preventivo};
            maintenanceRepository.Add(maintenance);

            // Act
            maintenanceRepository.Delete(maintenanceId);

            // Assert
            var result = maintenanceRepository.GetById(maintenanceId);
            Assert.IsNull(result); // Verifica que el mantenimiento haya sido eliminado
        }
    }
}