using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using maintenance_calibration_system.Application.Calibrations.Commands.CreateCalibration; // Cambiado
using maintenance_calibration_system.Application.Calibrations.Commands.DeleteCalibration; // Cambiado
using maintenance_calibration_system.Application.Calibrations.Commands.UpdateCalibration; // Cambiado
using maintenance_calibration_system.Application.Calibrations.Queries.GetAllCalibrations; // Cambiado
using maintenance_calibration_system.Application.Calibrations.Queries.GetCalibration; // Cambiado
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.GrpcProtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GrpcService1.Services
{
    public class CalibracionesService : Calibration.CalibrationBase // Cambiado
    {
        private readonly ICalibrationRepository<maintenance_calibration_system.Domain.Datos_Historicos.Calibration> _calibrationRepository; // Cambiado
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CalibracionesService> _logger; // Inyectar el logger

        public CalibracionesService( // Cambiado
            IMediator mediator,
            IMapper mapper,
            ILogger<CalibracionesService> logger,
            ICalibrationRepository<maintenance_calibration_system.Domain.Datos_Historicos.Calibration> calibrationRepository, // Cambiado
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _calibrationRepository = calibrationRepository;
            _unitOfWork = unitOfWork;
        }

        public override Task<CalibrationDTO> CreateCalibration(CreateCalibrationRequest request, ServerCallContext context) // Cambiado
        {
            var command = new CreateCalibrationCommand( // Cambiado
                new DateTime(request.DateActivity.ToDateTime().Ticks), // Convertir Timestamp a DateTime
                request.NameTechnician,
                request.NameCertificateAuthority);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<CalibrationDTO>(result)); // Cambiado
        }

        public override Task<NullableCalibrationDTO> GetCalibration(GetRequest request, ServerCallContext context) // Cambiado
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

        public override Task<Calibraciones> GetAllCalibraciones(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context) // Cambiado
        {
            var query = new GetAllCalibrationsQuery(); // Cambiado

            var result = _mediator.Send(query).Result;

            var calibrationDTOs = _mapper.Map<List<CalibrationDTO>>(result); // Mapea la lista de Calibration a List<CalibrationDTO>

            var calibracionesResponse = new Calibraciones // Cambiado
            {
                Items = { calibrationDTOs } // Asumiendo que Items es una colección repetida
            };

            return Task.FromResult(calibracionesResponse); // Devuelve el objeto Calibraciones
        }

        public override Task<Empty> UpdateCalibration(CalibrationDTO request, ServerCallContext context) // Cambiado
        {
            var command = new UpdateCalibrationCommand( // Cambiado
                new Guid(request.Id),
                new DateTime(request.DateActivity.ToDateTime().Ticks), // Convertir Timestamp a DateTime
                request.NameTechnician,
                request.NameCertificateAuthority);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteCalibration(DeleteRequest request, ServerCallContext context) // Cambiado
        {
            var query = new DeleteCalibrationCommand(new Guid(request.Id)); // Cambiado

            var result = _mediator.Send(query).Result;

            return Task.FromResult(new Empty());
        }
    }
}