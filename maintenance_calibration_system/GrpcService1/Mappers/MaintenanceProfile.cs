using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.GrpcProtos;


namespace GrpcService1.Mappers
{
    public class MaintenanceProfile : Profile
    {
        public MaintenanceProfile()
        {
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(dt => Timestamp.FromDateTime(dt.ToUniversalTime()));

            CreateMap<Timestamp, DateTime>()
                .ConvertUsing(ts => ts.ToDateTime());

            // Configuración para mapear TypeMaintenance a string
            //CreateMap<TypeMaintenance, string>()
                //.ConvertUsing(enumValue => enumValue.ToString());

            CreateMap<Maintenance, MaintenanceDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // Convertir Guid a string
                                                                                          //       .ForMember(dest => dest.DateActivity, opt => opt.MapFrom(src => src.DateActivity.ToTimestamp()))
                .ForMember(dest => dest.MaintenanceActuador, opt => opt.MapFrom(src => src.MaintenanceActuador)); // Mapeo automático de la lista

            CreateMap<MaintenanceDTO, Maintenance>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id))) // Convertir string a Guid
                                                                                           //      .ForMember(dest => dest.DateActivity, opt => opt.MapFrom(src => src.DateActivity.ToDateTime()))
                .ForMember(dest => dest.MaintenanceActuador, opt => opt.MapFrom(src => src.MaintenanceActuador)); // Mapeo automático de la lista
            
                      /*  // Mapeo de Sensor a NullableSensorDTO
                        CreateMap<Maintenance, NullableMaintenanceDTO>()
                            .ForMember(dest => dest.Maintenance, opt => opt.MapFrom(src => src != null ? new CalibrationDTO
                            {
                                Id = src.Id.ToString(), // Convertir Guid a string      
                                DateActivity = src.DateActivity.ToTimestamp(),
                                CalibratedSensors = new maintenance_calibration_system.GrpcProtos.Sensors
                                {
                                    Actuador = src.MaintenanceActuador.Sele
                                    Id = Actuador.Id.ToString(), // Convertir Guid a string
                                    AlphanumericCode = Actuador.AlphanumericCode,
                                    Manufacturer = Actuador.Manufacturer,
                                    Protocol = (CommunicationProtocol)Actuador.Protocol,
                                    PrincipleOperation = Actuador.PrincipleOperation,
                                    Magnitude = new maintenance_calibration_system.GrpcProtos.PhysicalMagnitude
                                    {
                                        Name = Sensor.Magnitude.Name,
                                        UnitofMagnitude = Sensor.Magnitude.UnitofMagnitude
                                    }
                                }).ToList() // Mapeo  de la lista
                            } : null));


                        CreateMap<NullableCalibrationDTO, Calibration>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Calibration != null ? Guid.Parse(src.Calibration.Id) : Guid.Empty)) // Convertir string a Guid, o usar Guid.Empty si Sensor es null
                            .ForMember(dest => dest.DateActivity, opt => opt.MapFrom(src => src.Calibration.DateActivity.ToDateTime()))
                            .ForMember(dest => dest.CalibratedSensors, opt => opt.MapFrom(src => src.Calibration.CalibratedSensors)); // Mapeo automático de la lista
                      */
        }
    }
}