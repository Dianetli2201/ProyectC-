using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.DataAccess.Respositories.Equipments;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using Microsoft.Extensions.Logging;


namespace maintenance_calibration_system.Application.Equipments.Commands.UpdateSensor
{
    public class UpdateSensorCommandHandler(
        IEquipmentRepository<Sensor> equipmentRepository,
        IUnitOfWork unitOfWork, ILogger logger) : ICommandHandler<UpdateSensorCommand, bool>
    {
        private readonly IEquipmentRepository<Sensor> _equipmentRepository = equipmentRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger _logger = logger;



        public Task<bool> Handle(UpdateSensorCommand request, CancellationToken cancellationToken)
        {
            // Buscar el sensor existente
            var existingSensor = _equipmentRepository.GetById(request.Id);

            if (existingSensor == null)
            {
                _logger.LogWarning("Sensor with ID {SensorId} not found.", request.Id);
                return Task.FromResult(false); // Devuelve false si no se encuentra el sensor
            }

            // Crear un nuevo objeto Sensor con los valores actualizados usando el constructor
            var updatedSensor = new Sensor(
                existingSensor.Id, // Mantener el mismo ID
                request.AlphanumericCode,
                request.Magnitude,
                request.Manufacturer,
                request.Protocol,
                request.PrincipleOperation); // Asegúrate de que esta propiedad esté presente

            // Actualizar el sensor en el repositorio
            _equipmentRepository.Update(updatedSensor);
            _unitOfWork.SaveChanges();

            _logger.LogInformation("Sensor with ID {SensorId} updated successfully.", request.Id);
            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}