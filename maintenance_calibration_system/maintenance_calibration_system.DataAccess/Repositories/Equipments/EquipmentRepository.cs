using System;

using maintenance_calibration_system.DataAccess.Contexts;

using maintenance_calibration_system.Domain.Datos_de_Configuracion; // Para ApplicationContext

namespace maintenance_calibration_system.DataAccess.Respositories.Equipments
{
    public class EquipmentRepository<T> : RepositoryBase<T> where T : Equipment
    {

        public EquipmentRepository(ApplicationContext context) : base(context)
        {

        }   
    }
}