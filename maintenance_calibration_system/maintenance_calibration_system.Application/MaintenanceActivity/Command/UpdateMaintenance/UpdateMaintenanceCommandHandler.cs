using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.UpdateMaintenance;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using maintenance_calibration_system.Contacts;

namespace maintenance_calibration_system.Application.MaintenanceActivity.CommandHandlers
{
    public class UpdateMaintenanceCommandHandler : ICommandHandler<UpdateMaintenanceCommand, Maintenance>
    {
        private readonly IMaintenanceActivityRepository _maintenanceRepository;
        private readonly IMaintenanceActivityDbContext _maintenanceDbContext;

        public UpdateMaintenanceCommandHandler(IMaintenanceActivityRepository maintenanceRepository, IMaintenanceActivityDbContext maintenanceDbContext)
        {
            _maintenanceRepository = maintenanceRepository;
            _maintenanceDbContext = maintenanceDbContext;
        }

        public async Task<Maintenance> Handle(UpdateMaintenanceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Buscar la actividad de mantenimiento por ID
                var maintenance = await _maintenanceRepository.GetByIdAsync(request.Id, cancellationToken);

                if (maintenance == null)
                {
                    throw new InvalidOperationException("No se encontró la actividad de mantenimiento");
                }

                // Actualizar los campos que se han proporcionado
                if (request.DateActivity.HasValue)
                {
                    maintenance.DateActivity = request.DateActivity.Value;
                }

                if (!string.IsNullOrEmpty(request.NameTechnician))
                {
                    maintenance.NameTechnician = request.NameTechnician;
                }

                if (request.TypeMaintenance.HasValue)
                {
                    maintenance.TypeMaintenance = request.TypeMaintenance.Value;
                }

                if (request.MaintenanceActuators != null)
                {
                    maintenance.MaintenanceActuador.Clear();
                    foreach (var actuador in request.MaintenanceActuators)
                    {
                        maintenance.MaintenanceActuador.Add(actuador);
                    }
                }

                // Guardar los cambios en la base de datos
                await _maintenanceDbContext.SaveChangesAsync(cancellationToken);

                return maintenance;
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine($"Error al actualizar la actividad de mantenimiento: {ex.Message}");
                throw;
            }
        }
    }
}