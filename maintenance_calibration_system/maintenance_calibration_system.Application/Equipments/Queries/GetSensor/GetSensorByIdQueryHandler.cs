using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;


namespace maintenance_calibration_system.Application.Equipments.Queries.GetSensor
{
    public class GetSensorByIdQueryHandler
        : IQueryHandler<GetSensorByIdQuery, Sensor>
    {
        private readonly IEquipmentRepository<Sensor> _equipmentRepository;

        // Constructor que inyecta el repositorio
        public GetSensorByIdQueryHandler(IEquipmentRepository<Sensor> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task<Sensor> Handle(GetSensorByIdQuery request, CancellationToken cancellationToken)
        {

                // Obtener el sensor del repositorio
                Sensor sensor = _equipmentRepository.GetById(request.Id);

                return Task.FromResult(sensor);
            
        }
    }
}
