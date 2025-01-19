using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Datos_de_Configuracion; // Asegúrate de que este espacio de nombres sea correcto
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.MaintenanceActivity.Command.CreateCalibration
{
    public class CreateCalibrationCommandHandler(
       IMaintenanceActivityRepository<Calibration> calibrationRepository,
        IUnitOfWork unitOfWork)
                : ICommandHandler<CreateCalibrationCommand, Calibration>
    {
        private readonly IMaintenanceActivityRepository<Calibration> _calibrationRepository = (IMaintenanceActivityRepository<Calibration>)calibrationRepository; // Cambiado para usar el repositorio de calibraciones
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public Task<Calibration> Handle(CreateCalibrationCommand request, CancellationToken cancellationToken)
        {
            var result = new Calibration(
                Guid.NewGuid(),
                request.DateActivity,
                request.NameTechnician,
                request.NameCertificateAuthority);

            // Asumiendo que necesitas agregar sensores calibrados a la calibración
            if (request.CalibratedSensors != null)
            {
                foreach (var sensor in request.CalibratedSensors)
                {
                    // Aquí puedes agregar lógica para manejar los sensores si es necesario
                    result.CalibratedSensors.Add(sensor);
                }
            }

            _calibrationRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
