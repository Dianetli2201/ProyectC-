using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.Equipments.Queries.GetAllSensor;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Equipments.Queries.GetAllActuador
{
    public class GetAllActuadorQueryHandler
        : IQueryHandler<GetAllActuadorQuery, List<Actuador>>
    {
        private readonly IEquipmentRepository<Actuador> _equipmentRepository;

        // Constructor que inyecta el repositorio
        public GetAllActuadorQueryHandler(IEquipmentRepository<Actuador> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<List<Actuador>> Handle(GetAllActuadorQuery request, CancellationToken cancellationToken)
        {
            // Obtener todos los sensores del repositorio
            var Actuadores = _equipmentRepository.GetAll();

            return Task.FromResult(Actuadores.ToList());
        }
    }
}
