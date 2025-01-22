using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using System;
using maintenance_calibration_system.Domain.Types; // Asegúrate de que este espacio de nombres sea correcto


namespace maintenance_calibration_system.Application.MaintenanceActivity.Command.UpdateMaintenance
{
    public record UpdateMaintenanceCommand(
        Guid Id,
        DateTime? DateActivity = null,
        string? NameTechnician = null,
        TypeMaintenance? TypeMaintenance = null,
        List<Actuador>? MaintenanceActuators = null) : ICommand<Maintenance>;
}