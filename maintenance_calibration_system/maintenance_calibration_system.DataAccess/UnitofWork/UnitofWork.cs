public interface IUnitOfWork : IDisposable
{
    ISensorRepository Sensors { get; }
    IActuatorRepository Actuators { get; }
    ICalibrationRepository Calibrations { get; }
    IMaintenanceRepository Maintenances { get; }
    IPlanningRepository Plannings { get; }

    Task<int> SaveChangesAsync();
}
public class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _context;

    public UnitOfWork(MyDbContext context)
    {
        _context = context;
        Sensors = new SensorRepository(_context);
        Actuators = new ActuatorRepository(_context);
        Calibrations = new CalibrationRepository(_context);
        Maintenances = new MaintenanceRepository(_context);
        Plannings = new PlanningRepository(_context);
    }

        public UnitOfWork(ISensorRepository sensors, IActuatorRepository actuators, ICalibrationRepository calibrations, IMaintenanceRepository maintenances, IPlanningRepository plannings) 
        {
            this.Sensors = sensors;
                this.Actuators = actuators;
                this.Calibrations = calibrations;
                this.Maintenances = maintenances;
                this.Plannings = plannings;
               
        }
             
            public ISensorRepository Sensors { get; }
    public IActuatorRepository Actuators { get; }
    public ICalibrationRepository Calibrations { get; }
    public IMaintenanceRepository Maintenances { get; }
    public IPlanningRepository Plannings { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}