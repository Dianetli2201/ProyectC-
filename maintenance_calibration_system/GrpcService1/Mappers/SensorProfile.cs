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
            .ForMember(dest => dest.Magnitude, opt => opt.MapFrom(src => new maintenance_calibration_system.GrpcProtos.PhysicalMagnitude()
            {
                Name = src.Magnitude.Name,
                UnitofMagnitude = src.Magnitude.UnitofMagnitude,
            }));

            CreateMap<maintenance_calibration_system.GrpcProtos.SensorDTO,
               maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
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
                    Magnitude = new maintenance_calibration_system.GrpcProtos.PhysicalMagnitude
                    {
                        Name = src.Magnitude.Name,
                        UnitofMagnitude = src.Magnitude.UnitofMagnitude
                    }

                } : null))
                .ForMember(dest => dest.Null, opt => opt.MapFrom(src => (NullValue?)null));


            CreateMap<List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>, List<SensorDTO>>();
        }


    }
}
