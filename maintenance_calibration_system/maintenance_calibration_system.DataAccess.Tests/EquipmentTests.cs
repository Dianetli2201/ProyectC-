using System;
using System.Linq;
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Respositories.Equipments;
using maintenance_calibration_system.DataAccess.Tests.Utilities;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace maintenance_calibration_system.Tests.DataAccess.Repositories.Equipments
{
    [TestClass]
    public class EquipmentRepositoryTests
    {
        private ApplicationContext? _context;
        private IUnitOfWork? _unitOfWork;
        private EquipmentRepository<Sensor>? _sensorRepository;
        private EquipmentRepository<Actuador>? _actuatorRepository;


        [TestInitialize]
        public void Setup()
        {
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectingString());
                
            _unitOfWork = new UnitOfWork(_context); // Inicializa la unidad de trabajo
            _sensorRepository = new EquipmentRepository<Sensor>(_context);
            _actuatorRepository = new EquipmentRepository<Actuador>(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }



        // Pruebas para Sensor
        [TestMethod]
        public void Add_ShouldAddSensor()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR001", someMagnitude, "ManufacturerA", CommunicationProtocol.UA, "PrincipleA");

            // Act
            _sensorRepository.Add(sensor);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Sensor>().FirstOrDefault(s => s.AlphanumericCode == "SENSOR001");
            Assert.IsNotNull(result);
            Assert.AreEqual("ManufacturerA", result.Manufacturer);
        }

        [TestMethod]
        public void GetById_ShouldReturnSensor()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR002", someMagnitude, "ManufacturerB", CommunicationProtocol.UA, "PrincipleB");
            _context.Set<Sensor>().Add(sensor);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

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
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var sensor1 = new Sensor(Guid.NewGuid(), "SENSOR003", someMagnitude, "ManufacturerC", CommunicationProtocol.UA, "PrincipleC");
            var sensor2 = new Sensor(Guid.NewGuid(), "SENSOR004", someMagnitude, "ManufacturerD", CommunicationProtocol.UA, "PrincipleD");
            _context.Set<Sensor>().AddRange(sensor1, sensor2);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = _sensorRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Update_ShouldModifySensor()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR005", someMagnitude, "ManufacturerE", CommunicationProtocol.UA, "PrincipleE");
            _context.Set<Sensor>().Add(sensor);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            sensor.Manufacturer = "UpdatedManufacturer";
            _sensorRepository.Update(sensor);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Sensor>().Find(sensor.Id);
            Assert.AreEqual("UpdatedManufacturer", result.Manufacturer);
        }

        [TestMethod]
        public void Delete_ShouldRemoveSensor()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var sensor = new Sensor(Guid.NewGuid(), "SENSOR006", someMagnitude, "ManufacturerF", CommunicationProtocol.UA, "PrincipleF");
            _context.Set<Sensor>().Add(sensor);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            _sensorRepository.Delete(sensor.Id);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Sensor>().Find(sensor.Id);
            Assert.IsNull(result);
        }

        // Pruebas para Actuador
        [TestMethod]
        public void Add_ShouldAddActuador()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var actuador = new Actuador(Guid.NewGuid(), "ACTUADOR001", someMagnitude, "ManufacturerA", "ControlCode", SignalControl.Analog);

            // Act
            _actuatorRepository.Add(actuador);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Actuador>().FirstOrDefault(a => a.AlphanumericCode == "ACTUADOR001");
            Assert.IsNotNull(result);
            Assert.AreEqual("ManufacturerA", result.Manufacturer);
        }

        [TestMethod]
        public void GetById_ShouldReturnActuador()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var actuador = new Actuador(Guid.NewGuid(), "ACTUADOR002", someMagnitude, "ManufacturerB", "ControlCode", SignalControl.Analog);
            _context.Set<Actuador>().Add(actuador);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = _actuatorRepository.GetById(actuador.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ACTUADOR002", result.AlphanumericCode);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllActuadores()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");

            var actuador1 = new Actuador(Guid.NewGuid(), "ACTUADOR003", someMagnitude, "ManufacturerC", "ControlCode", SignalControl.Analog);
            var actuador2 = new Actuador(Guid.NewGuid(), "ACTUADOR004", someMagnitude, "ManufacturerD", "ControlCode", SignalControl.Analog);


            _context.Set<Actuador>().AddRange(actuador1, actuador2);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = _actuatorRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Update_ShouldModifyActuador()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var actuador = new Actuador(Guid.NewGuid(), "ACTUADOR005", someMagnitude, "ManufacturerE", "ControlCode", SignalControl.Analog);
            _context.Set<Actuador>().Add(actuador);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            actuador.Manufacturer = "UpdatedManufacturer";
            _actuatorRepository.Update(actuador);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Actuador>().Find(actuador.Id);
            Assert.AreEqual("UpdatedManufacturer", result.Manufacturer);
        }

        [TestMethod]
        public void Delete_ShouldRemoveActuador()
        {
            // Arrange
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var actuador = new Actuador(Guid.NewGuid(), "ACTUADOR006", someMagnitude, "ManufacturerF", "ControlCode", SignalControl.Analog);
            _context.Set<Actuador>().Add(actuador);
            _unitOfWork.SaveChanges();

            // Act
            _actuatorRepository.Delete(actuador.Id);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Actuador>().Find(actuador.Id);
            Assert.IsNull(result);
        }
    }
}