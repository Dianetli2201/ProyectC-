using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using maintenance_calibration_system.DataAccess.Contexts; // Para ApplicationContext
using maintenance_calibration_system.Domain.Datos_de_Configuración; // Para Sensor
using maintenance_calibration_system.DataAccess.Repositories;

namespace maintenance_calibration_system.DataAccess.Tests
{
    /// <summary>
    /// Clase de pruebas unitarias para el repositorio de Sensores.
    /// </summary>
    [TestClass]
    public class SensorRepositoryTests
    {
        private Mock<ApplicationContext> _mockContext; // Simulación del contexto de la base de datos
        private SensorRepository _repository; // Instancia del repositorio a probar

        /// <summary>
        /// Configura el entorno para cada prueba unitaria.
        /// Se ejecuta antes de cada método de prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _mockContext = new Mock<ApplicationContext>(); // Inicializa el contexto simulado
            _repository = new SensorRepository(_mockContext.Object); // Crea una instancia del repositorio
        }

        /// <summary>
        /// Prueba que verifica que un sensor se añade correctamente al repositorio.
        /// </summary>
        [TestMethod]
        public void Add_ShouldAddSensor()
        {
            // Arrange
            var sensor = new Sensor { Id = Guid.NewGuid(), /* Inicializa otras propiedades */ };

            // Act
            _repository.Add(sensor);

            // Assert
            _mockContext.Verify(c => c.Set<Sensor>().Add(sensor), Times.Once); // Verifica que se llamó al método Add
            _mockContext.Verify(c => c.SaveChanges(), Times.Once); // Verifica que se llamó a SaveChanges
        }

        /// <summary>
        /// Prueba que verifica que se devuelve el sensor correcto al buscar por ID.
        /// </summary>
        [TestMethod]
        public void GetById_ShouldReturnSensor_WhenExists()
        {
            // Arrange
            var sensorId = Guid.NewGuid();
            var sensor = new Sensor { Id = sensorId };

            // Simula el comportamiento del contexto para Find.
            _mockContext.Setup(c => c.Set<Sensor>().Find(sensorId)).Returns(sensor);

            // Act
            var result = _repository.GetById(sensorId);

            // Assert
            Assert.IsNotNull(result); // Verifica que no sea nulo
            Assert.AreEqual(sensorId, result.Id); // Verifica que el ID sea correcto
        }

        /// <summary>
        /// Prueba que verifica que se devuelven todos los sensores del repositorio.
        /// </summary>
        [TestMethod]
        public void GetAll_ShouldReturnAllSensors()
        {
            // Arrange
            var sensors = new List<Sensor>
            {
                new Sensor { Id = Guid.NewGuid() },
                new Sensor { Id = Guid.NewGuid() }
            };

            // Simula el comportamiento del contexto para ToList.
            _mockContext.Setup(c => c.Set<Sensor>()).Returns(sensors.AsQueryable());

            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count()); // Verifica que se devuelvan dos sensores
        }

        /// <summary>
        /// Prueba que verifica que un sensor existente se actualiza correctamente en el repositorio.
        /// </summary>
        [TestMethod]
        public void Update_ShouldUpdateExistingSensor()
        {
            // Arrange
            var sensor = new Sensor { Id = Guid.NewGuid(), /* Inicializa otras propiedades */ };

            // Act
            _repository.Update(sensor);

            // Assert
            _mockContext.Verify(c => c.Set<Sensor>().Update(sensor), Times.Once); // Verifica que se llamó a Update
            _mockContext.Verify(c => c.SaveChanges(), Times.Once); // Verifica que se llamó a SaveChanges
        }

        /// <summary>
        /// Prueba que verifica que un sensor se elimina correctamente del repositorio.
        /// </summary>
        [TestMethod]
        public void Delete_ShouldRemoveSensor_WhenExists()
        {
            // Arrange
            var sensorId = Guid.NewGuid();
            var sensor = new Sensor { Id = sensorId };

            // Simula el comportamiento del contexto para Find.
            _mockContext.Setup(c => c.Set<Sensor>().Find(sensorId)).Returns(sensor);

            // Act
            _repository.Delete(sensorId);

            // Assert
            _mockContext.Verify(c => c.Set<Sensor>().Remove(sensor), Times.Once); // Verifica que se llamó a Remove
            _mockContext.Verify(c => c.SaveChanges(), Times.Once); // Verifica que se llamó a SaveChanges
        }
    }
}
