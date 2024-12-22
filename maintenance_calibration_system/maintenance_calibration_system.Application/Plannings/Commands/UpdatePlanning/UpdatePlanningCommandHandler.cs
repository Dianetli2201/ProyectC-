using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Application.Equipments.Commands.UpdateActuador;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.DataAccess.Respositories.Plannings;
using maintenance_calibration_system.Domain.Datos_de_Planificación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Plannings.Commands.UpdatePlanning
{
    public class UpdatePlanningCommandHandler : ICommandHandler<UpdatePlanningCommand, bool>
    {
        private readonly IPlanningRepository _planningRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePlanningCommandHandler(
            IPlanningRepository planningRepository,
            IUnitOfWork unitOfWork)
        {
            _planningRepository = planningRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(UpdatePlanningCommand request, CancellationToken cancellationToken)
        {
            // Buscar el sensor existente
            var existingPlanning = _planningRepository.GetById(request.Id);

            // Crear un nuevo objeto Sensor con los valores actualizados usando el constructor
            var updatedPlanning = new Planning(
                existingPlanning.Id, // Mantener el mismo ID
                request.EquipmentElement,
                request.Type,
                request.ExecutionDate); // Asegúrate de que esta propiedad esté presente


            // Actualizar el sensor en el repositorio
            _planningRepository.Update(updatedPlanning);
            _unitOfWork.SaveChanges();

            return Task.FromResult(true); // Devuelve true si la actualización fue exitosa
        }
    }
}

