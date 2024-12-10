using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using maintenance_calibration_system.DataAccess.Contexts; // Para ApplicationContext
using maintenance_calibration_system.Domain.Datos_de_Configuración; // Para Actuador
using maintenance_calibration_system.Infrastructure.Repositories;

namespace maintenance_calibration_system.DataAccess.Tests
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias para el repositorio de Actuadores.
    /// </summary>
    [TestClass]
    public class ActuadorTests
    {
        private Mock<ApplicationContext> _mockContext;
        private ActuadorRepository _repository;

        /// <summary>
        /// Configura el entorno para cada prueba unitaria.
        /// Se ejecuta antes de cada método de prueba.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _mockContext = new Mock<ApplicationContext>();
            _repository = new ActuadorRepository(_mockContext.Object);
        }

        /// <summary>
        /// Prueba que verifica que un actuador se añade correctamente al repositorio.
        /// </summary>
        [TestMethod]
        public void Add_ShouldAddActuador()
        {
            var actuador = new Actuador { Id = Guid.NewGuid(), /* Inicializa otras propiedades */ };

            _repository.Add(actuador);

            // Verifica que se haya llamado al método Add en el contexto.
            _mockContext.Verify(c => c.Set<Actuador>().Add(actuador), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        /// <summary>
        /// Prueba que verifica que se devuelve el actuador correcto al buscar por ID.
        /// </summary>
        [TestMethod]
        public void GetById_ShouldReturnActuador_WhenExists()
        {
            var actuadorId = Guid.NewGuid();
            var actuador = new Actuador { Id = actuadorId };

            // Simula el comportamiento del contexto para Find.
            _mockContext.Setup(c => c.Set<Actuador>().Find(actuadorId)).Returns(actuador);

            var result = _repository.GetById(actuadorId);

            Assert.IsNotNull(result);
            Assert.AreEqual(actuadorId, result.Id);
        }

        /// <summary>
        /// Prueba que verifica que se devuelven todos los actuadores del repositorio.
        /// </summary>
        [TestMethod]
        public void GetAll_ShouldReturnAllActuadores()
        {
            var actuadores = new List<Actuador>
            {
                new Actuador { Id = Guid.NewGuid() },
                new Actuador { Id = Guid.NewGuid() }
            }.AsQueryable();

            // Simula el comportamiento del contexto para ToList.
            _mockContext.Setup(c => c.Set<Actuador>()).Returns(actuadores.Provider);

            var result = _repository.GetAll().ToList();

            Assert.AreEqual(2, result.Count);
        }

        /// <summary>
        /// Prueba que verifica que un actuador existente se actualiza correctamente en el repositorio.
        /// </summary>
        [TestMethod]
        public void Update_ShouldUpdateExistingActuador()
        {
            var actuador = new Actuador { Id = Guid.NewGuid(), /* Inicializa otras propiedades */ };

            _repository.Update(actuador);

            // Verifica que se haya llamado al método Update en el contexto.
            _mockContext.Verify(c => c.Set<Actuador>().Update(actuador), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        /// <summary>
        /// Prueba que verifica que un actuador se elimina correctamente del repositorio.
        /// </summary>
        [TestMethod]
        public void Delete_ShouldRemoveActuador_WhenExists()
        {
            var actuadorId = Guid.NewGuid();
            var actuador = new Actuador { Id = actuadorId };

            // Simula el comportamiento del contexto para Find.
            _mockContext.Setup(c => c.Set<Actuador>().Find(actuadorId)).Returns(actuador);

            _repository.Delete(actuadorId);

            // Verifica que se haya llamado al método Remove en el contexto.
            _mockContext.Verify(c => c.Set<Actuador>().Remove(actuador), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
