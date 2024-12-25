﻿using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Domain.Types; // Asegúrate de que este espacio de nombres tenga las definiciones necesarias
using System;

namespace maintenance_calibration_system.Application.Calibrations.Commands.CreateCalibration
{
    internal interface ICalibrationRepository<T>
    {
        object Delete(Guid id);
        object GetById(Guid id);
        void Update(Calibration updatedCalibration);
    }
    public record CreateCalibrationCommand(
        DateTime DateActivity,
        string NameTechnician,
        string NameCertificateAuthority,
        List<Sensor> CalibratedSensors) : ICommand<Calibration>;
}
