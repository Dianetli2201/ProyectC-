using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using maintenance_calibration_system.GrpcProtos;

namespace GrpcService1.Mappers
{
    public class SensorProfile : Profile
    {
        public SensorProfile()
        {

            CreateMap<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor,
             maintenance_calibration_system.GrpcProtos.SensorDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
            .ForMember(dest => dest.AlphanumericCode, opt => opt.MapFrom(src => src.AlphanumericCode))
            .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
            .ForMember(dest => dest.PrincipleOperation, opt => opt.MapFrom(src => src.PrincipleOperation))
            .ForMember(dest => dest.Magnitude, opt => opt.MapFrom(src => new maintenance_calibration_system.GrpcProtos.PhysicalMagnitude()
            {
                Name = src.Magnitude.Name,
                UnitofMagnitude = src.Magnitude.UnitofMagnitude,
            }));

            CreateMap<maintenance_calibration_system.GrpcProtos.SensorDTO,
               maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
            .ForMember(dest => dest.AlphanumericCode, opt => opt.MapFrom(src => src.AlphanumericCode))
            .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer))
            .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
            .ForMember(dest => dest.PrincipleOperation, opt => opt.MapFrom(src => src.PrincipleOperation))
              .ForMember(dest => dest.Magnitude, opt => opt.MapFrom(src => new maintenance_calibration_system.Domain.ValueObjects.PhysicalMagnitude()
              {
                  Name = src.Magnitude.Name,
                  UnitofMagnitude = src.Magnitude.UnitofMagnitude,
              }));


            // Mapeo de Sensor a NullableSensorDTO
            CreateMap<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor,
                maintenance_calibration_system.GrpcProtos.NullableSensorDTO>()
                .ForMember(dest => dest.Sensor, opt => opt.MapFrom(src => src != null ? new SensorDTO
                {
                    Id = src.Id.ToString(), // Convertir Guid a string
                    AlphanumericCode = src.AlphanumericCode,
                    Manufacturer = src.Manufacturer,
                    Protocol = (CommunicationProtocol)src.Protocol,
                    PrincipleOperation = src.PrincipleOperation,
                    Magnitude = new maintenance_calibration_system.GrpcProtos.PhysicalMagnitude
                    {
                        Name = src.Magnitude.Name,
                        UnitofMagnitude = src.Magnitude.UnitofMagnitude
                    }
                } : null))
                .ForMember(dest => dest.Null, opt => opt.MapFrom(src => src == null ? NullValue.NullValue : (NullValue?)null));

            CreateMap<maintenance_calibration_system.GrpcProtos.NullableSensorDTO,
              maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Sensor != null ? Guid.Parse(src.Sensor.Id) : Guid.Empty)) // Convertir string a Guid, o usar Guid.Empty si Sensor es null
                .ForMember(dest => dest.AlphanumericCode, opt => opt.MapFrom(src => src.Sensor.AlphanumericCode))
                .ForMember(dest => dest.Magnitude, opt => opt.MapFrom(src => src.Sensor != null ? new PhysicalMagnitude
                {
                    Name = src.Sensor.Magnitude.Name,
                    UnitofMagnitude = src.Sensor.Magnitude.UnitofMagnitude
                } : null)) // Manejo de null para Magnitude
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Sensor.Manufacturer))
                .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Sensor.Protocol))
                .ForMember(dest => dest.PrincipleOperation, opt => opt.MapFrom(src => src.Sensor.PrincipleOperation));


            CreateMap<maintenance_calibration_system.GrpcProtos.SensorDTO, maintenance_calibration_system.GrpcProtos.CreateSensorRequest>()
                .ForMember(dest => dest.AlphanumericCode, opt => opt.MapFrom(src => src.AlphanumericCode))
                .ForMember(dest => dest.Magnitude, opt => opt.MapFrom(src => new maintenance_calibration_system.GrpcProtos.PhysicalMagnitude
                {
                    Name = src.Magnitude.Name,
                    UnitofMagnitude = src.Magnitude.UnitofMagnitude
                }))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer))
                .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
                .ForMember(dest => dest.PrincipleOperation, opt => opt.MapFrom(src => src.PrincipleOperation));


            CreateMap<List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>, Sensors>();

            CreateMap<Sensors, List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>>();
        }


    }
}
