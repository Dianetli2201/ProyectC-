using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.Equipments.Commands.CreateSensor;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Equipments.Commands.DeleteSensor
{
    public class DeleteSensorCommandHandler : ICommandHandler<DeleteSensorCommand, bool>
    {
        private readonly IEquipmentRepository<Sensor> _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSensorCommandHandler(
            IEquipmentRepository<Sensor> equipmentRepository, 
            IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteSensorCommand request, CancellationToken cancellationToken)
        {
            bool result = true;
            _equipmentRepository.Delete(request.Id);
            _unitOfWork.SaveChanges();
            return Task.FromResult(result);
        }
    }
}
