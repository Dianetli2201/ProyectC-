using System;
using System.Collections.Generic;
using System.Linq;
using maintenance_calibration_system.Domain.Common; // Para la clase Entity
using maintenance_calibration_system.Domain.ValueObjects; // Para PhysicalMagnitude
using maintenance_calibration_system.Domain.Datos_de_Configuracion; // Para Equipment
using maintenance_calibration_system.DataAccess.Contexts; // Para ApplicationContext

namespace maintenance_calibration_system.Infrastructure.Repositories
{
    public abstract class EquipmentRepository<T> where T : Equipment
    {
        protected readonly ApplicationContext _context;

        protected EquipmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual void Add(T equipment)
        {
            _context.Set<T>().Add(equipment);
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

        public virtual void Update(T equipment)
        {
            _context.Set<T>().Update(equipment);
            _context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            var equipment = GetById(id);
            if (equipment != null)
            {
                _context.Set<T>().Remove(equipment);
                _context.SaveChanges();
            }
        }
    }
}