using GrpcService1.Services;
using maintenance_calibration_system.Contacts;
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Respositories.Equipments;
using maintenance_calibration_system.DataAccess.Respositories.MaintenanceActivitiy;
using maintenance_calibration_system.DataAccess.Respositories.Plannings;


namespace GrpcService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton("Data Source=maintenance_calibration_systemDB.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IEquipmentRepository<>),typeof(EquipmentRepository<>));
            builder.Services.AddScoped(typeof(IMaintenanceActivityRepository<>), typeof(MaintenanceActivityRepository<>));
            builder.Services.AddScoped<IPlanningRepository, PlanningRepository>();
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<SensorsService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}