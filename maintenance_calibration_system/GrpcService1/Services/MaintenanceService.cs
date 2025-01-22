using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.CreateMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.DeleteCalibration;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.DeleteMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.UpdateMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetAllMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetCalibration;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetMaintenance;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.GrpcProtos;
using MediatR;

namespace GrpcService1.Services
{
    public class MaintenanceService : Maintenance.MaintenanceBase
    {
        private readonly IMaintenanceRepository<Maintenance> _maintenanceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<MaintenanceService> _logger;

        public MaintenanceService(
            IMediator mediator,
            IMapper mapper,
            ILogger<MaintenanceService> logger,
            IMaintenanceRepository<Maintenance> maintenanceRepository,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _maintenanceRepository = maintenanceRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<MaintenanceDTO> CreateMaintenance(CreateMaintenanceRequest request, ServerCallContext context)
        {
            var command = new CreateMaintenanceCommand(
                request.DateActivity.ToDateTime(),
                request.NameTechnician,
                request.TypeMaintenance,
                new List<Actuador>());

            var result = await _mediator.Send(command);

            return _mapper.Map<MaintenanceDTO>(result);
        }

        public override async Task<NullableMaintenanceDTO> GetMaintenance(GetRequest request, ServerCallContext context)
        {
            var query = new GetMaintenanceByIdQuery(new Guid(request.Id));

            var result = await _mediator.Send(query);

            if (result == null)
            {
                _logger.LogWarning("Mantenimiento no encontrado para ID: {MaintenanceId}", request.Id);
                return new NullableMaintenanceDTO { Kind = NullableMaintenanceDTO.KindOneofCase.Null };
            }
            else
            {
                _logger.LogInformation("Mantenimiento encontrado para ID: {MaintenanceId}", request.Id);
            }

            return _mapper.Map<NullableMaintenanceDTO>(result);
        }

        public override async Task<Calibrations> GetAllMaintenances(Empty request, ServerCallContext context)
        {
            var query = new GetAllMaintenanceQuery();

            var result = await _mediator.Send(query);

            var maintenanceDTOs = _mapper.Map<List<MaintenanceDTO>>(result);

            var response = new Maintenances { Items = { maintenanceDTOs } };

            return response;
        }

        public override async Task<Empty> UpdateMaintenance(MaintenanceDTO request, ServerCallContext context)
        {
            var command = new UpdateMaintenanceCommand(
                new Guid(request.Id),
                request.DateActivity.ToDateTime(),
                request.NameTechnician,
                request.TypeMaintenance,
                new List<Actuador>());

            await _mediator.Send(command);

            return new Empty();
        }

        public override async Task<Empty> DeleteMaintenance(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteMaintenanceCommand(new Guid(request.Id));

            await _mediator.Send(command);

            return new Empty();
        }
    }
}