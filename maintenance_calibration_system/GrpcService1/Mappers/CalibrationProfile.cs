using AutoMapper;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.GrpcProtos;
using System.Collections.Generic;

namespace GrpcService1.Mappers
{
    public class CalibrationProfile : Profile
    {
        public CalibrationProfile()
        {
            CreateMap<Calibration, CalibrationDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
                .ForMember(dest => dest.CalibratedSensors, opt => opt.MapFrom(src =>
                    src.CalibratedSensors.ConvertAll(sensor => new SensorDTO
                    {
                        Id = sensor.Id.ToString(), // Asumiendo que Sensor tiene una propiedad Id de tipo Guid
                    })));

            CreateMap<CalibrationDTO, Calibration>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
                .ForMember(dest => dest.CalibratedSensors, opt => opt.MapFrom(src =>
                    src.CalibratedSensors.Select(sensorDto => new maintenance_calibration_system.Domain.Datos_de_Configuracion.Sensor()
                    {
                        Id = Guid.Parse(sensorDto.Id) // Asumiendo que Sensor tiene una propiedad Id de tipo Guid
                    })));
            
        }
    }
}