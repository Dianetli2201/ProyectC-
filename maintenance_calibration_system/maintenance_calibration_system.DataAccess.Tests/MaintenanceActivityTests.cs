using Microsoft.VisualStudio.TestTools.UnitTesting;
using maintenance_calibration_system.Domain.Datos_Historicos;
using System;
using System.Collections.Generic;
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.ValueObjects;

namespace maintenance_calibration_system.Tests
{
    [TestClass]
    public class MaintenanceActivityTests
    {
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

        [TestMethod]
        public void Maintenance_Creation_ShouldInitializeProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "Jane Doe";
            var typeMaintenance = TypeMaintenance.Preventivo; // Asegúrate de que TypeMaintenance esté definido

            // Act
            var maintenance = new Maintenance(id, dateActivity, typeMaintenance, nameTechnician);

            // Assert
            Assert.AreEqual(id, maintenance.Id);
            Assert.AreEqual(dateActivity, maintenance.DateActivity);
            Assert.AreEqual(nameTechnician, maintenance.NameTechnician);
            Assert.AreEqual(typeMaintenance, maintenance.TypeMaintenance);
            Assert.IsNotNull(maintenance.MaintenanceActuador);
            Assert.AreEqual(0, maintenance.MaintenanceActuador.Count);
        }



        [TestMethod]
        public void Maintenance_AddActuator_ShouldIncreaseMaintenanceActuadorCount()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "Jane Doe";
            var typeMaintenance = TypeMaintenance.Preventivo; // Asegúrate de que TypeMaintenance esté definido
            var maintenance = new Maintenance(id, dateActivity, typeMaintenance, nameTechnician);
            var someMagnitude = new PhysicalMagnitude("Temperature", "Celsius");
            var actuador = new Actuador(Guid.NewGuid(), "ACTUADOR006", someMagnitude, "ManufacturerF", "ControlCode", SignalControl.Analog);

            // Act
            maintenance.MaintenanceActuador.Add(actuador);

            // Assert
            Assert.AreEqual(1, maintenance.MaintenanceActuador.Count);
            Assert.AreEqual(actuador, maintenance.MaintenanceActuador[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Calibration_Creation_WithNullTechnician_ShouldThrowException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            string? nameTechnician = null; // Null technician name
            var nameCertificateAuthority = "Cert Authority";

            // Act
            var calibration = new Calibration(id, nameCertificateAuthority, dateActivity, nameTechnician);
        }

        [TestMethod]
        public void Calibration_Creation_WithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "John Doe";
            var nameCertificateAuthority = "Cert Authority";

            // Act & Assert
            var calibration = new Calibration(id, nameCertificateAuthority, dateActivity, nameTechnician);
            Assert.IsNotNull(calibration);
        }

        [TestMethod]
        public void Maintenance_Creation_WithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "Jane Doe";
            var typeMaintenance = TypeMaintenance.Preventivo; // Asegúrate de que TypeMaintenance esté definido

            // Act & Assert
            var maintenance = new Maintenance(id, dateActivity, typeMaintenance, nameTechnician);
            Assert.IsNotNull(maintenance);
        }

        [TestMethod]
        public void Calibration_ShouldHaveUniqueId()
        {
            // Arrange
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "John Doe";
            var nameCertificateAuthority = "Cert Authority";

            // Act
            var calibration1 = new Calibration(id1, nameCertificateAuthority, dateActivity, nameTechnician);
            var calibration2 = new Calibration(id2, nameCertificateAuthority, dateActivity, nameTechnician);

            // Assert
            Assert.AreNotEqual(calibration1.Id, calibration2.Id);
        }

        [TestMethod]
        public void Maintenance_ShouldHaveUniqueId()
        {
            // Arrange
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var dateActivity = DateTime.Now;
            var nameTechnician = "Jane Doe";
            var typeMaintenance = TypeMaintenance.Preventivo; // Asegúrate de que TypeMaintenance esté definido

            // Act
            var maintenance1 = new Maintenance(id1, dateActivity, typeMaintenance, nameTechnician);
            var maintenance2 = new Maintenance(id2, dateActivity, typeMaintenance, nameTechnician);

            // Assert
            Assert.AreNotEqual(maintenance1.Id, maintenance2.Id);
        }
    }
}


    }
}
