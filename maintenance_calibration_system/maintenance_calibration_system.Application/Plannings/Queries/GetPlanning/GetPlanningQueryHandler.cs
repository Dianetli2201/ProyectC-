using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.Equipments.Queries.GetActuador;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Contracts;
using maintenance_calibration_system.Domain.Datos_de_Planificación;


namespace maintenance_calibration_system.Application.Plannings.Queries.GetPlanning
{
    public class GetPlanningByIdQueryHandler
        : IQueryHandler<GetPlanningByIdQuery, Planning?>
    {
        private readonly IPlanningRepository _planningRepository;

        // Constructor que inyecta el repositorio
        public GetPlanningByIdQueryHandler(IPlanningRepository planningRepository)
        {
            _planningRepository = planningRepository;
        }

        public Task<Planning?> Handle(GetPlanningByIdQuery request, CancellationToken cancellationToken)
        {
            // Obtener todos los sensores del repositorio
            Planning? planning = _planningRepository.GetById(request.Id);

            return Task.FromResult(planning);
        }
    }
}
