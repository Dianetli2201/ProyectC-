﻿using maintenance_calibration_system.Application.Abstract;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.DataAccess.Respositories.Plannings;


namespace maintenance_calibration_system.Application.Plannings.Commands.DeletePlanning
{
    public class DeletePlanningCommandHandler : ICommandHandler<DeletePlanningCommand, bool>
    {
        private readonly IPlanningRepository _planningRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePlanningCommandHandler(
            IPlanningRepository planningRepository,
            IUnitOfWork unitOfWork)
        {
            _planningRepository = planningRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(DeletePlanningCommand request, CancellationToken cancellationToken)
        {
            bool result = true;
            _planningRepository.Delete(request.Id);
            _unitOfWork.SaveChanges();
            return Task.FromResult(result);
        }
    }
}
