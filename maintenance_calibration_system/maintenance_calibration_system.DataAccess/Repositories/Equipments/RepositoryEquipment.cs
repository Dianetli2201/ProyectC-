using System;
using System.Collections.Generic;
using System.Linq;
using maintenance_calibration_system.Domain.Common; // Para la clase Entity
using maintenance_calibration_system.Domain.ValueObjects; // Para PhysicalMagnitude
using maintenance_calibration_system.Domain.Datos_de_Configuración; // Para Equipment
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.DataAccess.Respositories.Common;
using maintenance_calibration_system.Domain.Datos_de_Configuracion; // Para ApplicationContext

namespace maintenance_calibration_system.DataAccess.Respositories.Equipments
{
    public abstract class EquipmentRepository<T> : RepositoryBase<T> where T : Equipment
    {

        protected EquipmentRepository(ApplicationContext context) : base(context)
        {

        }   
    }
}