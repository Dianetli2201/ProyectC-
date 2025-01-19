using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.GrpcProtos;


namespace GrpcService1.Mappers
{
    public class CalibrationProfile : Profile
    {
        public CalibrationProfile()
        {
            CreateMap<Calibration, CalibrationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
                .ForMember(dest => dest.DateActivity, opt => opt.MapFrom(src => src.DateActivity.ToTimestamp()))
                .ForMember(dest => dest.CalibratedSensors, opt => opt.MapFrom(src => src.CalibratedSensors)); // Mapeo automático de la lista

            CreateMap<CalibrationDTO, Calibration>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
                .ForMember(dest => dest.DateActivity, opt => opt.MapFrom(src => src.DateActivity.ToDateTime()))
                .ForMember(dest => dest.CalibratedSensors, opt => opt.MapFrom(src => src.CalibratedSensors)); // Mapeo automático de la lista
        }
    }
}