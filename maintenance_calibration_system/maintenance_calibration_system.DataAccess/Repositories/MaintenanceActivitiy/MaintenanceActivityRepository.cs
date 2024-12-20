using maintenance_calibration_system.Domain.Datos_Historicos; 
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using maintenance_calibration_system.Contacts;


namespace maintenance_calibration_system.DataAccess.Respositories.MaintenanceActivitiy
{
    /// <summary>Repositorio para manejar entidades de tipo MaintenanceActivity.</summary>
    public class MaintenanceActivityRepository<T> : RepositoryBase<T>, IMaintenanceActivityRepository<T> where T : MaintenanceActivity
    {
        /// <summary>Constructor que inicializa el repositorio con el contexto de la aplicación.</summary>
        /// <param name="context">El contexto de la aplicación.</param>
        public MaintenanceActivityRepository(ApplicationContext context) : base(context)
        {

        }

    }
}
