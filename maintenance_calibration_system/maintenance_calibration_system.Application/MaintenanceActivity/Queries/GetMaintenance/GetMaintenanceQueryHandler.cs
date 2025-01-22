using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetMaintenance;
using maintenance_calibration_system.Domain.Datos_Historicos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.MaintenanceActivity.QueryHandlers
{
    public class GetMaintenanceQueryHandler : IRequestHandler<GetMaintenanceByIdQuery, Maintenance>
    {
        private readonly IMaintenanceActivityRepository _maintenanceRepository;

        public GetMaintenanceQueryHandler(IMaintenanceActivityRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public async Task<Maintenance> Handle(GetMaintenanceByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Buscar la actividad de mantenimiento por ID
                var maintenance = await _maintenanceRepository.GetByIdAsync(request.Id, cancellationToken);

                if (maintenance == null)
                {
                    throw new MaintenanceNotFoundException("La actividad de mantenimiento no existe");
                }

                return maintenance;
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine($"Error al obtener la actividad de mantenimiento: {ex.Message}");
                throw;
            }
        }
    }

    public class MaintenanceNotFoundException : Exception
    {
        public MaintenanceNotFoundException(string message) : base(message) { }
    }
}