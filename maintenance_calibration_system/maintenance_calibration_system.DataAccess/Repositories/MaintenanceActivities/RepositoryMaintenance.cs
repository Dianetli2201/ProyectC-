using System;
using System.Collections.Generic;
using System.Linq;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Common;

namespace maintenance_calibration_system.Data.Repositories
{
    public interface IMaintenanceRepository
    {
        void Add(Maintenance maintenance);
        Maintenance GetById(Guid id);
        IEnumerable<Maintenance> GetAll();
        void Update(Maintenance maintenance);
        void Delete(Guid id);
    }

    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly List<Maintenance> _maintenances; // Simulando una base de datos en memoria

        public MaintenanceRepository()
        {
            _maintenances = new List<Maintenance>();
        }

        public void Add(Maintenance maintenance)
        {
            _maintenances.Add(maintenance);
        }

        public Maintenance GetById(Guid id)
        {
            return _maintenances.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Maintenance> GetAll()
        {
            return _maintenances;
        }

        public void Update(Maintenance maintenance)
        {
            var existingMaintenance = GetById(maintenance.Id);
            if (existingMaintenance != null)
            {
                existingMaintenance.TypeMaintenance = maintenance.TypeMaintenance;
                existingMaintenance.MaintenanceActuador = maintenance.MaintenanceActuador;
                // Actualizar otras propiedades según sea necesario
            }
        }

        public void Delete(Guid id)
        {
            var maintenance = GetById(id);
            if (maintenance != null)
            {
                _maintenances.Remove(maintenance);
            }
        }
    }
}