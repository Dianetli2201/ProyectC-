using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using maintenance_calibration_system.Application.Plannings.Commands.CreatePlanning;
using maintenance_calibration_system.Application.Plannings.Commands.DeletePlanning;
using maintenance_calibration_system.Application.Plannings.Commands.UpdatePlanning;
using maintenance_calibration_system.Application.Plannings.Queries.GetAllPlannings;
using maintenance_calibration_system.Application.Plannings.Queries.GetPlanning;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Contracts;
using maintenance_calibration_system.GrpcProtos;
using MediatR;

namespace GrpcService1.Services
{
    public class PlanningsService : Planning.PlanningBase // Cambiado
    {
        private readonly IPlanningRepository _planningRepository; // Cambiado
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PlanningsService( // Cambiado
            IMediator mediator,
            IMapper mapper,
            IPlanningRepository planningRepository, // Cambiado
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _mediator = mediator;
            _planningRepository = planningRepository; // Cambiado
            _unitOfWork = unitOfWork;
        }

        public override Task<PlanningDTO> CreatePlanning(CreatePlanningRequest request, ServerCallContext context) // Cambiado
        {
            var command = new CreatePlanningCommand( // Cambiado
                request.EquipmentElement, // Nuevo campo
                request.Type, // Nuevo campo
                request.ExecutionDate // Nuevo campo
            );

            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<PlanningDTO>(result)); // Cambiado
        }

        public override Task<NullablePlanningDTO> GetPlanning(GetRequest request, ServerCallContext context) // Cambiado
        {
            var query = new GetPlanningByIdQuery(new Guid(request.Id)); // Cambiado

            var result = _mediator.Send(query).Result;

            return Task.FromResult(_mapper.Map<NullablePlanningDTO>(result)); // Cambiado
        }

        public override Task<Plannings> GetAllPlannings(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context) // Cambiado
        {
            var query = new GetAllPlanningQuery(); // Cambiado

            var result = _mediator.Send(query).Result;

            // Mapea la lista de Planning a List<PlanningDTO> // Cambiado
            var planningDTOs = _mapper.Map<List<PlanningDTO>>(result); // Cambiado

            // Crea un nuevo objeto Plannings y asigna la lista de PlanningDTO // Cambiado
            var planningsResponse = new Plannings // Cambiado
            {
                Items = { planningDTOs } // Asumiendo que Items es una colección repetida
            };

            return Task.FromResult(planningsResponse); // Devuelve el objeto Plannings
        }

        public override Task<Empty> UpdatePlanning(PlanningDTO request, ServerCallContext context) // Cambiado
        {
            var command = new UpdatePlanningCommand( // Cambiado
                new Guid(request.Id), // Ahora se incluye el Id
                request.EquipmentElement, // Nuevo campo
                request.Type, // Nuevo campo
                request.ExecutionDate // Nuevo campo
            );

            var result = _mediator.Send(command).Result;

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeletePlanning(DeleteRequest request, ServerCallContext context) // Cambiado
        {
            var query = new DeletePlanningCommand(new Guid(request.Id)); // Cambiado

            var result = _mediator.Send(query).Result;

            return Task.FromResult(new Empty());
        }
    }
}
