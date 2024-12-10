using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion; // Para ApplicationContext


namespace maintenance_calibration_system.DataAccess.Respositories.Equipments
{
    /// <summary>Repositorio para manejar entidades de tipo Equipment.</summary>
    public class EquipmentRepository<T> : RepositoryBase<T> where T : Equipment
    {
        /// <summary>Constructor que inicializa el repositorio con el contexto de la aplicación.</summary>
        /// <param name="context">El contexto de la aplicación.</param>
        public EquipmentRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
