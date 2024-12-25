using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.Calibrations.Commands.CreateCalibration;
using maintenance_calibration_system.Domain.Datos_Historicos; // Asegúrate de que este espacio de nombres sea correcto


namespace maintenance_calibration_system.Application.Calibrations.Queries.GetCalibration
{
    public class GetCalibrationByIdQueryHandler(ICalibrationRepository<Calibration> calibrationRepository) : IQueryHandler<GetCalibrationByIdQuery, Calibration>
    {
        private readonly ICalibrationRepository<Calibration> _calibrationRepository = calibrationRepository; // Repositorio para manejar calibraciones

        public Task<Calibration> Handle(GetCalibrationByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener la calibración del repositorio por ID
            Calibration calibration = (Calibration)_calibrationRepository.GetById(request.Id);

            return Task.FromResult(calibration); // Retornar la calibración encontrada
        }
    }
}
