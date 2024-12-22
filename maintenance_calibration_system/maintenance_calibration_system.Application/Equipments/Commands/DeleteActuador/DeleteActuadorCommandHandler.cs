using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;


namespace maintenance_calibration_system.Application.Equipments.Commands.DeleteActuador
{
    public class DeleteActuadorCommandHandler : ICommandHandler<DeleteActuadorCommand, bool>
    {
        private readonly IEquipmentRepository<Actuador> _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteActuadorCommandHandler(
            IEquipmentRepository<Actuador> equipmentRepository,
            IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeleteActuadorCommand request, CancellationToken cancellationToken)
        {
            bool result = true;
            _equipmentRepository.Delete(request.Id);
            _unitOfWork.SaveChanges();
            return Task.FromResult(result);
        }
    }
}
