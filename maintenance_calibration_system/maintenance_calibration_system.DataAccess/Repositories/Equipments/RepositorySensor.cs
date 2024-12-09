using System;
using System.Collections.Generic;
using maintenance_calibration_system.Domain.Datos_de_Configuración; // Para Sensor
using maintenance_calibration_system.DataAccess.Contexts; // Para ApplicationContext
using maintenance_calibration_system.Domain.Common;

namespace maintenance_calibration_system.Infrastructure.Repositories
{
    public interface ISensorRepository
    {
        void Add(Sensor sensor);
        Sensor GetById(Guid id);
        IEnumerable<Sensor> GetAll();
        void Update(Sensor sensor);
        void Delete(Guid id);
    }

    public class SensorRepository : EquipmentRepository<Sensor>, ISensorRepository
    {
        public SensorRepository(ApplicationContext context) : base(context)
        {
            // Llama al constructor de EquipmentRepository
        }

        // Los métodos CRUD son heredados de EquipmentRepository,
        // así que no es necesario volver a implementarlos.
    }
}