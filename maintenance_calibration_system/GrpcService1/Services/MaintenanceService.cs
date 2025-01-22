using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.CreateMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.DeleteMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.UpdateMaintenance;
//using maintenance_calibration_system.Application.MaintenanceActivity.Command.ModifyMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetAllMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetAllCalibration;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetCalibration;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetMaintenance;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.CreateCalibration;
using GrpcService1.Mappers;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.GrpcProtos;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GrpcService1.Services
{
    public class MaintenancesService : MaintenanceService.MaintenanceServiceBase // Cambiado
    {
        private readonly IMaintenanceActivityRepository<maintenance_calibration_system.Domain.Datos_Historicos.Maintenance> _maintenanceRepository; // Cambiado
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<MaintenancesService> _logger; // Inyectar el logger

        public MaintenancesService( // Cambiado
            IMediator mediator,
            IMapper mapper,
            ILogger<MaintenancesService> logger,
             IMaintenanceActivityRepository<maintenance_calibration_system.Domain.Datos_Historicos.Maintenance> maintenanceRepository, // Cambiado
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
            var actuators = new List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Actuador>();

            var command = new CreateMaintenanceCommand(
                request.DateActivity.ToDateTime(),
                request.TypeMaintenance,
                request.NameTechnician,
                actuators
            );

            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<MaintenanceDTO>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el mantenimiento");
                throw new RpcException(new Status(StatusCode.Internal, "Error interno del servidor"));
            }
        }

        public override Task<MaintenanceDTO> GetMaintenance(GetRequest request, ServerCallContext context) // Cambiado
        {
            var query = new GetMaintenanceByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;

            if (result == null)
            {
                _logger.LogWarning("Mantenimiento no encontrado para ID: {MaintenanceId}", request.Id); // Log de advertencia
                //return Task.FromResult<NullableMaintenanceDTO>(null);
                if (result == null)
                {
                    _logger.LogWarning("Mantenimiento no encontrado para ID: {MaintenanceId}", request.Id);
                    //    return Task.FromResult(new MaintenanceDTO { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue });
                }
            }
            else
            {
                _logger.LogInformation("Mantenimiento encontrado para ID: {MaintenanceId}", request.Id); // Log de información
            }

            return Task.FromResult(_mapper.Map<MaintenanceDTO>(result)); // Cambiado
        }

        public override Task<Maintenances> GetAllMaintenances(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context) // Cambiado
        {
            var query = new GetAllMaintenanceQuery(); // Cambiado

            var result = _mediator.Send(query).Result;

            var maintenanceDTOs = _mapper.Map<List<MaintenanceDTO>>(result); // Mapea la lista de Maintenance a List<MaintenanceDTO>

            var maintenanceResponse = new Maintenances(); // Cambiado
            maintenanceResponse.Items.AddRange(maintenanceDTOs); // Asumiendo que Items es una colección repetida

            return Task.FromResult(maintenanceResponse); // Devuelve el objeto Maintenance
        }

        public override Task<Empty> UpdateMaintenance(MaintenanceDTO request, ServerCallContext context) // Cambiado
        {
            var command = new UpdateMaintenanceCommand( // Cambiado
                new Guid(request.Id),
                request.DateActivity.ToDateTime(), // Convertir Timestamp a DateTime
                request.TypeMaintenance,
                request.NameTechnician,
                new List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Actuador>()
                );

            var result = _mediator.Send(command).Result;

            return Task.FromResult(new Empty());
        }

        /// <summary>Devuelve todas las entidades del tipo especificado.</summary>
        /// <returns>Una colección de todas las entidades.</returns>
       /* public override Task<Empty> AddOrModifyCalibratedSensors(ModifyCalibrationDTO request, ServerCallContext context) // Cambiado
        {

            var command = new ModifyCalibrationCommand( // Cambiado
                new Guid(request.Id),
                _mapper.Map<List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>>(request.CalibratedSensors)
                );

            var result = _mediator.Send(command).Result;

            return Task.FromResult(new Empty());
        } */



        public override Task<Empty> DeleteMaintenance(DeleteRequest request, ServerCallContext context) // Cambiado
        {

            try
            {
                var command = new DeleteMaintenanceCommand(new Guid(request.Id));
                var result = _mediator.Send(command).Result;
            }
            catch (FormatException)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "El formato del ID no es válido."));
            }



            return Task.FromResult(new Empty());
        }
    }
}