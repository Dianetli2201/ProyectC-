using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.CreateCalibration;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.DeleteCalibration;
using maintenance_calibration_system.Application.MaintenanceActivity.Command.UpdateCalibration;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetAllCalibration;
using maintenance_calibration_system.Application.MaintenanceActivity.Queries.GetCalibration;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.GrpcProtos;
using MediatR;

namespace GrpcService1.Services
{
    public class CalibrationService : Calibration.CalibrationBase // Cambiado
    {
        private readonly ICalibrationRepository<Calibration> _calibrationRepository; // Cambiado
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CalibrationService> _logger; // Inyectar el logger

        public CalibrationService( // Cambiado
            IMediator mediator,
            IMapper mapper,
            ILogger<CalibrationService> logger,
            ICalibrationRepository<maintenance_calibration_system.Domain.Datos_Historicos.Calibration> calibrationRepository, // Cambiado
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _calibrationRepository = calibrationRepository; // Cambiado
            _unitOfWork = unitOfWork;
        }

        public  Task<CalibrationDTO> CreateCalibration(CreateCalibrationRequest request, ServerCallContext context) // Cambiado
        {
            var command = new CreateCalibrationCommand( // Cambiado
                request.DateActivity.ToDateTime(), // Convertir Timestamp a DateTime
                request.NameTechnician,
                request.NameCertificateAuthority,
                new List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>()); // Aquí puedes llenar la lista de sensores según sea necesario

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<CalibrationDTO>(result)); // Cambiado
        }

        public  Task<NullableCalibrationDTO> GetCalibration(GetRequest request, ServerCallContext context) // Cambiado
        {
            var query = new GetCalibrationByIdQuery(new Guid(request.Id)); // Cambiado

            var result = _mediator.Send(query).Result;

            if (result == null)
            {
                _logger.LogWarning("Calibración no encontrada para ID: {CalibrationId}", request.Id); // Log de advertencia
                return Task.FromResult<NullableCalibrationDTO>(null);
            }
            else
            {
                _logger.LogInformation("Calibración encontrada para ID: {CalibrationId}", request.Id); // Log de información
            }

            return Task.FromResult(_mapper.Map<NullableCalibrationDTO>(result)); // Cambiado
        }

        public  Task<Calibration> GetAllCalibrations(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context) // Cambiado
        {
            var query = new GetAllCalibrationQuery(); // Cambiado

            var result = _mediator.Send(query).Result;

            var calibrationDTOs = _mapper.Map<List<CalibrationDTO>>(result); // Mapea la lista de Calibration a List<CalibrationDTO>

            var calibrationResponse = new Calibration(); // Cambiado
            calibrationResponse.Items.AddRange(calibrationDTOs); // Asumiendo que Items es una colección repetida

            return Task.FromResult(calibrationResponse); // Devuelve el objeto Calibration
        }

        public  Task<Empty> UpdateCalibration(CalibrationDTO request, ServerCallContext context) // Cambiado
        {
            var command = new UpdateCalibrationCommand( // Cambiado
                new Guid(request.Id),
                request.DateActivity.ToDateTime(), // Convertir Timestamp a DateTime
                request.NameTechnician,
                request.NameCertificateAuthority,
                new List<Sensor>()); // Aquí puedes llenar la lista de sensores según sea necesario

            var result = _mediator.Send(command).Result;

            return Task.FromResult(new Empty());
        }

        public  Task<Empty> DeleteCalibration(DeleteRequest request, ServerCallContext context) // Cambiado
        {
            var command = new DeleteCalibrationCommand(new Guid(request.Id)); // Cambiado

            var result = _mediator.Send(command).Result;

            return Task.FromResult(new Empty());
        }
    }
}