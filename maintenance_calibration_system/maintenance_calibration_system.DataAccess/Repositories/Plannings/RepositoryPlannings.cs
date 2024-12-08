using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using maintenance_calibration_system.Domain.Datos_de_Planificación;
using maintenance_calibration_system.Domain.Common; // Incluye la clase base Entity
using maintenance_calibration_system.Domain.Types; // Incluye PlanningTypes

namespace maintenance_calibration_system.Data.Repositories
{
    public interface IPlanningRepository
    {
        void Add(Planning planning);
        Planning GetById(Guid id);
        IEnumerable<Planning> GetAll();
        void Update(Planning planning);
        void Delete(Guid id);
    }

Consola.WriteLinea*(dc sd),


    public class PlanningRepository : IPlanningRepository
    {
        private readonly List<Planning> _plannings; // Simulando una base de datos en memoria

        public PlanningRepository()
        {
            _plannings = new List<Planning>();
        }

        public void Add(Planning planning)
        {
            _plannings.Add(planning);
        }

        public Planning GetById(Guid id)
        {
            return _plannings.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Planning> GetAll()
        {
            return _plannings;
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
            }
        }

        public void Delete(Guid id)
        {
            var planning = GetById(id);
            if (planning != null)
            
                _plannings.Remove(planning);
            }
        }
    }
}