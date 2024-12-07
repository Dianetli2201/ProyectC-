using System; // Para tipos básicos como Guid y DateTime.
using System.Collections.Generic; // Para usar colecciones genéricas como IEnumerable.
using System.Linq; // Para utilizar métodos LINQ como ToList().
using maintenance_calibration_system.Domain.Common; // Para la clase Entity.
using maintenance_calibration_system.Domain.Datos_Historicos; // Para MaintenanceActivity.
using maintenance_calibration_system.Infrastructure; // Para ApplicationContext.

namespace maintenance_calibration_system.Infrastructure.Repositories
{
    public abstract class MaintenanceActivityRepository<T> where T : MaintenanceActivity
    {
        protected readonly ApplicationContext _context;

        protected MaintenanceActivityRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual void Add(T activity)
        {
            _context.Set<T>().Add(activity);
            _context.SaveChanges();
        }

        public virtual T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual void Update(T activity)
        {
            _context.Set<T>().Update(activity);
            _context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            var activity = GetById(id);
            if (activity != null)
            {
                _context.Set<T>().Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}