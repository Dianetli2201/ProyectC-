using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.Equipments.Queries.GetSensor;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Equipments.Queries.GetActuador
{
    public class GetActuadorByIdQueryHandler
        : IQueryHandler<GetActuadorByIdQuery, Actuador>
    {
        private readonly IEquipmentRepository<Actuador> _equipmentRepository;

        // Constructor que inyecta el repositorio
        public GetActuadorByIdQueryHandler(IEquipmentRepository<Actuador> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<Actuador> Handle(GetActuadorByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener todos los sensores del repositorio
            Actuador actuador = _equipmentRepository.GetById(request.Id);

            return Task.FromResult(actuador);
        }
    }
}
