

using System;
using System.Collections.Generic;
using System.Linq;
using maintenance_calibration_system.Domain.Datos_de_Configuración; // Para Actuador y IActuadorRepository
using maintenance_calibration_system.DataAccess.Contexts; // Para ApplicationContext
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.ValueObjects;

namespace maintenance_calibration_system.Domain.Datos_de_Configuracion
{
     public interface IActuadorRepository
    {
        void Add(Actuador actuador);
        Actuador GetById(Guid id);
        IEnumerable<Actuador> GetAll();
        void Update(Actuador actuador);
        void Delete(Guid id);
    }
    public class ActuadorRepository : IActuadorRepository
    {
        private readonly ApplicationContext _context;

        public ActuadorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Actuador actuador)
        {
            _context.Set<Actuador>().Add(actuador);
            _context.SaveChanges();
        }

        public Actuador GetById(Guid id)
        {
            return _context.Set<Actuador>().Find(id);
        }

        public IEnumerable<Actuador> GetAll()
        {
            return _context.Set<Actuador>().ToList();
        }

        public void Update(Actuador actuador)
        {
            _context.Set<Actuador>().Update(actuador);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var actuador = GetById(id);
            if (actuador != null)
            {
                _context.Set<Actuador>().Remove(actuador);
                _context.SaveChanges();
            }
        }
    }
}