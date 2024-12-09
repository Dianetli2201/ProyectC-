using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using maintenance_calibration_system.Domain.Datos_Historicos; // Para Calibration
using maintenance_calibration_system.Data.Repositories; // Para CalibrationRepository

namespace maintenance_calibration_system.Tests.Data.Repositories
{
    /// <summary>
    /// Clase de pruebas unitarias para el repositorio de Calibraciones.
    /// </summary>
    [TestClass]
    public class CalibrationRepositoryTests
    {
        private CalibrationRepository _repository; // Instancia del repositorio a probar

        /// <summary>
        /// Configura el entorno para cada prueba unitaria.
        /// Se ejecuta antes de cada método de prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _repository = new CalibrationRepository(); // Crea una nueva instancia del repositorio
        }

        /// <summary>
        /// Prueba que verifica que una calibración se añade correctamente al repositorio.
        /// </summary>
        [TestMethod]
        public void Add_ShouldAddCalibration()
        {
            // Arrange
            var calibration = new Calibration { Id = Guid.NewGuid(), NameCertificateAuthority = "CertAuthority" };

            // Act
            _repository.Add(calibration);

            // Assert
            var result = _repository.GetById(calibration.Id);
            Assert.IsNotNull(result); // Verifica que la calibración no sea nula
            Assert.AreEqual(calibration.NameCertificateAuthority, result.NameCertificateAuthority); // Verifica que los datos sean correctos
        }

        /// <summary>
        /// Prueba que verifica que se devuelve la calibración correcta al buscar por ID.
        /// </summary>
        [TestMethod]
        public void GetById_ShouldReturnCalibration_WhenExists()
        {
            // Arrange
            var calibrationId = Guid.NewGuid();
            var calibration = new Calibration { Id = calibrationId, NameCertificateAuthority = "CertAuthority" };
            _repository.Add(calibration);

            // Act
            var result = _repository.GetById(calibrationId);

            // Assert
            Assert.IsNotNull(result); // Verifica que no sea nulo
            Assert.AreEqual(calibrationId, result.Id); // Verifica que el ID sea correcto
        }

        /// <summary>
        /// Prueba que verifica que se devuelven todas las calibraciones del repositorio.
        /// </summary>
        [TestMethod]
        public void GetAll_ShouldReturnAllCalibrations()
        {
            // Arrange
            var calibration1 = new Calibration { Id = Guid.NewGuid(), NameCertificateAuthority = "CertAuthority1" };
            var calibration2 = new Calibration { Id = Guid.NewGuid(), NameCertificateAuthority = "CertAuthority2" };
            _repository.Add(calibration1);
            _repository.Add(calibration2);

            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count()); // Verifica que se devuelvan dos calibraciones
        }

        /// <summary>
        /// Prueba que verifica que una calibración existente se actualiza correctamente en el repositorio.
        /// </summary>
        [TestMethod]
        public void Update_ShouldUpdateExistingCalibration()
        {
            // Arrange
            var calibration = new Calibration { Id = Guid.NewGuid(), NameCertificateAuthority = "OldCertAuthority" };
            _repository.Add(calibration);

            var updatedCalibration = new Calibration { Id = calibration.Id, NameCertificateAuthority = "NewCertAuthority" };

            // Act
            _repository.Update(updatedCalibration);

            // Assert
            var result = _repository.GetById(calibration.Id);
            Assert.AreEqual("NewCertAuthority", result.NameCertificateAuthority); // Verifica que se haya actualizado correctamente
        }

        /// <summary>
        /// Prueba que verifica que una calibración se elimina correctamente del repositorio.
        /// </summary>
        [TestMethod]
        public void Delete_ShouldRemoveCalibration_WhenExists()
        {
            // Arrange
            var calibrationId = Guid.NewGuid();
            var calibration = new Calibration { Id = calibrationId, NameCertificateAuthority = "CertAuthority" };
            _repository.Add(calibration);

            // Act
            _repository.Delete(calibrationId);

            // Assert
            var result = _repository.GetById(calibrationId);
            Assert.IsNull(result); // Verifica que la calibración haya sido eliminada
        }
    }
}