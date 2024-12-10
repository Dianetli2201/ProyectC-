using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Respositories.Equipments;
using maintenance_calibration_system.DataAccess.Respositories.Plannings;
using Microsoft.EntityFrameworkCore;

public interface IUnitOfWork
{
    void SaveChanges();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        if (!context.Database.CanConnect())
            context.Database.Migrate();
    }

    public void SaveChanges() 
    {
        _context.SaveChanges();
    }
}