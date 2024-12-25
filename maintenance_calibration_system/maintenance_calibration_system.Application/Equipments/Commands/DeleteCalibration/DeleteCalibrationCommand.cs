using maintenance_calibration_system.Application.Abstract;


namespace maintenance_calibration_system.Application.Equipments.Commands.DeleteActuador
{
    public record DeleteCalibrationCommand(Guid Id) : ICommand<bool>;
}
