

using System;
using System.Collections.Generic;
using System.Linq;
using maintenance_calibration_system.Domain.Datos_de_Configuraci�n; // Para Actuador
using maintenance_calibration_system.DataAccess.Contexts; // Para ApplicationContext
using maintenance_calibration_system.Domain.Common;

namespace maintenance_calibration_system.Infrastructure.Repositories
{
    public interface IActuadorRepository
    {
        void Add(Actuador actuador);
        Actuador GetById(Guid id);
        IEnumerable<Actuador> GetAll();
        void Update(Actuador actuador);
        void Delete(Guid id);
    }

    public class ActuadorRepository : EquipmentRepository<Actuador>, IActuadorRepository
    {
        public ActuadorRepository(ApplicationContext context) : base(context)
        {
            // Llama al constructor de EquipmentRepository
        }

        // Los m�todos CRUD son heredados de EquipmentRepository,
        // as� que no es necesario volver a implementarlos.
    }
}