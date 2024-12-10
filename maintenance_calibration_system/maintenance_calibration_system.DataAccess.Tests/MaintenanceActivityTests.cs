using Microsoft.VisualStudio.TestTools.UnitTesting;
using maintenance_calibration_system.Domain.Datos_Historicos;
using System;
using System.Collections.Generic;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.ValueObjects;
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Tests.Utilities;
using maintenance_calibration_system.DataAccess.Respositories.MaintenanceActivitiy;
using maintenance_calibration_system.DataAccess.Respositories.Equipments;
namespace maintenance_calibration_system.Tests
{


    [TestClass]
    public class MaintenanceActivityTests
    {
        private ApplicationContext? _context;
        private IUnitOfWork _unitOfWork;
        private MaintenanceActivityRepository<Maintenance>? _maintenanceRepository;
        private MaintenanceActivityRepository<Calibration>? _calibrationRepository;

        public MaintenanceActivityTests()
        {
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectingString());

            _unitOfWork = new UnitOfWork(_context);
            _maintenanceRepository = new MaintenanceActivityRepository<Maintenance>(_context);
            _calibrationRepository = new MaintenanceActivityRepository<Calibration>(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Calibration_Creation_ShouldInitializeProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "John Doe";
            var nameCertificateAuthority = "Cert Authority";

            // Act
            var calibration = new Calibration(id, nameCertificateAuthority, dateActivity, nameTechnician);

            // Assert
            Assert.AreEqual(id, calibration.Id);
            Assert.AreEqual(dateActivity, calibration.DateActivity);
            Assert.AreEqual(nameTechnician, calibration.NameTechnician);
            Assert.AreEqual(nameCertificateAuthority, calibration.NameCertificateAuthority);
            Assert.IsNotNull(calibration.CalibratedSensors);
            Assert.AreEqual(0, calibration.CalibratedSensors.Count);
        }

        // Pruebas para Maintenance
        [TestMethod]
        public void AddMaintenance_ShouldAddMaintenance()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "Jane Doe";
            var typeMaintenance = TypeMaintenance.Preventivo; // Asegúrate de que TypeMaintenance esté definido
            var maintenance = new Maintenance(id, dateActivity, typeMaintenance, nameTechnician);

            // Act
            _maintenanceRepository.Add(maintenance);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Maintenance>().FirstOrDefault(m => m.Id == id);
            Assert.IsNotNull(result);
            Assert.AreEqual(nameTechnician, result.NameTechnician);
        }

        [TestMethod]
        public void GetMaintenanceById_ShouldReturnMaintenance()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "Jane Doe";
            var typeMaintenance = TypeMaintenance.Preventivo; // Asegúrate de que TypeMaintenance esté definido
            var maintenance = new Maintenance(id, dateActivity, typeMaintenance, nameTechnician);
            _context.Set<Maintenance>().Add(maintenance);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = _maintenanceRepository.GetById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(nameTechnician, result.NameTechnician);
        }

        [TestMethod]
        public void GetAllMaintenance_ShouldReturnAllMaintenance()
        {
            // Arrange
            var maintenance1 = new Maintenance(Guid.NewGuid(), DateTime.Now, TypeMaintenance.Preventivo, "Technician A");
            var maintenance2 = new Maintenance(Guid.NewGuid(), DateTime.Now, TypeMaintenance.Correctivo, "Technician B");
            _context.Set<Maintenance>().AddRange(maintenance1, maintenance2);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = _maintenanceRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void UpdateMaintenance_ShouldModifyMaintenance()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "Jane Doe";
            var typeMaintenance = TypeMaintenance.Preventivo; // Asegúrate de que TypeMaintenance esté definido
            var maintenance = new Maintenance(id, dateActivity, typeMaintenance, nameTechnician);
            _context.Set<Maintenance>().Add(maintenance);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            maintenance.NameTechnician = "Updated Technician";
            _maintenanceRepository.Update(maintenance);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Maintenance>().Find(id);
            Assert.AreEqual("Updated Technician", result.NameTechnician);
        }

        [TestMethod]
        public void DeleteMaintenance_ShouldRemoveMaintenance()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "Jane Doe";
            var typeMaintenance = TypeMaintenance.Preventivo; // Asegúrate de que TypeMaintenance esté definido
            var maintenance = new Maintenance(id, dateActivity, typeMaintenance, nameTechnician);
            _context.Set<Maintenance>().Add(maintenance);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            _maintenanceRepository.Delete(id);
          
        _maintenanceRepository.Delete(id);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Maintenance>().Find(id);
            Assert.IsNull(result);
        }

        // Pruebas para Calibration
        [TestMethod]
        public void AddCalibration_ShouldAddCalibration()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "John Smith";
            var nameCertificateAuthority = "Momoa";
            var calibration = new Calibration(id, nameCertificateAuthority, dateActivity, nameTechnician);

            // Act
            _calibrationRepository.Add(calibration);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Calibration>().FirstOrDefault(c => c.Id == id);
            Assert.IsNotNull(result);
            Assert.AreEqual(nameTechnician, result.NameTechnician);
        }

        [TestMethod]
        public void GetCalibrationById_ShouldReturnCalibration()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "John Smith";
            var nameCertificateAuthority = "Momoa";
            var calibration = new Calibration(id, nameCertificateAuthority, dateActivity, nameTechnician);

            _context.Set<Calibration>().Add(calibration);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = _calibrationRepository.GetById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(nameTechnician, result.NameTechnician);
        }

        [TestMethod]
        public void GetAllCalibration_ShouldReturnAllCalibration()
        {
            // Arrange
            var nameCertificateAuthority = "Momoa";
            var calibration1 = new Calibration(Guid.NewGuid(), nameCertificateAuthority, DateTime.Now, "Technician C");
            var calibration2 = new Calibration(Guid.NewGuid(), nameCertificateAuthority, DateTime.Now, "Technician D");
            _context.Set<Calibration>().AddRange(calibration1, calibration2);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            var result = _calibrationRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void UpdateCalibration_ShouldModifyCalibration()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "John Smith";
            var nameCertificateAuthority = "Momoa";
            var calibration = new Calibration(id, nameCertificateAuthority, dateActivity, nameTechnician);
            _context.Set<Calibration>().Add(calibration);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            calibration.NameTechnician = "Updated Technician";

            _calibrationRepository.Update(calibration);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Calibration>().Find(id);
            Assert.AreEqual("Updated Technician", result.NameTechnician);
        }

        [TestMethod]
        public void DeleteCalibration_ShouldRemoveCalibration()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "John Smith";
            var nameCertificateAuthority = "Momoa";
            var calibration = new Calibration(id, nameCertificateAuthority, dateActivity, nameTechnician);
            _context.Set<Calibration>().Add(calibration);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Act
            _calibrationRepository.Delete(id);
            _unitOfWork.SaveChanges(); // Asegúrate de guardar los cambios

            // Assert
            var result = _context.Set<Calibration>().Find(id);
            Assert.IsNull(result);
        }
    }
}
