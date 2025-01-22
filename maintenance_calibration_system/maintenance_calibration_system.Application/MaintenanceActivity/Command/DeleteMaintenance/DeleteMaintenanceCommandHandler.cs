using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.CreateMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.DeleteMaintenance;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Contacts;
using System;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.MaintenanceActivity.CommandHandlers
{
    public class DeleteMaintenanceCommandHandler : ICommandHandler<DeleteMaintenanceCommand, bool>
    {
        private readonly IMaintenanceActivityRepository _maintenanceRepository;
        private readonly IMaintenanceActivityDbContext _maintenanceDbContext;

        public DeleteMaintenanceCommandHandler(IMaintenanceActivityRepository maintenanceRepository, IMaintenanceActivityDbContext maintenanceDbContext)
        {
            _maintenanceRepository = maintenanceRepository;
            _maintenanceDbContext = maintenanceDbContext;
        }

        public async Task<bool> Handle(DeleteMaintenanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Buscar la actividad de mantenimiento por ID
                var maintenance = await _maintenanceRepository.GetByIdAsync(request.Id, cancellationToken);

                if (maintenance == null)
                {
                    return false; // No se encontró la actividad de mantenimiento
                }

                // Eliminar la actividad de mantenimiento
                _maintenanceRepository.Remove(maintenance);
                await _maintenanceDbContext.SaveChangesAsync(cancellationToken);

                return true; // Actividad de mantenimiento eliminada correctamente
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine($"Error al eliminar la actividad de mantenimiento: {ex.Message}");
                return false;
            }
        }
    }
}
