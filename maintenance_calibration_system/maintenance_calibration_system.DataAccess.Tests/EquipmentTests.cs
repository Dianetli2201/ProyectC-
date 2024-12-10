using System;
using System.Linq;
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Respositories.Equipments;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace maintenance_calibration_system.DataAccess.Tests
{
    [TestClass]
    public class EquipmentRepositoryTests
    {
        private ApplicationContext? _context;
        private EquipmentRepository<Sensor>? _sensorRepository;
        private EquipmentRepository<Actuador>? _actuatorRepository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationContext(options);
            _sensorRepository = new SensorRepository(_context);
            _actuatorRepository = new ActuadorRepository(_context);
        }

        // Pruebas para Sensor
        [TestMethod]
        public void Add_ShouldAddSensor()
        {
            // Arrange
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR001", PhysicalMagnitude.SomeMagnitude, "ManufacturerA", CommunicationProtocol.SomeProtocol, "PrincipleA");

            // Act
            _sensorRepository.Add(sensor);

            // Assert
            var result = _context.Set<Sensor>().FirstOrDefault(s => s.AlphanumericCode == "SENSOR001");
            Assert.IsNotNull(result);
            Assert.AreEqual("ManufacturerA", result.Manufacturer);
        }

        [TestMethod]
        public void GetById_ShouldReturnSensor()
        {
            // Arrange
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR002", PhysicalMagnitude.SomeMagnitude, "ManufacturerB", CommunicationProtocol.SomeProtocol, "PrincipleB");
            _context.Set<Sensor>().Add(sensor);
            _context.SaveChanges();

            // Act
            var result = _sensorRepository.GetById(sensor.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("SENSOR002", result.AlphanumericCode);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllSensors()
        {
            // Arrange
            var sensor1 = new Sensor(Guid.NewGuid(), "SENSOR003", PhysicalMagnitude.SomeMagnitude, "ManufacturerC", CommunicationProtocol.SomeProtocol, "PrincipleC");
            var sensor2 = new Sensor(Guid.NewGuid(), "SENSOR004", PhysicalMagnitude.SomeMagnitude, "ManufacturerD", CommunicationProtocol.SomeProtocol, "PrincipleD");
            _context.Set<Sensor>().AddRange(sensor1, sensor2);
            _context.SaveChanges();

            // Act
            var result = _sensorRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Update_ShouldModifySensor()
        {
            // Arrange
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR005", PhysicalMagnitude.SomeMagnitude, "ManufacturerE", CommunicationProtocol.SomeProtocol, "PrincipleE");
            _context.Set<Sensor>().Add(sensor);
            _context.SaveChanges();

            // Act
            sensor.Manufacturer = "UpdatedManufacturer";
            _sensorRepository.Update(sensor);

            // Assert
            var result = _context.Set<Sensor>().Find(sensor.Id);
            Assert.AreEqual("UpdatedManufacturer", result.Manufacturer);
        }

        [TestMethod]
        public void Delete_ShouldRemoveSensor()
        {
            // Arrange
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR006", PhysicalMagnitude.SomeMagnitude, "ManufacturerF", CommunicationProtocol.SomeProtocol, "PrincipleF");
            _context.Set<Sensor>().Add(sensor);
            _context.SaveChanges();

            // Act
            _sensorRepository.Delete(sensor.Id);

            // Assert
            var result = _context.Set<Sensor>().Find(sensor.Id);
            Assert.IsNull(result);
        }

        // Pruebas para Actuador
        [TestMethod]
        public void Add_ShouldAddActuador()
        {
            // Arrange
            var actuador = new Actuador(Guid.NewGuid(), "ACTUADOR001", PhysicalMagnitude.SomeMagnitud, "ManufacturerA", "ControlCode", SignalControl.SomeSignal);

            // Act
            _actuatorRepository.Add(actuador);

            // Assert
            var result = _context.Set<Actuador>().FirstOrDefault(a => a.AlphanumericCode == "ACTUADOR001");
            Assert.IsNotNull(result);
            Assert.AreEqual("ManufacturerA", result.Manufacturer);
        }

        [TestMethod]
        public void GetById_ShouldReturnActuador()
        {
            // Arrange
            var actuador = new Actuador(Guid.NewGuid(), "ACTUADOR002", PhysicalMagnitude.SomeMagnitude, "ManufacturerB", "ControlCode", SignalControl.Some
