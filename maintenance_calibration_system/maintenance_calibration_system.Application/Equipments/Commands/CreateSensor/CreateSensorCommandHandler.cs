using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Equipments.Commands.CreateSensor
{
    public class CreateSensorCommandHandler
        : ICommandHandler<CreateSensorCommand, Sensor>
    {

        private readonly IEquipmentRepository<Sensor> _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSensorCommandHandler(
            IEquipmentRepository<Sensor> equipmentRepository,
            IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Sensor> Handle(CreateSensorCommand request, CancellationToken cancellationToken)
        {
            Sensor result = new Sensor(
                Guid.NewGuid(),
                request.AlphanumericCode,
                request.Magnitude,
                request.Manufacturer,
                request.Protocol,
                request.PrincipleOperation);

            _equipmentRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }

    }
}
