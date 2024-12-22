using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using maintenance_calibration_system.GrpcProtos;

namespace GrpcService1.Mappers
{
    public class PlanningProfile : Profile
    {
        public PlanningProfile()
        {


            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(dt => Timestamp.FromDateTime(dt.ToUniversalTime()));

            CreateMap<maintenance_calibration_system.Domain.Datos_de_Planificación.Planning,
                maintenance_calibration_system.GrpcProtos.PlanningDTO>()
                .ForMember(dest => dest.ExecutionDate, opt => opt.MapFrom(src => src.ExecutionDate));

            CreateMap<maintenance_calibration_system.GrpcProtos.PlanningDTO,
                maintenance_calibration_system.Domain.Datos_de_Planificación.Planning>()
                .ForMember(dest => dest.ExecutionDate, opt => opt.MapFrom(src => src.ExecutionDate));

   


            // Mapeo de Planning a NullablePlanningDTO
            CreateMap<maintenance_calibration_system.Domain.Datos_de_Planificación.Planning,
                maintenance_calibration_system.GrpcProtos.NullablePlanningDTO>()
                .ForMember(dest => dest.Planning, opt => opt.MapFrom(src => src != null ? new maintenance_calibration_system.GrpcProtos.PlanningDTO
                {
                    // Solo mapeamos ExecutionDate manualmente, los demás se mapean automáticamente
                 //   ExecutionDate = CreateMap<src.ExecutionDate, dest.ExecutionDate> // Llama a tu método de conversión aquí

                } : null))
                .ForMember(dest => dest.Null, opt => opt.MapFrom(src => src == null ? NullValue.NullValue : (NullValue?)null));


            CreateMap<List<maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor>, List<SensorDTO>>();
        }

    }
}
