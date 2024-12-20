using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService1;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.GrpcProtos;


namespace GrpcService1.Services
{
    public class SensorsService : Sensor.SensorBase
    {
        private readonly IEquipmentRepository<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor> _equipmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SensorsService(
            IEquipmentRepository<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor> equipmentRepository, 
            IUnitOfWork unitOfWork)
        {
            _equipmentRepository = equipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public override Task<SensorDTO> CreateSensor(CreateSensorRequest request, ServerCallContext context)
        {
            return base.CreateSensor(request, context); 
        }

        public override Task<NullableSensorDTO> GetSensor(GetRequest request, ServerCallContext context)
        {
            return base.GetSensor(request, context);
        }

        public override Task<Sensors> GetAllSensors(Empty request, ServerCallContext context)
        {
            return base.GetAllSensors(request, context);
        }

        public override Task<Empty> UpdateSensor(SensorDTO request, ServerCallContext context)
        {
            return base.UpdateSensor(request, context);
        }

        public override Task<Empty> DeleteSensor(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteSensor(request, context);
        }
    }
}
