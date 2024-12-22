using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.Equipments.Commands.DeleteSensor;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Equipments.Commands.UpdateSensor
{
    public class UpdateSensorCommandHandler : ICommandHandler<UpdateSensorCommand, bool>
    {
        private readonly IEquipmentRepository<Sensor> _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSensorCommandHandler(
            IEquipmentRepository<Sensor> equipmentRepository,
            IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(UpdateSensorCommand request, CancellationToken cancellationToken)
        {
            // Buscar el sensor existente
            var existingSensor = _equipmentRepository.GetById(request.Id);

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

            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}
