using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using maintenance_calibration_system.Domain.Datos_de_Planificación;
using maintenance_calibration_system.Domain.Common; // Incluye la clase base Entity
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore; // Incluye PlanningTypes

namespace maintenance_calibration_system.DataAccess.Respositories.Plannings
{
    public interface IPlanningRepository
    {
        void Add(Planning planning);
        Planning GetById(Guid id);
        IEnumerable<Planning> GetAll();
        void Update(Planning planning);
        void Delete(Guid id);
    }

    public class PlanningRepository : IPlanningRepository
    {
        private readonly ApplicationContext _context; // Contexto de la base de datos
        private readonly DbSet<Planning> _plannings; // Conjunto de planificaciones

        public PlanningRepository(ApplicationContext context)
        {
            _context = context;
            _plannings = _context.Set<Planning>(); // Inicializa el conjunto de planificaciones
        }

        public void Add(Planning planning)
        {
            if (planning == null)
            {
                throw new ArgumentNullException(nameof(planning), "La planificación no puede ser nula.");
            }
            _plannings.Add(planning); // Agrega la planificación al conjunto
            _context.SaveChanges(); // Guarda los cambios en el contexto
        }

        public Planning GetById(Guid id)
        {
            return _plannings.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Planning> GetAll()
        {
            return _plannings.ToList(); // Convierte a lista para evitar problemas de enumeración
        }

        public void Update(Planning planning)
        {
            var existingPlanning = GetById(planning.Id);
            if (existingPlanning != null)
            {
                existingPlanning.EquipmentElement = planning.EquipmentElement;
                existingPlanning.Type = planning.Type;
                existingPlanning.ExecutionDate = planning.ExecutionDate;
                // Actualizar otras propiedades según sea necesario
                _context.SaveChanges(); // Guarda los cambios en el contexto
            }
        }

        public void Delete(Guid id)
        {
            var planning = GetById(id);
            if (planning != null)
            {
                _plannings.Remove(planning);
                _context.SaveChanges(); // Guarda los cambios en el contexto
            }
        }
    }
}
