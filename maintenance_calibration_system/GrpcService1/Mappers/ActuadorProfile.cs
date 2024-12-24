using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using maintenance_calibration_system.GrpcProtos;

namespace GrpcService1.Mappers
{
    public class ActuadorProfile : Profile
    {
        public ActuadorProfile()
        {
            CreateMap<maintenance_calibration_system.Domain.Datos_de_Configuracion.Actuador,
             maintenance_calibration_system.GrpcProtos.ActuadorDTO>()
            .ForMember(dest => dest.Magnitude, opt => opt.MapFrom(src => new maintenance_calibration_system.GrpcProtos.PhysicalMagnitude()
            {
                Name = src.Magnitude.Name,
                UnitofMagnitude = src.Magnitude.UnitofMagnitude,
            }));

            CreateMap<maintenance_calibration_system.GrpcProtos.ActuadorDTO,
               maintenance_calibration_system.Domain.Datos_de_Configuracion.Actuador>()
              .ForMember(dest => dest.Magnitude, opt => opt.MapFrom(src => new maintenance_calibration_system.Domain.ValueObjects.PhysicalMagnitude()
              {
                  Name = src.Magnitude.Name,
                  UnitofMagnitude = src.Magnitude.UnitofMagnitude,
              }));


            // Mapeo de Actuador a NullableActuadorDTO
            CreateMap<maintenance_calibration_system.Domain.Datos_de_Configuracion.Actuador,
                maintenance_calibration_system.GrpcProtos.NullableActuadorDTO>()
                .ForMember(dest => dest.Actuador, opt => opt.MapFrom(src => src != null ? new ActuadorDTO
                {
                    // Solo mapeamos Magnitude manualmente, los demás se mapean automáticamente
                    Magnitude = new maintenance_calibration_system.GrpcProtos.PhysicalMagnitude
                    {
                        Name = src.Magnitude.Name,
                        UnitofMagnitude = src.Magnitude.UnitofMagnitude
                    }
                } : null))
                .ForMember(dest => dest.Null, opt => opt.MapFrom(src => src == null ? NullValue.NullValue : (NullValue?)null));


            CreateMap<List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Actuador>, Actuadores>();
        }


    }
}
